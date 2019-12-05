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
    // expects a List<MonsterAttack>
    public class MonsterAttackConverter : JsonConverter
    {
        private JObject JODiff(JObject jo_base, JObject jo_compare)
        {
            if(jo_base.Count == 0)
            {
                return jo_compare;
            }

            JObject ret;
            if (jo_base.GetValue("id") == null)
            {
                ret = new JObject { { "Id", jo_base.GetValue("Id") } };
            } else
            {
                ret = new JObject { { "id", jo_base.GetValue("id") } };
            }

            foreach (KeyValuePair<string, JToken> token in jo_base)
            {
                if (!JToken.DeepEquals(token.Value, jo_compare.GetValue(token.Key)))
                {
                    ret.Add(token.Key, jo_compare.GetValue(token.Key));
                }
            }

            return ret;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<MonsterAttack> attacks = value as List<MonsterAttack>;
            JArray attacks_array = new JArray { };
            foreach (MonsterAttack attack in attacks)
            {
                if (attack.Type == "hardcoded")
                {
                    JArray array = new JArray { attack.Id, attack.Cooldown };
                    attacks_array.Add(array);
                }
                else
                {
                    List<MonsterAttack> mon_list = Program.LoadedObjectDictionary.GetMAttacks(attack.Id);
                    JObject jo_base = new JObject { };
                    if(mon_list != null)
                    {
                        jo_base = JObject.FromObject(mon_list[0], serializer);
                    }
                    JObject attack_obj = JObject.FromObject(attack, serializer);
                    attacks_array.Add(JODiff(jo_base, attack_obj));
                }
            }
            attacks_array.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            List<MonsterAttack> ret = new List<MonsterAttack> { };
            JArray main_array = JArray.Load(reader);
            foreach (JToken token in main_array)
            {
                if (token.Type == JTokenType.Array)
                {
                    JArray array = token.ToObject<JArray>();
                    ret.Add(new MonsterAttack
                    {
                        Id = (string)array[0],
                        Cooldown = (int)array[1]
                    });
                }
                else
                {
                    MonsterAttack test = token.ToObject<MonsterAttack>(serializer);
                    List<MonsterAttack> loaded_attack_list = Program.LoadedObjectDictionary.GetMAttacks(test.Id);
                    JObject token_object = token.ToObject<JObject>(serializer);
                    string type;
                    if (loaded_attack_list != null)
                    {
                        JObject base_object = JObject.FromObject(loaded_attack_list[0], serializer);
                        type = loaded_attack_list[0].Type == "monster_attack" ? loaded_attack_list[0].AttackType : loaded_attack_list[0].Type;
                        base_object.Merge(token_object,
                            new JsonMergeSettings
                            {
                                MergeArrayHandling = MergeArrayHandling.Replace
                            });
                        token_object = base_object;
                    }
                    else
                    {
                        type = test.Type == "monster_attack" ? test.AttackType : test.Type;
                    }
                    switch (type)
                    {
                        case "hardcoded":
                            ret.Add(token.ToObject<MonsterAttack>(serializer));
                            break;
                        case "leap":
                            ret.Add(token_object.ToObject<MonsterAttackLeap>(serializer));
                            break;
                        case "bite":
                            ret.Add(token_object.ToObject<MonsterAttackBite>(serializer));
                            break;
                        case "gun":
                            ret.Add(token_object.ToObject<MonsterAttackGun>(serializer));
                            break;
                        case "melee":
                            ret.Add(token_object.ToObject<MonsterAttackMelee>(serializer));
                            break;
                        case "spell":
                            ret.Add(token_object.ToObject<MonsterAttackSpell>(serializer));
                            break;
                        default: break;
                    }
                    
                }
            }
            if(ret.Count == 0)
            {
                return null;
            } else
            {
                return ret;
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
            JToken token = JToken.FromObject(instance.Values, serializer);
            token.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            DamageInstance instance = new DamageInstance { };
            if(token.Type == JTokenType.Array)
            {
                foreach(JObject jo in token.ToObject<List<JObject>>(serializer))
                {
                    DamageUnit du = (DamageUnit)jo.ToObject(typeof(DamageUnit), serializer);
                    instance.Add(du);
                }
            }
            else
            {
                return token.ToObject<T>(serializer);
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
    public class MAttackGunRangeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(GunRange));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<GunRange> ranges = value as List<GunRange>;
            JArray outer = new JArray { };
            foreach (GunRange range in ranges)
            {
                outer.Add(new JArray { range.Min, range.Max, range.Type });
            }
            outer.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                JArray outer = token.ToObject<JArray>();
                List<GunRange> ranges = new List<GunRange> { };
                foreach (JArray array in outer)
                {
                    ranges.Add(new GunRange
                    {
                        Min = (int)array[0],
                        Max = (int)array[1],
                        Type = (string)array[2]
                    });
                }
                return ranges;
            }
            else
            {
                return token.ToObject<GunRange>();
            }
        }
    }
    public class IdValueArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IdValueArray));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<IdValueArray> pairs = value as List<IdValueArray>;
            JArray outer = new JArray { };
            foreach (IdValueArray pair in pairs)
            {
                outer.Add(new JArray { pair.Id, pair.Value });
            }
            outer.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                JArray outer = token.ToObject<JArray>();
                List<IdValueArray> ret = new List<IdValueArray> { };
                foreach (JArray array in outer)
                {
                    ret.Add(new IdValueArray
                    {
                        Id = (string)array[0],
                        Value = (int)array[1]
                    });
                }
                return ret;
            }
            else
            {
                return token.ToObject<GunRange>();
            }
        }
    }
}
