using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
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
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType is IEnumerable)
            {
                property.ShouldSerialize = instance =>
                {
                    IEnumerable enumer = instance
                        .GetType()
                        .GetProperty(property.PropertyName)
                        .GetValue(instance, null) as IEnumerable;

                    if (enumer != null)
                    {
                        // check to see if there is at least one item in the Enumerable
                        return enumer.GetEnumerator().MoveNext();
                    }
                    else
                    {
                        // if the enumerable is null, we defer the decision to NullValueHandling
                        return true;
                    }
                };
            }

            return property;
        }
    }
}
