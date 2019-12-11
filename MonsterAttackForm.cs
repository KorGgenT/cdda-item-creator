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
    public partial class MonsterAttackForm : Form
    {
        Dictionary<string, string> hardcoded_attacks;
        MonsterAttack mattack;
        private void LoadHardcodedAttacks()
        {
            string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\hardcoded_mattack.json";
            string flag_file_text = File.ReadAllText(flag_path);
            JObject jobj = JObject.Parse(flag_file_text);
            hardcoded_attacks = jobj.ToObject<Dictionary<string, string>>();
        }
        private void BuildMonsterAttack()
        {
            switch(mattackTypeCombobox.Text)
            {
                default: 
                    mattack = null;
                    break;
            }
        }
        private void LoadBodyParts()
        {
            string flag_path = System.Windows.Forms.Application.StartupPath + "\\json\\body_parts.json";
            string flag_file_text = File.ReadAllText(flag_path);
            string[] array = JArray.Parse(flag_file_text).ToObject<string[]>();
            bodyPartComboBox.Items.AddRange(array);
            monEffectDataBodyPartComboBox.Items.AddRange(array);
        }
        public MonsterAttackForm()
        {
            InitializeComponent();
            LoadHardcodedAttacks();
            LoadBodyParts();
            monEffectDataIdComboBox.Items.AddRange(Program.LoadedObjectDictionary.GetList("effect_type").ToArray());
            gunTypeComboBox.Items.AddRange(Program.LoadedObjectDictionary.GetList("GUN").ToArray());
            ammoTypeComboBox.Items.AddRange(Program.LoadedObjectDictionary.GetList("AMMO").ToArray());
            mattackTypeCombobox.SelectedIndex = 0;
            idComboBox.SelectedIndex = 0;
            foreach (string spell_id in Program.LoadedObjectDictionary.GetList("SPELL"))
            {
                spellIdComboBox.Items.Add(spell_id);
            }
            spellIdComboBox.SelectedIndex = 0;
        }

        private void mattackTypeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            idComboBox.Enabled = true;
            idComboBox.SelectedIndex = -1;
            idComboBox.Items.Clear();
            idComboBox.Show();
            idComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            idLabel.Show();
            spellPanel.Hide();
            leapPanel.Hide();
            meleePanel.Hide();
            gunPanel.Hide();
            switch(mattackTypeCombobox.Text)
            {
                case "gun":
                    {
                        gunPanel.Show();
                        break;
                    }
                case "melee":
                    {
                        biteNoInfectionChanceLabel.Hide();
                        biteNoInfectionChanceUpDown.Hide();
                        meleePanel.Show();
                        break;
                    }
                case "bite":
                    {
                        biteNoInfectionChanceLabel.Show();
                        biteNoInfectionChanceUpDown.Show();
                        meleePanel.Show();
                        break;
                    }
                case "hardcoded":
                    {
                        foreach(string key in hardcoded_attacks.Keys)
                        {
                            idComboBox.Items.Add(key);
                            idComboBox.SelectedIndex = 0;
                            idComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        }
                        break;
                    }
                case "leap":
                    {
                        leapPanel.Show();
                        break;
                    }
                case "spell":
                    {
                        idComboBox.Enabled = false;
                        idComboBox.Hide();
                        idLabel.Hide();
                        spellPanel.Show();
                        break;
                    }
                default: break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mattack = null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            BuildMonsterAttack();
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

        private void meleeBodyPartAddButton_Click(object sender, EventArgs e)
        {
            bodyPartsDataGrid.Rows.Add(
                bodyPartComboBox.Text,
                bodyPartHitRateUpDown.Value
                );
        }

        private void moneEffectDataAddButton_Click(object sender, EventArgs e)
        {
            meleeMonEffectDataGrid.Rows.Add(
                monEffectDataIdComboBox.Text,
                monEffectDataDurationUpDown.Value,
                monEffectDataAffectHitBpCheckBox.Checked,
                monEffectDataBodyPartComboBox.Text,
                monEffectDataPermanentCheckbox.Checked,
                monEffectDataChanceUpDown.Value
                );
        }
    }
}
