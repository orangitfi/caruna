using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KT.Utils.FileRecords
{
    public class RecordItemTemplate
    {

        #region Attribuutit ja vakiot

        private List<DataField> _fields;

        #endregion

        #region Konstruktorit

        public RecordItemTemplate()
        {
            this.DefaultPaddingChar = ' ';
        }


        public RecordItemTemplate(DataField[] fields)
            : this()
        {
            foreach (DataField field in fields)
            {
                this.AddField(field);
            }

        } 

        #endregion

        #region Propertyt

        internal List<DataField> Fields
        {
            get
            {
                if (this._fields == null)
                    this._fields = new List<DataField>();
                return this._fields;
            }
        }

        public char DefaultPaddingChar { get; set; }

        public bool PadToRight { get; set; }        

        #endregion

        #region Metodit

        public void AddField(DataField field)
        {
            this.Fields.Add(field);
        }

        public DataTable CreateDataTableFromTemplate()
        {
            DataTable dt = new DataTable();

            foreach (DataField field in this.Fields)
            {
                dt.Columns.Add(new DataColumn(field.Name, field.DataType));
            }

            return dt;
        }

        #endregion

    }
}
