using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cdda_item_creator
{
    public partial class SelectorForm : Form
    {
        private void TryLoadObjectLists()
        {
            cddaFolderBrowserDialog.ShowDialog();
            if(cddaFolderBrowserDialog.SelectedPath == "")
            {
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(cddaFolderBrowserDialog.SelectedPath);
            foreach (FileInfo file in dir.GetFiles("*.json", SearchOption.AllDirectories))
            {
                string file_text = File.ReadAllText(file.FullName);
                try
                {
                    JArray ja = JArray.Parse(file_text);
                    List<JObject> temp_list = (List<JObject>)ja.ToObject(typeof(List<JObject>));
                    foreach (JObject obj in temp_list)
                    {
                        GenericTypedObject generic_object = (GenericTypedObject)obj.ToObject(typeof(GenericTypedObject));
                        if (generic_object.valid())
                        {
                            Program.LoadedObjectDictionary.Add(generic_object.Type, generic_object.GetId());
                            switch (generic_object.Type)
                            {
                                case "MONSTER":
                                    Program.LoadedObjectDictionary.Add(generic_object.Id, (Mtype)obj.ToObject(typeof(Mtype)));
                                    break;
                                case "SPELL":
                                    Program.LoadedObjectDictionary.Add(generic_object.Id, (spell.spell_type)obj.ToObject(typeof(spell.spell_type)));
                                    break;
                                default: break;
                            }
                        }
                    }
                } catch(Newtonsoft.Json.JsonReaderException)
                {

                } catch(System.ArgumentException)
                {

                }
            }
        }
        public SelectorForm()
        {
            InitializeComponent();
            TryLoadObjectLists();
        }

        private void spellButton_Click(object sender, EventArgs e)
        {
            spell_form form = new spell_form();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void createMonster_button_Click(object sender, EventArgs e)
        {
            MonsterForm form = new MonsterForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void viewLoadedItemsButton_Click(object sender, EventArgs e)
        {
            ViewerForm form = new ViewerForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
    public class GenericTypedObject
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Ident { get; set; }
        public string GetId()
        {
            if(Id != null)
            {
                return Id;
            } else
            {
                // this could also get null. check validity first.
                return Ident;
            }
        }
        public bool valid()
        {
            return Type != null && (Id != null || Ident != null);
        }
    }
}
