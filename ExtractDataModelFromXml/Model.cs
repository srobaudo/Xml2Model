using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ExtractDataModelFromXml
{
    public sealed class Model : DynamicObject
    {
        private readonly Dictionary<string, object> _properties;

        public Model(Dictionary<string, object> properties)
        {
            _properties = properties;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                return true;
            }

            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!_properties.ContainsKey(binder.Name))
            {
                return false;
            }

            _properties[binder.Name] = value;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var key in _properties.Keys)
            {
                sb.AppendLine($"{key} => {_properties[key]}");
            }

            return sb.ToString();
        }
    }
}