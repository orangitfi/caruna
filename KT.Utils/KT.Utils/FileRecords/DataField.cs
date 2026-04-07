using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils.FileRecords
{
    public class DataField
    {

        #region Konstruktorit

        public DataField()
        {
        }

        public DataField(string name, Type dataType)
            : this(name, dataType, 0)
        {
        }

        public DataField(string name, Type dataType, int length)
            : this(name, dataType, length, false, null, null, null)
        {
        }

        public DataField(string name, Type dataType, int length, bool isRequired)
            : this(name, dataType, length, isRequired, null, null, null)
        {
        }

        public DataField(string name, Type dataType, int length, bool isRequired, char paddingChar, bool padToRight)
            : this(name, dataType, length, isRequired, paddingChar, padToRight, null)
        {
        }

        public DataField(string name, Type dataType, int length, bool isRequired, DataFormatFunction dataFormatFunction)
            : this(name, dataType, length, isRequired, null, null, dataFormatFunction)
        {
        }

        public DataField(string name, Type dataType, int length, bool isRequired, char? paddingChar, bool? padToRight, DataFormatFunction dataFormatFunction)
        {
            this.Name = name;
            this.DataType = dataType;
            this.Length = length;
            this.IsRequired = isRequired;
            this.DataFormatFunction = dataFormatFunction;
            this.PaddingChar = paddingChar;
            this.PadToRight = padToRight;
        } 

        #endregion

        #region Propertyt

        public string Name { get; set; }        

        public Type DataType { get; set; }       

        public int Length  { get; set; }        

        public bool IsRequired { get; set; }        

        public char? PaddingChar { get; set; }        

        public bool? PadToRight { get; set; }        

        public DataFormatFunction DataFormatFunction { get; set; }        

        #endregion

    }

}
