using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils
{
    public class KeyObjectValuePair
    {

        private string _key;

        private object _value;

        public KeyObjectValuePair()
        {
        }

        public KeyObjectValuePair(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        public object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }


    }
}
