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
        public void loadColors()
        {
            string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\valid_color.json";
            string flag_file_text = File.ReadAllText(flag_path);
            JArray parray = JArray.Parse(flag_file_text);
            colorComboBox.Items.AddRange(parray.ToObject<string[]>());
        }
        public void loadFlags()
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
        public MonsterForm()
        {


            InitializeComponent();
            loadColors();
            loadFlags();

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
    }
}
