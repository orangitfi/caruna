#!/usr/bin/env python3
"""
Generate INSERT statements for lookup tables.
Connects to SQL Server and exports small reference tables to SQL scripts.
"""

import subprocess
import sys
import re

# Lookup tables to export (tables with < 100 rows)
LOOKUP_TABLES = [
    'hlp_AktiviteetinLaji', 'hlp_AktiviteetinStatus', 'hlp_AktiviteettiYhteystapa',
    'hlp_Alv', 'hlp_ArkistonSijainti', 'hlp_Asiakastyyppi', 'hlp_BicKoodi',
    'hlp_DFRooli', 'hlp_HinnastoAlakategoria', 'hlp_HinnastoKategoria',
    'hlp_Indeksi', 'hlp_Indeksityyppi', 'hlp_InvCost', 'hlp_Julkisuusaste',
    'hlp_Kieli', 'hlp_KirjanpidonKustannuspaikka', 'hlp_Kirjanpidontili',
    'hlp_Kohdekategoria', 'hlp_Kyla', 'hlp_LiiketoiminnanTarve', 'hlp_Local1',
    'hlp_Lupataho', 'hlp_MaaraAlaTarkenne', 'hlp_MaksunSuoritus', 'hlp_Metsatyyppi',
    'hlp_Purpose', 'hlp_Puustolaji', 'hlp_PuustonOmistajuus', 'hlp_PuustonPoisto',
    'hlp_Regulation', 'hlp_Saanto', 'hlp_SiirtoOikeus', 'hlp_SopimuksenAlaluokka',
    'hlp_SopimuksenEhtoversio', 'hlp_SopimuksenKesto', 'hlp_SopimusFormaatti',
    'hlp_Vuokratyyppi', 'hlp_Yksikko',
    'hlps_KorvauslaskemaStatus', 'hlps_Korvaustyyppi', 'hlps_KorvausyksikonTyyppi',
    'hlps_Kuukausi', 'hlps_MaksuStatus', 'hlps_OrganisaationTyyppi',
    'hlps_SopimuksenTila', 'hlps_Sopimusluokka', 'hlps_TahoTyyppi',
    'hlps_Tiedostolahde', 'hlps_YlasopimuksenTyyppi'
]

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
        '-s', '|',  # Column separator
        '-W',  # Trim spaces
        '-w', '8000',  # Line width
        '-h', '-1'  # No headers
    ]
    
    result = subprocess.run(cmd, capture_output=True, text=True)
    if result.returncode != 0:
        print(f"Error executing SQL: {result.stderr}", file=sys.stderr)
        return None
    return result.stdout

def has_identity_column(table_name):
    """Check if table has an IDENTITY column."""
    query = f"""
    SELECT COUNT(*)
    FROM sys.columns 
    WHERE object_id = OBJECT_ID('{table_name}')
    AND is_identity = 1;
    """
    output = run_sql(query)
    if not output:
        return False
    
    # Parse the count
    for line in output.strip().split('\n'):
        line = line.strip()
        if line.isdigit():
            return int(line) > 0
    
    return False

def get_columns(table_name):
    """Get column names for a table."""
    query = f"""
    SELECT name 
    FROM sys.columns 
    WHERE object_id = OBJECT_ID('{table_name}')
    ORDER BY column_id;
    """
    output = run_sql(query)
    if not output:
        return []
    
    # Filter out status messages
    columns = []
    for line in output.strip().split('\n'):
        line = line.strip()
        if not line:
            continue
        if '---' in line:
            continue
        if 'rows affected' in line.lower():
            continue
        if line.startswith('(') and line.endswith(')'):
            continue
        columns.append(line)
    
    return columns

def get_data(table_name):
    """Get all data from a table."""
    query = f"SELECT * FROM {table_name};"
    output = run_sql(query)
    if not output:
        return []
    
    # Filter out SQL Server status messages and empty lines
    lines = []
    for line in output.strip().split('\n'):
        line = line.strip()
        if not line:
            continue
        if '---' in line:  # Header separator
            continue
        if 'rows affected' in line.lower():  # Status message
            continue
        if line.startswith('(') and line.endswith(')'):  # (X rows affected)
            continue
        lines.append(line)
    
    return lines

def escape_sql_value(value):
    """Escape a value for SQL INSERT."""
    if value is None or value == '' or value.upper() == 'NULL':
        return 'NULL'
    
    # Remove pipe separators and trim
    value = value.strip().strip('|').strip()
    
    if value.upper() == 'NULL':
        return 'NULL'
    
    # Escape single quotes
    value = value.replace("'", "''")
    return f"'{value}'"

def generate_insert(table_name, columns, row_data):
    """Generate INSERT statement for a row."""
    values = [val.strip() for val in row_data.split('|')]
    
    # Pad values if needed
    while len(values) < len(columns):
        values.append('NULL')
    
    escaped_values = [escape_sql_value(v) for v in values[:len(columns)]]
    
    cols_str = ', '.join(f'[{col}]' for col in columns)
    vals_str = ', '.join(escaped_values)
    
    return f"INSERT INTO [{table_name}] ({cols_str}) VALUES ({vals_str});"

def main():
    """Main function."""
    output_file = 'database/migrations/001_lookup_data.sql'
    
    print(f"Generating INSERT statements for {len(LOOKUP_TABLES)} tables...")
    
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write("-- Lookup/Reference Data\n")
        f.write("-- Auto-generated from Fortum database\n")
        f.write("-- Tables: hlp_* and hlps_* (< 100 rows each)\n\n")
        f.write("SET NOCOUNT ON;\nGO\n\n")
        
        for table in sorted(LOOKUP_TABLES):
            print(f"  Processing {table}...", end='')
            
            columns = get_columns(table)
            if not columns:
                print(" SKIP (no columns)")
                continue
            
            rows = get_data(table)
            if not rows:
                print(" SKIP (no data)")
                continue
            
            # Check if table has IDENTITY column
            has_identity = has_identity_column(table)
            
            f.write(f"-- Table: {table} ({len(rows)} rows)\n")
            
            # Enable IDENTITY_INSERT only if table has IDENTITY column
            if has_identity:
                f.write(f"SET IDENTITY_INSERT [{table}] ON;\n")
            
            for row in rows:
                try:
                    insert_stmt = generate_insert(table, columns, row)
                    f.write(insert_stmt + '\n')
                except Exception as e:
                    print(f"\n  ERROR in {table}: {e}", file=sys.stderr)
                    continue
            
            # Disable IDENTITY_INSERT only if it was enabled
            if has_identity:
                f.write(f"SET IDENTITY_INSERT [{table}] OFF;\n")
            f.write("GO\n\n")
            print(f" OK ({len(rows)} rows)")
    
    print(f"\n✓ Generated: {output_file}")

if __name__ == '__main__':
    main()
