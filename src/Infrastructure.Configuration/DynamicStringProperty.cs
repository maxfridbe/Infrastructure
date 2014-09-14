using System;
using System.Dynamic;

namespace Infrastructure.Configuration
{
    public class DynamicStringProperty : DynamicObject
    {
        private readonly string _value;

        public DynamicStringProperty(string value)
        {
            _value = value;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.ReturnType == typeof(bool))
            {
                result = bool.Parse(_value);
            }
            else if (binder.ReturnType == typeof(int))
            {
                result = int.Parse(_value);
            }
            else if (binder.ReturnType == typeof(float))
            {
                result = float.Parse(_value);
            }
            else if (binder.ReturnType == typeof(string))
            {
                result = _value;
            }
            else if (binder.ReturnType == typeof(DateTime))
            {
                result = DateTime.Parse(_value);
            }
            else
            {
                throw new Exception("Cannot convert string to type " + binder.ReturnType);
            }
            return true;
        }
    }
}