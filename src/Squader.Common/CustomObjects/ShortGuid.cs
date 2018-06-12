using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace Squader.Common.CustomObjects
{
    //Experimental
    public struct ShortGuid
    {
        private string _value;

        public override string ToString() => this._value;
        

        public ShortGuid(string value)
        {
            _value = value;
        }

        public static implicit operator ShortGuid(string value)
        {
            // While not technically a requirement; see below why this is done.
            if (value == null)
                return null;

            return new ShortGuid(value);
        }

        public static explicit operator string(ShortGuid value)
        {
            return value._value;
        }
        
    }
}
