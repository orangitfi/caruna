#!/usr/bin/env python3
"""
Generate CREATE TABLE statements for all tables.
Extracts schema from SQL Server and creates DDL scripts.
"""

import subprocess
import sys
import re

def run_sql(query):
    """Execute SQL query and return output."""
    cmd = [
        'docker', 'exec', 'caruna-db',
        '/opt/mssql-tools18/bin/sqlcmd',
        '-S', 'localhost',
        '-U', 'SA',
        '-P', 'DevPassword123!',
        '-C',
        '-d', 'Fortum',
        '-Q', query,
        '-s', '|',
        '-W',
        '-w', '8000',
        '-h', '-1'
    ]
    
    result = subprocess.run(cmd, capture_output=True, text=True)
    if result.returncode != 0:
        print(f"Error: {result.stderr}", file=sys.stderr)
        return None
    return result.stdout

def clean_output(output):
    """Clean SQL Server output."""
    if not output:
        return []
    
    lines = []
    for line in output.strip().split('\n'):
        line = line.strip()
        if not line or '---' in line:
            continue
        if 'rows affected' in line.lower():
            continue
        if line.startswith('(') and line.endswith(')'):
            continue
        lines.append(line)
    return lines

def get_tables():
    """Get all table names."""
    query = """
    SELECT name 
    FROM sys.tables 
    WHERE type = 'U'
    AND name NOT LIKE 'sys%'
    ORDER BY name;
    """
    output = run_sql(query)
    return clean_output(output)

def get_table_columns(table_name):
    """Get column definitions for a table."""
    query = f"""
    SELECT 
        c.column_id,
        c.name AS column_name,
        TYPE_NAME(c.user_type_id) AS data_type,
        c.max_length,
        c.precision,
        c.scale,
        c.is_nullable,
        c.is_identity,
        dc.definition AS default_value
    FROM sys.columns c
    LEFT JOIN sys.default_constraints dc ON c.default_object_id = dc.object_id
    WHERE c.object_id = OBJECT_ID('{table_name}')
    ORDER BY c.column_id;
    """
    output = run_sql(query)
    lines = clean_output(output)
    
    columns = []
    for line in lines:
        parts = [p.strip() for p in line.split('|')]
        if len(parts) >= 8:
            columns.append({
                'column_id': parts[0],
                'name': parts[1],
                'data_type': parts[2],
                'max_length': parts[3],
                'precision': parts[4],
                'scale': parts[5],
                'is_nullable': parts[6],
                'is_identity': parts[7],
                'default_value': parts[8] if len(parts) > 8 else None
            })
    return columns

def get_primary_key(table_name):
    """Get primary key info."""
    query = f"""
    SELECT 
        i.name AS index_name,
        COL_NAME(ic.object_id, ic.column_id) AS column_name
    FROM sys.indexes i
    INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    WHERE i.object_id = OBJECT_ID('{table_name}')
    AND i.is_primary_key = 1
    ORDER BY ic.key_ordinal;
    """
    output = run_sql(query)
    lines = clean_output(output)
    
    pk_info = {'name': None, 'columns': []}
    for line in lines:
        parts = [p.strip() for p in line.split('|')]
        if len(parts) >= 2:
            if not pk_info['name']:
                pk_info['name'] = parts[0]
            pk_info['columns'].append(parts[1])
    
    return pk_info if pk_info['columns'] else None

def format_data_type(col):
    """Format SQL Server data type."""
    data_type = col['data_type'].upper()
    
    # String types
    if data_type in ('VARCHAR', 'CHAR', 'NVARCHAR', 'NCHAR', 'VARBINARY', 'BINARY'):
        max_len = int(col['max_length'])
        if max_len == -1:
            return f"{data_type}(MAX)"
        if data_type.startswith('N'):
            max_len = max_len // 2
        return f"{data_type}({max_len})"
    
    # Decimal types
    if data_type in ('DECIMAL', 'NUMERIC'):
        precision = col['precision']
        scale = col['scale']
        return f"{data_type}({precision}, {scale})"
    
    # Other types
    return data_type

def generate_create_table(table_name):
    """Generate CREATE TABLE statement."""
    columns = get_table_columns(table_name)
    if not columns:
        return None
    
    pk_info = get_primary_key(table_name)
    
    sql = f"CREATE TABLE [dbo].[{table_name}] (\n"
    
    col_defs = []
    for col in columns:
        col_def = f"    [{col['name']}] {format_data_type(col)}"
        
        # Identity
        if col['is_identity'] == '1':
            col_def += " IDENTITY(1,1)"
        
        # Nullable
        if col['is_nullable'] == '0':
            col_def += " NOT NULL"
        else:
            col_def += " NULL"
        
        # Default
        if col['default_value'] and col['default_value'] != 'NULL':
            col_def += f" DEFAULT {col['default_value']}"
        
        col_defs.append(col_def)
    
    # Add primary key constraint
    if pk_info:
        pk_cols = ', '.join(f"[{col}]" for col in pk_info['columns'])
        col_defs.append(f"    CONSTRAINT [{pk_info['name']}] PRIMARY KEY CLUSTERED ({pk_cols})")
    
    sql += ',\n'.join(col_defs)
    sql += "\n);"
    
    return sql

def main():
    """Main function."""
    print("Generating CREATE TABLE statements...")
    
    tables = get_tables()
    if not tables:
        print("Error: No tables found!", file=sys.stderr)
        return 1
    
    print(f"Found {len(tables)} tables")
    
    output_file = 'database/migrations/000_schema.sql'
    
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write("-- Database Schema (DDL)\n")
        f.write("-- CREATE TABLE statements for Fortum database\n")
        f.write(f"-- Generated from SQL Server 2022\n")
        f.write("-- Total tables: {}\n\n".format(len(tables)))
        f.write("SET NOCOUNT ON;\n")
        f.write("GO\n\n")
        
        success_count = 0
        for i, table in enumerate(tables, 1):
            print(f"  [{i}/{len(tables)}] Processing {table}...", end='')
            
            try:
                create_sql = generate_create_table(table)
                if create_sql:
                    f.write(f"-- Table: {table}\n")
                    f.write(create_sql + "\n")
                    f.write("GO\n\n")
                    success_count += 1
                    print(" OK")
                else:
                    print(" SKIP (no columns)")
            except Exception as e:
                print(f" ERROR: {e}")
                continue
    
    print(f"\n✓ Generated {success_count}/{len(tables)} tables")
    print(f"✓ Saved to: {output_file}")
    
    return 0

if __name__ == '__main__':
    sys.exit(main())
