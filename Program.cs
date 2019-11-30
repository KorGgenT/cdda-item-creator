using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cdda_item_creator
{
    static class Program
    {
        // the container for the lists of CDDA objects by type
        public static class LoadedObjectDictionary
        {
            static Dictionary<string, List<string>> ids_by_type = new Dictionary<string, List<string>> { };

            static public void Add(string type, string id)
            {
                List<string> temp_list;
                if(ids_by_type.TryGetValue(type, out temp_list))
                {
                    temp_list.Add(id);
                    ids_by_type[type] = temp_list;
                } else
                {
                    temp_list = new List<string> { id };
                    ids_by_type.Add(type, temp_list);
                }
            }
            static public Dictionary<string, List<string>>.KeyCollection Keys()
            {
                return ids_by_type.Keys;
            }
            static public List<string> GetList(string key)
            {
                List<string> ret;
                ids_by_type.TryGetValue(key, out ret);
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
