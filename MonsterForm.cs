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

namespace cdda_item_creator
{
    public partial class MonsterForm : Form
    {
        Mtype main_monster = new Mtype { };
        public void loadColors()
        {
            string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\valid_color.json";
            string flag_file_text = File.ReadAllText(flag_path);
            JArray parray = JArray.Parse(flag_file_text);
            colorComboBox.Items.AddRange(parray.ToObject<string[]>());
        }
        public MonsterForm()
        {
            InitializeComponent();
            loadColors();
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
        private void UpdateMonsterDataGrid()
        {
            main_monster.UpdateVolume((int)volumeUpDown.Value, volumeListbox.Text);
            main_monster.UpdateWeight((int)weightUpDown.Value, weightComboBox.Text);

            main_monster.Material = ListDataUpdater(materialDataGrid);
            main_monster.Species = ListDataUpdater(speciesDataGrid);
            main_monster.Categories = ListDataUpdater(categoriesDataGrid);
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
                damageInstanceAmountUpDown.Value,
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
    }
}
