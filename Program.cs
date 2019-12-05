using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cdda_item_creator
{
    public static class ObjectExtensions
    {
        public static T DeepCopy<T>(this T original)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(original));
        }
    }
    static class Program
    {
        // the container for the lists of CDDA objects by type
        public static class LoadedObjectDictionary
        {
            static Dictionary<string, HashSet<string>> ids_by_type = new Dictionary<string, HashSet<string>> { };
            static Dictionary<string, List<Mtype>> mtypes_by_id = new Dictionary<string, List<Mtype>> { };
            static Dictionary<string, List<spell.spell_type>> spells_by_id = new Dictionary<string, List<spell.spell_type>> { };
            static Dictionary<string, List<MonsterAttack>> mattacks_by_id = new Dictionary<string, List<MonsterAttack>> { };

            static public void Add(string type, string id)
            {
                HashSet<string> temp_list;
                if(ids_by_type.TryGetValue(type, out temp_list))
                {
                    temp_list.Add(id);
                    ids_by_type[type] = temp_list;
                } else
                {
                    temp_list = new HashSet<string> { id };
                    ids_by_type.Add(type, temp_list);
                }
            }
            static public void Add(string id, MonsterAttack mattack)
            {
                List<MonsterAttack> temp_attack;
                if (mattacks_by_id.TryGetValue(id, out temp_attack))
                {
                    temp_attack.Add(mattack);
                    mattacks_by_id[id] = temp_attack;
                } else
                {
                    temp_attack = new List<MonsterAttack> { mattack };
                    mattacks_by_id.Add(id, temp_attack);
                }
            }
            static public void Add(string id, Mtype mon)
            {
                List<Mtype> temp_list;
                if(mtypes_by_id.TryGetValue(id, out temp_list))
                {
                    temp_list.Add(mon);
                    mtypes_by_id[id] = temp_list;
                } else
                {
                    temp_list = new List<Mtype> { mon };
                    mtypes_by_id.Add(id, temp_list);
                }
            }
            static public void Add(string id, spell.spell_type spell)
            {
                List<spell.spell_type> temp_list;
                if (spells_by_id.TryGetValue(id, out temp_list))
                {
                    temp_list.Add(spell);
                    spells_by_id[id] = temp_list;
                }
                else
                {
                    temp_list = new List<spell.spell_type> { spell };
                    spells_by_id.Add(id, temp_list);
                }
            }
            static public Dictionary<string, HashSet<string>>.KeyCollection Keys()
            {
                return ids_by_type.Keys;
            }
            static public HashSet<string> GetList(string key)
            {
                HashSet<string> ret;
                ids_by_type.TryGetValue(key, out ret);
                return ret;
            }
            static public List<Mtype> GetMtypes(string id)
            {
                List<Mtype> ret;
                mtypes_by_id.TryGetValue(id, out ret);
                return ret;
            }
            static public List<MonsterAttack> GetMAttacks(string id)
            {
                List<MonsterAttack> ret;
                mattacks_by_id.TryGetValue(id, out ret);
                return ret;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectorForm());
        }
    }
}
