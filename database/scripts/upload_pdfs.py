#!/usr/bin/env python3
"""
Upload real PDF files to database migration script.

Reads 3 exported PDF files from database/migrations/sample_pdfs/
and generates SQL INSERT statements with hex-encoded binary data.

Uses fake test IDs to avoid references to non-existent Sopimus records.
"""

import sys
import os
from datetime import datetime

def bytes_to_hex_string(data):
    """Convert bytes to SQL hex string (0x...)."""
    return '0x' + data.hex().upper()

def main():
    """Generate SQL script from exported PDF files."""
    
    print("=" * 60)
    print("UPLOAD REAL PDFs TO MIGRATION")
    print("=" * 60)
    
    # PDF files to process (exported from database)
    # Using fake test IDs to avoid FK issues
    pdf_files = [
        {
            'file': 'STLTuloste.pdf',
            'stl_id': 99001,
            'sopimus_id': 99001,
            'luoja': 'test_user',
            'luotu': '2026-04-10 09:00:00.000',
            'description': 'Test PDF #1'
        },
        {
            'file': 'STLTuloste2.pdf',
            'stl_id': 99002,
            'sopimus_id': 99002,
            'luoja': 'test_user',
            'luotu': '2026-04-10 09:01:00.000',
            'description': 'Test PDF #2'
        },
        {
            'file': 'STLTuloste3.pdf',
            'stl_id': 99003,
            'sopimus_id': 99003,
            'luoja': 'test_user',
            'luotu': '2026-04-10 09:02:00.000',
            'description': 'Test PDF #3'
        }
    ]
    
    pdf_dir = 'database/migrations/sample_pdfs'
    output_file = 'database/migrations/003_sample_pdfs.sql'
    
    print(f"\n📂 Reading PDF files from: {pdf_dir}/")
    print()
    
    # Check if files exist
    missing_files = []
    for pdf in pdf_files:
        filepath = os.path.join(pdf_dir, pdf['file'])
        if not os.path.exists(filepath):
            missing_files.append(pdf['file'])
    
    if missing_files:
        print(f"❌ Missing PDF files: {', '.join(missing_files)}")
        print()
        print("Expected files:")
        for pdf in pdf_files:
            print(f"  - {pdf_dir}/{pdf['file']}")
        return 1
    
    # Read PDF files and convert to hex
    total_size = 0
    pdf_data = []
    
    for i, pdf in enumerate(pdf_files, 1):
        filepath = os.path.join(pdf_dir, pdf['file'])
        
        print(f"  [{i}/3] Reading: {pdf['file']}")
        
        with open(filepath, 'rb') as f:
            binary_data = f.read()
        
        file_size = len(binary_data)
        hex_data = bytes_to_hex_string(binary_data)
        
        pdf_data.append({
            **pdf,
            'hex_data': hex_data,
            'size': file_size
        })
        
        total_size += file_size
        
        print(f"       Size: {file_size:,} bytes ({file_size/1024:.1f} KB)")
        print(f"       Hex: {len(hex_data):,} chars ({len(hex_data)/1024:.1f} KB)")
        print(f"       → STLId: {pdf['stl_id']}, SopimusId: {pdf['sopimus_id']}")
        print()
    
    # Generate SQL script
    print("=" * 60)
    print(f"Generating: {output_file}")
    print("=" * 60)
    
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write("-- Sample PDF Data (Real PDFs from production database)\n")
        f.write("-- Auto-generated from exported binary PDF files\n")
        f.write(f"-- Generated: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
        f.write(f"-- Total size: {total_size:,} bytes ({total_size/1024:.1f} KB)\n\n")
        f.write("-- NOTE: Uses fake test IDs (99001-99003) to avoid FK issues\n")
        f.write("--       Sopimus table is empty in migrations, so no real references\n")
        f.write("--       These PDFs are for testing PDF display/download functionality\n\n")
        f.write("SET NOCOUNT ON;\n")
        f.write("GO\n\n")
        
        f.write("PRINT 'Loading 3 sample PDF files (real production PDFs)...';\n")
        f.write("SET IDENTITY_INSERT [Sopimus_Tuloste] ON;\n")
        f.write("GO\n\n")
        
        for i, pdf in enumerate(pdf_data, 1):
            f.write(f"-- Real PDF {i}: {pdf['file']} - {pdf['description']}\n")
            f.write(f"-- STLId={pdf['stl_id']} (FAKE TEST ID), SopimusId={pdf['sopimus_id']} (FAKE TEST ID)\n")
            f.write(f"-- Size: {pdf['size']:,} bytes ({pdf['size']/1024:.1f} KB)\n")
            f.write(f"-- Note: Does not reference actual Sopimus (table is empty in migrations)\n")
            f.write(f"INSERT INTO [Sopimus_Tuloste] (\n")
            f.write(f"    [STLId], [STLSopimusId], [STLTuloste],\n")
            f.write(f"    [STLLuoja], [STLLuotu], [STLPaivittaja], [STLPaivitetty]\n")
            f.write(f") VALUES (\n")
            f.write(f"    {pdf['stl_id']},\n")
            f.write(f"    {pdf['sopimus_id']},\n")
            f.write(f"    {pdf['hex_data']},\n")
            f.write(f"    '{pdf['luoja']}',\n")
            f.write(f"    '{pdf['luotu']}',\n")
            f.write(f"    '{pdf['luoja']}',\n")
            f.write(f"    '{pdf['luotu']}'\n")
            f.write(f");\n")
            f.write(f"GO\n\n")
        
        f.write("SET IDENTITY_INSERT [Sopimus_Tuloste] OFF;\n")
        f.write("GO\n\n")
        f.write(f"PRINT 'Loaded 3 sample PDF files successfully ({total_size:,} bytes total)';\n")
        f.write(f"PRINT 'Test IDs used: 99001, 99002, 99003 (no FK references to Sopimus)';\n")
        f.write("GO\n")
    
    sql_size = os.path.getsize(output_file)
    
    print()
    print(f"✅ Generated: {output_file}")
    print(f"   SQL size: {sql_size:,} bytes ({sql_size/1024:.1f} KB)")
    print(f"   Binary PDFs: {total_size:,} bytes ({total_size/1024:.1f} KB)")
    print(f"   Overhead: {(sql_size/total_size - 1)*100:.1f}% (hex encoding)")
    print()
    print("=" * 60)
    print("✅ Complete! 3 real production PDFs embedded in SQL script")
    print("   Using fake test IDs (99001-99003) - no FK issues")
    print("=" * 60)
    
    return 0

if __name__ == "__main__":
    sys.exit(main())
