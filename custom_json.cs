using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cdda_item_creator
{
    public class IgnoreEmptyEnumerablesResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);

            if (typeof(IEnumerable<object>).IsAssignableFrom(jsonProperty.PropertyType))
            {
                jsonProperty.ShouldSerialize = instance => {
                    var value = instance.GetType()
                        .GetProperty(jsonProperty.PropertyName)
                        ?.GetValue(instance);

                    if (value == null)
                    {
                        return false;
                    }

                    return ((IEnumerable<object>)value).GetEnumerator()
                        .MoveNext();
                };
            }

            return jsonProperty;
        }
    }
}
