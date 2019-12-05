using Newtonsoft.Json;
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
using static System.Windows.Forms.CheckedListBox;

namespace cdda_item_creator
{
    public partial class MonsterForm : Form
    {
        Mtype main_monster = new Mtype { };
        Dictionary<string, string> monster_flags;
        private void loadColors()
        {
            string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\valid_color.json";
            string flag_file_text = File.ReadAllText(flag_path);
            JArray parray = JArray.Parse(flag_file_text);
            colorComboBox.Items.AddRange(parray.ToObject<string[]>());
        }
        private void loadFlags()
        {
            string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\monster_flags.json";
            string flag_file_text = File.ReadAllText(flag_path);
            JObject o1 = JObject.Parse(flag_file_text);
            monster_flags = o1.ToObject<Dictionary<string, string>>();
            foreach( string key in monster_flags.Keys)
            {
                flagsListBox.Items.Add(key);
            }
        }
        private void loadHarvest()
        {
            HashSet<string> harvest = Program.LoadedObjectDictionary.GetList("harvest");
            if(harvest == null)
            {
                return;
            }
            foreach(string harvest_entry in harvest)
            {
                harvestTextBox.Items.Add(harvest_entry);
            }
        }
        private void loadSpecies()
        {
            HashSet<string> species = Program.LoadedObjectDictionary.GetList("SPECIES");
            if (species == null)
            {
                return;
            }
            foreach (string species_entry in species)
            {
                SpeciesComboBox.Items.Add(species_entry);
            }
        }
        private void loadMaterial()
        {
            HashSet<string> material = Program.LoadedObjectDictionary.GetList("material");
            if (material == null)
            {
                return;
            }
            foreach (string material_entry in material)
            {
                MaterialComboBox.Items.Add(material_entry);
            }
        }
        private void loadMonsterLists()
        {
            HashSet<string> monster = Program.LoadedObjectDictionary.GetList("MONSTER");
            if (monster == null)
            {
                return;
            }
            foreach (string monster_entry in monster)
            {
                looksLikeTextBox.Items.Add(monster_entry);
                copyFromComboBox.Items.Add(monster_entry);
            }
        }
        private void loadFaction()
        {
            HashSet<string> faction = Program.LoadedObjectDictionary.GetList("faction");
            if(faction == null)
            {
                return;
            }
            foreach(string faction_entry in faction)
            {
                defaultFactionTextBox.Items.Add(faction);
            }
        }
        private void UpdateSpecialAttackDataGrid()
        {
            specialAttacksDataGrid.Rows.Clear();
            if(main_monster.SpecialAttacks == null)
            {
                return;
            }
            foreach(MonsterAttack mattack in main_monster.SpecialAttacks)
            {
                specialAttacksDataGrid.Rows.Add(
                    mattack.Id,
                    mattack.Type,
                    mattack.Cooldown
                    );
            }
        }
        // updates the lists on the form to the data from the Mtype object
        private void UpdateFormListInternal()
        {
            UpdateSpecialAttackDataGrid();
            List<int> indices = new List<int> { };
            foreach(string checked_item in flagsListBox.CheckedItems)
            {
                indices.Add(flagsListBox.Items.IndexOf(checked_item));
            }
            foreach(int idx in indices)
            {
                flagsListBox.SetItemChecked(idx, false);
            }
            if (main_monster.Flags != null)
            {
                foreach (string flag in main_monster.Flags)
                {
                    int idx = flagsListBox.Items.IndexOf(flag);
                    if (idx == -1)
                    {
                        continue;
                    }
                    flagsListBox.SetItemChecked(idx, true);
                }
            }

            damageInstanceDataGrid.Rows.Clear();
            if (main_monster.MeleeDamage != null)
            {
                foreach (DamageUnit du in main_monster.MeleeDamage.Values)
                {
                    damageInstanceDataGrid.Rows.Add(du.Type, du.Amount, du.ArmorPenetration, du.ArmorMultiplier, du.DamageMultiplier);
                }
            }

            materialDataGrid.Rows.Clear();
            if(main_monster.Material != null)
            {
                foreach(string mat in main_monster.Material)
                {
                    materialDataGrid.Rows.Add(mat);
                }
            }

            speciesDataGrid.Rows.Clear();
            if(main_monster.Species != null)
            {
                foreach(string spec in main_monster.Species)
                {
                    speciesDataGrid.Rows.Add(spec);
                }
            }

            categoriesDataGrid.Rows.Clear();
            if(main_monster.Categories != null)
            {
                foreach(string cat in main_monster.Categories)
                {
                    categoriesDataGrid.Rows.Add(cat);
                }
            }

            if(main_monster.Volume != null && main_monster.Volume != "")
            {
                string[] split = main_monster.Volume.Split(' ');
                int vol = 1;
                int.TryParse(split[0], out vol);
                volumeUpDown.Value = vol;
                string it = "ml";
                if(split[1] == "L")
                {
                    it = "L";
                }
                volumeListbox.SelectedItem = it;
            } else
            {
                volumeUpDown.Value = 1;
            }

            if(main_monster.Weight != null && main_monster.Weight != "")
            {
                string[] split = main_monster.Weight.Split(' ');
                int weight = 1;
                int.TryParse(split[0], out weight);
                weightUpDown.Value = weight;
                weightComboBox.SelectedItem = split[1];
            } else
            {
                weightUpDown.Value = 1;
            }
        }
        public void UpdateSymbolPreviewColor()
        {
            string raw_color_string = colorComboBox.Text;
            if(raw_color_string == "")
            {
                return;
            }
            string[] color_split = raw_color_string.Split('_');
            string text_color = "";
            string back_color = "";
            if(color_split.Length == 3)
            {
                back_color = char.ToUpper(color_split[2][0]) + color_split[2].Substring(1);
                text_color = char.ToUpper(color_split[0][0]) + color_split[0].Substring(1) + char.ToUpper(color_split[1][0]) + color_split[1].Substring(1);
            } else 
            {
                text_color = char.ToUpper(color_split[0][0]) + color_split[0].Substring(1);
            }
            if (color_split.Length == 2)
            {
                if (color_split[0] != "light" && color_split[0] != "dark")
                {
                    back_color = char.ToUpper(color_split[1][0]) + color_split[1].Substring(1);
                } else
                {
                    text_color = char.ToUpper(color_split[0][0]) + color_split[0].Substring(1) + char.ToUpper(color_split[1][0]) + color_split[1].Substring(1);
                }
            }
            if(text_color == "LightRed")
            {
                text_color = "Pink";
            }
            if(back_color == "LightRed")
            {
                back_color = "Pink";
            }
            symbolPreviewLabel.BackColor = Color.FromName(back_color);
            symbolPreviewLabel.ForeColor = Color.FromName(text_color);
        }
        public MonsterForm()
        {
            InitializeComponent();
            loadColors();
            loadFlags();
            loadHarvest();
            loadSpecies();
            loadMaterial();
            loadMonsterLists();
            loadFaction();

            MaterialComboBox.DataSource = main_monster.Material;
            SpeciesComboBox.DataSource = main_monster.Species;

            mtypeBindingSource.Add(main_monster);
            monsterNameStringsBindingSource.Add(main_monster.Name);
            pathSettingsDataBindingSource.Add(main_monster.PathSettings);
            volumeListbox.SelectedIndex = 0;
            weightComboBox.SelectedIndex = 1;
            colorComboBox.SelectedIndex = 0;
            damageInstanceTypeComboBox.SelectedIndex = 0;
        }
        private List<string> ListDataUpdater( DataGridView info )
        {
            List<string> ret = null;
            if( info.Rows.Count > 0)
            {
                ret = new List<string> { };
            }
            foreach(DataGridViewRow row in info.Rows)
            {
                string text = (string)row.Cells[0].Value;
                if( text != null)
                {
                    ret.Add(text);
                }
            }
            return ret;
        }
        private List<string> ListDataUpdater(CheckedListBox info)
        {
            List<string> ret = null;
            if (info.CheckedItems.Count > 0)
            {
                ret = new List<string> { };
            }
            foreach (string checked_item in info.CheckedItems)
            {
                if (checked_item != null)
                {
                    ret.Add(checked_item);
                }
            }
            return ret;
        }
        private void UpdateDamageInstanceData()
        {
            main_monster.MeleeDamage = null;
            if(damageInstanceDataGrid.Rows.Count > 0)
            {
                main_monster.MeleeDamage = new DamageInstance { };
            }
            foreach(DataGridViewRow row in damageInstanceDataGrid.Rows)
            {
                string type = row.Cells["Type"].Value.ToString();
                int amount;
                int.TryParse(row.Cells["Amount"].Value.ToString(), out amount);
                int armor_penetration;
                int.TryParse(row.Cells["ArmorPenetration"].Value.ToString(), out armor_penetration);
                float armor_multiplier;
                float.TryParse(row.Cells["ArmorMultiplier"].Value.ToString(), out armor_multiplier);
                float damage_multiplier;
                float.TryParse(row.Cells["DamageMultiplier"].Value.ToString(), out damage_multiplier);
                DamageUnit du = 
                    new DamageUnit
                    {
                        Type = type,
                        Amount = amount,
                        ArmorPenetration = armor_penetration,
                        ArmorMultiplier = armor_multiplier,
                        DamageMultiplier = damage_multiplier
                    };
                main_monster.MeleeDamage.Add(du);
            }
        }
        private void UpdateMonsterDataGrid()
        {
            main_monster.UpdateVolume((int)volumeUpDown.Value, volumeListbox.Text);
            main_monster.UpdateWeight((int)weightUpDown.Value, weightComboBox.Text);

            UpdateDamageInstanceData();

            main_monster.Material = ListDataUpdater(materialDataGrid);
            main_monster.Species = ListDataUpdater(speciesDataGrid);
            main_monster.Categories = ListDataUpdater(categoriesDataGrid);

            main_monster.Flags = ListDataUpdater(flagsListBox);
        }

        private void clipboardButton_Click(object sender, EventArgs e)
        {
            UpdateMonsterDataGrid();

            IgnoreEmptyEnumerablesResolver contractResolver = new IgnoreEmptyEnumerablesResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            Clipboard.SetText(JsonConvert.SerializeObject(
                main_monster,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    ContractResolver = contractResolver
                }
                ));
        }

        private void damageInstanceAddButton_Click(object sender, EventArgs e)
        {
            damageInstanceDataGrid.Rows.Add(
                damageInstanceTypeComboBox.Text,
                damageInstanceAmountUpDown.Value.ToString(),
                damageInstanceArmorPenetrationUpDown.Value,
                damageInstanceArmorMultiplierUpDown.Value,
                damageInstanceDamageMultiplierUpDown.Value
                );
        }

        private void difficultyLabel_Click(object sender, EventArgs e)
        {
            UpdateMonsterDataGrid();
            difficultyLabel.Text = "Calculated Difficulty (click to update): " + main_monster.Difficulty().ToString();
        }
        private void UpdateMeleeDamageRange()
        {
            int min_damage = main_monster.MeleeDice;
            int max_damage = min_damage * main_monster.MeleeDiceSides;
            min_damage += main_monster.MeleeCut;
            max_damage += main_monster.MeleeCut;
            meleeDamageRangeLabel.Text = min_damage.ToString() + " - " + max_damage.ToString();
            meleeDamageRangeLabel.Refresh();
        }
        private void meleeDiceUpdown_ValueChanged(object sender, EventArgs e)
        {
            UpdateMeleeDamageRange();
        }

        private void meleeDiceSidesUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateMeleeDamageRange();
        }

        private void bonusCutUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateMeleeDamageRange();
        }

        private void meleeDamageRangeLabel_Click(object sender, EventArgs e)
        {
            UpdateMeleeDamageRange();
        }

        private void flagsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            flagDescriptionLabel.Text = monster_flags[flagsListBox.SelectedItem.ToString()];
        }

        private void symbolTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSymbolPreviewColor();
        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSymbolPreviewColor();
        }
        private void UpdateMainMonsterBindings()
        {
            mtypeBindingSource.Clear();
            mtypeBindingSource.Add(main_monster);
            mtypeBindingSource.ResetBindings(false);

            pathSettingsDataBindingSource.Clear();
            pathSettingsDataBindingSource.Add(main_monster.PathSettings);
            pathSettingsDataBindingSource.ResetBindings(false);

            if (main_monster.NamePlural != null)
            {
                main_monster.Name.StrPl = main_monster.NamePlural;
            }
            monsterNameStringsBindingSource.Clear();
            monsterNameStringsBindingSource.Add(main_monster.Name);
            monsterNameStringsBindingSource.ResetBindings(false);

            UpdateFormListInternal();
        }
        private void copyFromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( copyFromComboBox.SelectedIndex == -1)
            {
                return;
            }
            // TODO: selector for items, and show what mod they're from
            main_monster = Program.LoadedObjectDictionary.GetMtypes(copyFromComboBox.Text)[0].DeepCopy();
            UpdateMainMonsterBindings();
        }

        private void clearCopyFromButton_Click(object sender, EventArgs e)
        {
            copyFromComboBox.SelectedIndex = -1;
        }
    }
}
