﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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
            string cdda_path;
            try
            {
                string cdda_path_file = System.Windows.Forms.Application.StartupPath + "\\cdda_data_path";
                cdda_path = File.ReadAllText(cdda_path_file);
            }
            catch
            {
                cddaFolderBrowserDialog.ShowDialog();
                cdda_path = cddaFolderBrowserDialog.SelectedPath;
            }
            currentPathLabel.Text = cdda_path;
            if (cdda_path == "")
            {
                return;
            }
            else
            {
                File.WriteAllText(Application.StartupPath + "\\cdda_data_path", cdda_path);
            }
            DirectoryInfo dir = new DirectoryInfo(cdda_path);
            JsonSerializer j_ser = new JsonSerializer
            {
                ContractResolver = new IgnoreEmptyEnumerablesResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
            foreach (FileInfo file in dir.GetFiles("*.json", SearchOption.AllDirectories))
            {
                string file_text = File.ReadAllText(file.FullName);
                try
                {
                    JArray ja = JArray.Parse(file_text);
                    List<JObject> temp_list = (List<JObject>)ja.ToObject(typeof(List<JObject>));
                    foreach (JObject obj in temp_list)
                    {
                        GenericTypedObject generic_object = (GenericTypedObject)obj.ToObject(typeof(GenericTypedObject), j_ser);
                        if (generic_object.valid())
                        {
                            Program.LoadedObjectDictionary.Add(generic_object.Type, generic_object.GetId());
                            switch (generic_object.Type)
                            {
                                case "MONSTER":
                                    Mtype temp = (Mtype)obj.ToObject(typeof(Mtype), j_ser);
                                    Program.LoadedObjectDictionary.Add(generic_object.Id, temp);
                                    break;
                                case "SPELL":
                                    Program.LoadedObjectDictionary.Add(generic_object.Id, (spell.spell_type)obj.ToObject(typeof(spell.spell_type), j_ser));
                                    break;
                                case "monster_attack":
                                    MonsterAttack loaded_attack = (MonsterAttack)obj.ToObject(typeof(MonsterAttack), j_ser);
                                    switch (loaded_attack.AttackType)
                                    {
                                        case "hardcoded":
                                            Program.LoadedObjectDictionary.Add(generic_object.Id, loaded_attack);
                                            break;
                                        case "leap":
                                            Program.LoadedObjectDictionary.Add(generic_object.Id, (MonsterAttackLeap)obj.ToObject(typeof(MonsterAttackLeap), j_ser));
                                            break;
                                        case "bite":
                                            Program.LoadedObjectDictionary.Add(generic_object.Id, (MonsterAttackBite)obj.ToObject(typeof(MonsterAttackBite), j_ser));
                                            break;
                                        case "melee":
                                            string melee = obj.ToString();
                                            Program.LoadedObjectDictionary.Add(generic_object.Id, (MonsterAttackMelee)obj.ToObject(typeof(MonsterAttackMelee), j_ser));
                                            break;
                                        case "spell":
                                            Program.LoadedObjectDictionary.Add(generic_object.Id, (MonsterAttackSpell)obj.ToObject(typeof(MonsterAttackSpell), j_ser));
                                            break;
                                        case "gun":
                                            Program.LoadedObjectDictionary.Add(generic_object.Id, (MonsterAttackGun)obj.ToObject(typeof(MonsterAttackGun), j_ser));
                                            break;
                                        default: break;
                                    }
                                    break;
                                case "material":
                                    Program.LoadedObjectDictionary.Add(generic_object.Ident, (MaterialType)obj.ToObject(typeof(MaterialType), j_ser));
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
            Hide();
            form.ShowDialog();
            Show();
        }

        private void createMonster_button_Click(object sender, EventArgs e)
        {
            MonsterForm form = new MonsterForm();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void viewLoadedItemsButton_Click(object sender, EventArgs e)
        {
            ViewerForm form = new ViewerForm();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void loadGameDialog_Click(object sender, EventArgs e)
        {
            string cdda_path;
            cddaFolderBrowserDialog.ShowDialog();
            cdda_path = cddaFolderBrowserDialog.SelectedPath;
            currentPathLabel.Text = cdda_path;
            if (cdda_path == "")
            {
                return;
            }
            else
            {
                File.WriteAllText(Application.StartupPath + "\\cdda_data_path", cdda_path);
            }
        }

        private void createMaterialButton_Click(object sender, EventArgs e)
        {
            MaterialForm form = new MaterialForm();
            Hide();
            form.ShowDialog();
            Show();
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
