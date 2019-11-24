using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cdda_item_creator.spell;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace cdda_item_creator
{
    public partial class spell_form : Form
    {
        public spell.spell_type main_spell = new spell.spell_type();

        void update_effect_str( string effect )
        {
            effect_str_combobox.Items.Clear();
            effect_str_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            if (effect == "recover_energy")
            {
                effect_str_combobox.Items.AddRange(spell.allowed_strings.recover_energy_types);
                effect_str_combobox.SelectedIndex = 0;
                effect_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            } else if( effect == "timed_event" )
            {
                effect_str_combobox.Items.AddRange(spell.allowed_strings.timed_event);
                effect_str_combobox.SelectedIndex = 0;
                effect_str_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            } else if( effect == "pain_split" || effect == "teleport_random" || effect == "vomit" || effect == "explosion" ||
                effect == "flashbang" || effect == "mod_moves" || effect == "map" || effect == "bash" || effect == "charm_monster" )
            {
                effect_str_combobox.SelectedIndex = -1;
                effect_str_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }

        public spell_form()
        {
            StaticDataLoader loader = new StaticDataLoader { };
            loader.loadAll();
            InitializeComponent();
            InitializeLists();
            spelltypeBindingSource.Add(main_spell);
            energy_type_combobox.SelectedIndex = 0;
            effect_combobox.SelectedIndex = 0;
            damage_type_combobox.SelectedIndex = 0;
            sound_type_combobox.SelectedIndex = 0;
        }

        private void clipboard_button_Click(object sender, EventArgs e)
        {
            main_spell.Flags = flags_listbox.CheckedItems.Cast<string>().ToList();
            main_spell.ValidTargets = valid_targets_listbox.CheckedItems.Cast<string>().ToList();
            main_spell.AffectedBps = effected_body_part_listbox.CheckedItems.Cast<string>().ToList();
            main_spell.EffectTargets = effect_filter_listbox.CheckedItems.Cast<string>().ToList();

            main_spell.ExtraEffects = null;
            if(additionalSpellGrid.Rows.Count > 0)
            {
                main_spell.ExtraEffects = new List<FakeSpell> { };
            }
            foreach(DataGridViewRow row in additionalSpellGrid.Rows)
            {
                FakeSpell spell = new FakeSpell
                {
                    Id = (string)row.Cells[0].Value,
                    MaxLevel = (int)row.Cells[1].Value,
                    Self = (bool)row.Cells[2].Value
                };
                main_spell.ExtraEffects.Add(spell);
            }

            main_spell.LearnSpells = null;
            if (spellsLearnedGrid.Rows.Count > 0)
            {
                main_spell.LearnSpells = new Dictionary<string, int> { };
            }
            foreach (DataGridViewRow row in spellsLearnedGrid.Rows)
            {
                main_spell.LearnSpells.Add((string)row.Cells[0].Value, (int)row.Cells[1].Value);
            }


            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            Clipboard.SetText(JsonConvert.SerializeObject(
                main_spell,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    ContractResolver = contractResolver
                }
                )); ;
        }

        private void effect_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string effect = effect_combobox.SelectedItem.ToString();
            if (!spell.allowed_strings.effect_descriptions.ContainsKey(effect))
            {
                return;
            }
            spell_effect_description_label.Text = spell.allowed_strings.effect_descriptions[effect];
            update_effect_str(effect);
        }

        private void fakeSpellAddButton_Click(object sender, EventArgs e)
        {
            string fake_spell_id = FakeSpellIdTextbox.Text;
            if(fake_spell_id.Length == 0)
            {
                // empty spell string is invalid
                return;
            }
            int fake_spell_max_level = (int)fakeSpellUpDown.Value;
            bool fake_spell_self = fakeSpellSelfCheckbox.Checked;
            additionalSpellGrid.Rows.Add(fake_spell_id, fake_spell_max_level, fake_spell_self);
        }

        private void spellsLearnedAddButton_Click(object sender, EventArgs e)
        {
            string spell_id = spellsLearnedTextbox.Text;
            if(spell_id.Length == 0)
            {
                return;
            }
            int spell_level = (int)SpellsLearnedUpDown.Value;
            spellsLearnedGrid.Rows.Add(spell_id, spell_level);
        }

        private void flags_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string flag = flags_listbox.SelectedItem.ToString();
            if(!spell.allowed_strings.spell_flags_description.ContainsKey(flag))
            {
                return;
            }
            flag_description_labe.Text = spell.allowed_strings.spell_flags_description[flag];
        }
    }
}
