using System;

namespace CafeRestaurantOtomasyonu
{
    public class DinamikSqlParameter
    {
        readonly string _parameterName;
        readonly object _value;

        public DinamikSqlParameter(string parameterName, object value)
        {
            _parameterName = parameterName;
            _value = value;
        }

        public string ParameterName
        {
            get { return _parameterName; }
        }

        public object Value
        {
            get { return _value; }
        }
    }
}
