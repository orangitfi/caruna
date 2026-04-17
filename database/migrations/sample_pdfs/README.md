# Sample PDF Export Instructions

## Step 1: Export 3 PDFs from Database (One-time manual step)

### Using DBeaver:

1. **Connect to database** (localhost:1433, Fortum)

2. **Run this query:**
```sql
SELECT TOP 3 
    STLId, 
    STLSopimusId, 
    STLTuloste,
    DATALENGTH(STLTuloste) AS Size
FROM Sopimus_Tuloste 
WHERE STLTuloste IS NOT NULL
ORDER BY DATAL ENGTH(STLTuloste) ASC
```

3. **Export PDFs:**
   - Right-click on each `STLTuloste` cell in results
   - Choose **"Save Content" → "Save to File"**
   - Save as:
     - `database/migrations/sample_pdfs/sample_8.pdf` (STLId=8)
     - `database/migrations/sample_pdfs/sample_2.pdf` (STLId=2)
     - `database/migrations/sample_pdfs/sample_145.pdf` (STLId=145)

### Using SQL Server Management Studio (SSMS):

1. Run the same query
2. Right-click results → **"Save Results As"** → CSV
3. Open CSV, extract binary data from PDF column

### Using Azure Data Studio:

1. Run the query
2. Click on binary cell → "Save as file"

## Step 2: Generate SQL Migration Script

Once you have the 3 PDF files saved, run:

```bash
python3 database/scripts/upload_pdfs.py
```

This will:
- Read the 3 binary PDF files
- Generate `database/migrations/003_sample_pdfs.sql` with hex-encoded PDFs
- Use fake test IDs (99001-99003) to avoid FK issues
- No references to non-existent Sopimus records

## Why Manual Export?

- Python pyodbc installation issues on macOS
- SQL Server BCP tool doesn't work properly in Docker
- mssql-tools sqlcmd has limitations on binary data size
- **Easiest:** One-time manual export with GUI tool that handles binaries correctly

## Result

You'll have:
- ✅ 3 real PDF files (binary) in `database/migrations/sample_pdfs/`
- ✅ `003_sample_pdfs.sql` with embedded hex data for version control
- ✅ ~290 KB of real production PDFs for testing
