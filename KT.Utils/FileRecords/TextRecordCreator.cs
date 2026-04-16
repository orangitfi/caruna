using KT.Utils.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace KT.Utils.FileRecords
{
    public class TextRecordCreator
    {

        #region Konstruktorit

        public TextRecordCreator(FieldSeparationMode fieldSeparationMode)
        {
            this.FieldSeparationMode = fieldSeparationMode;
            this.FieldSeparator = ";";
        } 

        #endregion

        #region Propertyt

        public RecordItemTemplate ItemTemplate { get; set; }        

        public RecordItemTemplate HeaderTemplate { get; set; }        

        public RecordItemTemplate FooterTemplate { get; set; }

        public FieldSeparationMode FieldSeparationMode { get; set; }        

        public string FieldSeparator { get; set; }        

        public string ItemSeparator { get; set; }        

        public System.Text.Encoding Encoding { get; set; }
        
        public bool CreateHeaderFromFirstDataRow { get; set; }
        
        public bool CreateFooterFromLastDataRow { get; set; }        

        public DataRow HeaderData { get; set; }        

        public DataRow FooterData { get; set; }        

        public string HeaderString { get; set; }        

        public string FooterString { get; set; }        

        #endregion

        #region Metodit

        public string CreateFileString(DataTable data, MappingKeyPair[] mappings)
        {
            StringBuilder sb = new StringBuilder();

            if (((this.HeaderData != null) || (this.HeaderString != null)) && !this.CreateHeaderFromFirstDataRow)
            {
                if ((this.HeaderData != null))
                {
                    this.WriteRow(this.HeaderTemplate, mappings, this.HeaderData, sb);
                }
                else
                {
                    sb.Append(this.HeaderString);
                    if ((this.ItemSeparator != null))
                        sb.Append(this.ItemSeparator);
                }
            }

            int index = 0;
            int lastIndex = data.Rows.Count - 1;


            foreach (DataRow dr in data.Rows)
            {
                RecordItemTemplate template = null; // Activator.CreateInstance<RecordItemTemplate>();

                if (index == 0 && this.CreateHeaderFromFirstDataRow)
                {
                    template = this.HeaderTemplate;
                }
                else if (index == lastIndex && this.CreateFooterFromLastDataRow)
                {
                    template = this.FooterTemplate;
                }
                else
                {
                    template = this.ItemTemplate;
                }

                this.WriteRow(template, mappings, dr, sb);
                index += 1;
            }

            if (((this.FooterData != null) || (this.FooterString != null)) && !this.CreateFooterFromLastDataRow)
            {
                if ((this.FooterData != null))
                {
                    this.WriteRow(this.FooterTemplate, mappings, this.FooterData, sb);
                }
                else
                {
                    sb.Append(this.FooterString);
                    if ((this.ItemSeparator != null))
                        sb.Append(this.ItemSeparator);
                }
            }

            return sb.ToString();
        }

        public bool CreateFile(string filename, DataTable data, MappingKeyPair[] mappings)
        {

            string fileString = this.CreateFileString(data, mappings);

            using (StreamWriter writer = new StreamWriter(filename, false, this.Encoding))
            {
                try
                {
                    writer.Write(fileString);
                }
                catch (IOException)
                {
                    return false;
                }
                finally
                {
                    writer.Close();
                }
            }

            return true;
        }

        private void WriteRow(RecordItemTemplate template, MappingKeyPair[] mappings, DataRow dr, StringBuilder sb)
        {
            int fieldCount = 0;
            if ((mappings == null))
            {
                foreach (DataField field in template.Fields)
                {
                    object value = dr[field.Name];
                    if (this.FieldSeparationMode == FieldSeparationMode.Separator && fieldCount > 0)
                    {
                        sb.Append(this.FieldSeparator);
                    }
                    this.WriteField(field, value, sb, template);
                    fieldCount += 1;
                }

            }
            else
            {
                
                foreach (MappingKeyPair mapping in mappings)
                {
                    object value = dr[mapping.SourceKey];
                    string targetKey = mapping.TargetKey;
                    DataField field = this.ItemTemplate.Fields.Single(f => f.Name == targetKey);
                    if (this.FieldSeparationMode == FieldSeparationMode.Separator && fieldCount > 0)
                    {
                        sb.Append(this.FieldSeparator);
                    }
                    this.WriteField(field, value, sb, template);
                    fieldCount += 1;
                }

            }

            if ((this.ItemSeparator != null))
                sb.Append(this.ItemSeparator);
        }


        private void WriteField(DataField field, object value, StringBuilder sb, RecordItemTemplate template)
        {
            if ((value != null) && !(System.DBNull.Value == value) && (field.DataFormatFunction != null))
                value = field.DataFormatFunction(value);

            string stringValue = null;
            if ((value == null) || System.DBNull.Value == value)
            {
                if (field.IsRequired)
                    throw new ArgumentException(string.Format("Required field '{0}' must have a value.", field.Name));
                stringValue = null;
            }
            else
            {
                stringValue = value.ToString();
            }

            if (field.Length > 0 && (stringValue != null) && stringValue.Length > field.Length)
                throw new ArgumentException(string.Format("Value is too long for field '{0}'", field.Name));

            if (this.FieldSeparationMode == FieldSeparationMode.FixedSize)
            {
                char paddingChar;
                if ((stringValue == null))
                {
                    paddingChar = ' ';
                    stringValue = string.Empty;
                }
                else
                {
                    paddingChar = Convert.ToChar((field.PaddingChar.HasValue ? field.PaddingChar.GetValueOrDefault(' ') : template.DefaultPaddingChar));
                }

                bool padToRight = Convert.ToBoolean((field.PadToRight.HasValue ? field.PadToRight.GetValueOrDefault(false) : template.PadToRight));

                if (padToRight)
                {
                    stringValue = stringValue.PadRight(field.Length, paddingChar);
                }
                else
                {
                    stringValue = stringValue.PadLeft(field.Length, paddingChar);
                }

                sb.Append(stringValue);
            }
            else
            {
                sb.Append(value);
            }
        }

        #endregion

    }

}
