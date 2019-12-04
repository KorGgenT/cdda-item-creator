using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
                        .GetProperty(member.Name)
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

    public class MonsterAttackConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            MonsterAttack attack = value as MonsterAttack;
            if(attack.Type == "hardcoded")
            {
                JArray array = new JArray { attack.Id, attack.Cooldown };
                array.WriteTo(writer);
            }

            JToken token = JToken.FromObject(attack,
                new JsonSerializer
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                }
                );
            token.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                JArray array = JArray.Load(reader);
                return new MonsterAttack
                {
                    Id = (string)array[0],
                    Cooldown = (int)array[1]
                };
            }
            else 
            {
                JToken obj = JToken.Load(reader);
                return obj.ToObject<T>();
            }            
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(MonsterAttack).IsAssignableFrom(objectType);
        }
    }
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            return new List<T> { token.ToObject<T>() };
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class DamageInstanceConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DamageInstance));
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DamageInstance instance = (DamageInstance)value;
            JToken token = JToken.FromObject(instance.Values,
                new JsonSerializer
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                }
                );
            token.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            DamageInstance instance = new DamageInstance { };
            if(token.Type == JTokenType.Array)
            {
                foreach(JObject jo in token.ToObject<List<JObject>>())
                {
                    DamageUnit du = (DamageUnit)jo.ToObject(typeof(DamageUnit),
                        new JsonSerializer
                        {
                            ContractResolver = new DefaultContractResolver
                            {
                                NamingStrategy = new SnakeCaseNamingStrategy()
                            }
                        });
                    instance.Add(du);
                }
            }
            else
            {
                return token.ToObject<T>();
            }
            return instance;
        }
    }
    public class VolumeConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if(token.Type == JTokenType.String)
            {
                return token.ToObject<string>();
            } else if(token.Type == JTokenType.Integer)
            {
                int vol_ml = token.ToObject<int>() * 250;
                if(vol_ml % 1000 == 0)
                {
                    return (vol_ml / 1000).ToString() + " L";
                }
                return vol_ml.ToString() + " ml";
            }
            return null;
        }
    }
    public class WeightConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                return token.ToObject<string>();
            }
            else if (token.Type == JTokenType.Integer)
            {
                int grams = token.ToObject<int>();
                if (grams % 1000 == 0)
                {
                    return (grams / 1000).ToString() + " kg";
                }
                return grams.ToString() + " g";
            }
            return null;
        }
    }
    public class TranslationConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Translation));
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToObject<Translation>();
            }
            else if (token.Type == JTokenType.String)
            {
                string name = token.ToString();
                return new Translation { Str = name };
            }
            return null;
        }
    }
}
