using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils
{
    public class TypeCache
    {
        #region Attribuutit ja vakiot

        private Type _booleanType;
        private Type _byteType;
        private Type _charType;
        private Type _dateTimeType;
        private Type _decimalType;
        private Type _doubleType;
        private Type _intType;
        private Type _longType;
        private Type _shortType;
        private Type _stringType;

        private Dictionary<string, Type> _specialTypeList;
        #endregion

        #region Ctors

        public TypeCache()
        {
        }

        #endregion

        #region Propertyt

        public Type BooleanType
        {
            get
            {
                if ((this._booleanType == null))
                    this._booleanType = typeof(bool);
                return this._booleanType;
            }
        }

        public Type ByteType
        {
            get
            {
                if (this._byteType == null) this._byteType = typeof(byte);
                return this._byteType;
            }
        }

        public Type CharType
        {
            get
            {
                if ((this._charType == null))
                    this._charType = typeof(char);
                return this._charType;
            }
        }

        public Type DateTimeType
        {
            get
            {
                if ((_dateTimeType == null))
                    this._dateTimeType = typeof(DateTime);
                return this._dateTimeType;
            }
        }

        public Type DecimalType
        {
            get
            {
                if ((this._decimalType == null))
                    this._decimalType = typeof(decimal);
                return this._decimalType;
            }
        }

        public Type DoubleType
        {
            get
            {
                if ((this._doubleType == null))
                    this._doubleType = typeof(double);
                return this._doubleType;
            }
        }

        public Type IntegerType
        {
            get
            {
                if ((this._intType == null))
                    this._intType = typeof(int);
                return this._intType;
            }
        }

        public Type LongType
        {
            get
            {
                if ((this._longType == null))
                    this._longType = typeof(long);
                return this._longType;
            }
        }

        public Type ShortType
        {

            get
            {
                if (this._shortType == null) this._shortType = typeof(short);
                return this._shortType;
            }
        }

        public Type StringType
        {
            get
            {
                if ((this._stringType == null))
                    this._stringType = typeof(string);
                return this._stringType;
            }
        }


        private Dictionary<string, Type> CustomTypeList
        {
            get
            {
                if ((this._specialTypeList == null))
                    this._specialTypeList = new Dictionary<string, Type>();
                return this._specialTypeList;
            }
        }

        #endregion

        #region Metodit

        public object GetTypeByName(string typeName)
        {

            Type t = null;

            if (!this.CustomTypeList.ContainsKey(typeName))
            {
                t = Type.GetType(typeName);
                this.CustomTypeList[typeName] = t;
            }
            else
            {
                t = this.CustomTypeList[typeName];
            }

            return t;

        }

        #endregion

    }
}
