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
        private void EnableAllFields()
        {
            min_damage_updown.Enabled = true;
            damage_increment_updown.Enabled = true;
            max_damage_updown.Enabled = true;
            min_range_updown.Enabled = true;
            range_increment_updown.Enabled = true;
            max_range_updown.Enabled = true;
            min_aoe_updown.Enabled = true;
            aoe_increment_updown.Enabled = true;
            max_aoe_updown.Enabled = true;
            min_duration_updown.Enabled = true;
            duration_increment_updown.Enabled = true;
            max_duration_updown.Enabled = true;
            min_field_intensity_updown.Enabled = true;
            field_intensity_increment_updown.Enabled = true;
            max_field_intensity_updown.Enabled = true;
            field_id_textbox.Enabled = true;
            field_chance_updown.Enabled = true;
            field_intensity_variance_updown.Enabled = true;
            effect_filter_listbox.Enabled = true;
            effected_body_part_listbox.Enabled = true;
            valid_targets_listbox.Enabled = true;
            effect_str_combobox.Enabled = true;
            damage_type_combobox.Enabled = true;
            // "none" is not desirable for most spells
            // and it is also partially hidden down the list
            valid_targets_listbox
                    .SetItemCheckState(4, CheckState.Unchecked);
        }
        private void ResetDisabledFieldValues()
        {
            List<NumericUpDown> disablable_fields = new List<NumericUpDown>{
                min_damage_updown,
                damage_increment_updown,
                max_damage_updown,
                min_range_updown,
                range_increment_updown,
                max_range_updown,
                min_aoe_updown,
                aoe_increment_updown,
                max_aoe_updown,
                min_duration_updown,
                duration_increment_updown,
                max_duration_updown,
                min_field_intensity_updown,
                field_intensity_increment_updown,
                max_field_intensity_updown,
                field_intensity_variance_updown
            };
            foreach(NumericUpDown box in disablable_fields)
            {
                if (!box.Enabled)
                {
                    box.Value = 0;
                }
            }
            if (!field_id_textbox.Enabled)
            {
                field_id_textbox.Text = "";
            }
            if(!field_chance_updown.Enabled)
            {
                field_chance_updown.Value = 1;
            }
            if (!damage_type_combobox.Enabled)
            {
                damage_type_combobox.SelectedItem = "NONE";
            }
            if (!effected_body_part_listbox.Enabled)
            {
                foreach (int i in effected_body_part_listbox.CheckedIndices)
                {
                    effected_body_part_listbox
                        .SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            if (!valid_targets_listbox.Enabled)
            {
                foreach (int i in effected_body_part_listbox.CheckedIndices)
                {
                    valid_targets_listbox
                        .SetItemCheckState(i, CheckState.Unchecked);
                }
                // sets to "none"
                valid_targets_listbox
                    .SetItemCheckState(4, CheckState.Checked);
            }
            if (!effect_filter_listbox.Enabled)
            {
                foreach (int i in effect_filter_listbox.CheckedIndices)
                {
                    effect_filter_listbox
                        .SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }
        private void DisableDamage()
        {
            min_damage_updown.Enabled = false;
            damage_increment_updown.Enabled = false;
            max_damage_updown.Enabled = false;
            damage_type_combobox.Enabled = false;
        }
        private void DisableRange()
        {
            min_range_updown.Enabled = false;
            range_increment_updown.Enabled = false;
            max_range_updown.Enabled = false;
        }
        private void DisableAoe()
        {
            min_aoe_updown.Enabled = false;
            aoe_increment_updown.Enabled = false;
            max_aoe_updown.Enabled = false;
        }
        private void DisableDuration()
        {
            min_duration_updown.Enabled = false;
            duration_increment_updown.Enabled = false;
            max_duration_updown.Enabled = false;
        }
        private void DisableFields()
        {
            min_field_intensity_updown.Enabled = false;
            field_intensity_increment_updown.Enabled = false;
            max_field_intensity_updown.Enabled = false;
            field_id_textbox.Enabled = false;
            field_chance_updown.Enabled = false;
            field_intensity_variance_updown.Enabled = false;
        }
        private void EnableValidEffectValues()
        {
            string effect = effect_combobox.Text;
            EnableAllFields();
            switch (effect)
            {
                case "pain_split":
                    DisableDamage();
                    DisableRange();
                    DisableAoe();
                    DisableDuration();
                    DisableFields();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    valid_targets_listbox.Enabled = false;
                    effect_str_combobox.Enabled = false;
                    break;
                case "target_attack":
                case "projectile_attack":
                case "cone_attack":
                case "line_attack":
                    effect_filter_listbox.Enabled = false;
                    break;
                case "teleport_random":
                    DisableDamage();
                    DisableFields();
                    DisableDuration();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    valid_targets_listbox.Enabled = false;
                    effect_str_combobox.Enabled = false;
                    break;
                case "spawn_item":
                    DisableFields();
                    DisableRange();
                    DisableAoe();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    valid_targets_listbox.Enabled = false;
                    break;
                case "recover_energy":
                    DisableFields();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "summon":
                    DisableFields();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "translocate":
                    DisableDamage();
                    DisableDuration();
                    DisableFields();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    effect_str_combobox.Enabled = false;
                    break;
                case "area_pull":
                case "area_push":
                    DisableFields();
                    DisableDuration();
                    damage_type_combobox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    effect_str_combobox.Enabled = false;
                    break;
                case "timed_event":
                    DisableDamage();
                    DisableRange();
                    DisableAoe();
                    DisableFields();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    valid_targets_listbox.Enabled = false;
                    break;
                case "ter_transform":
                    DisableFields();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "noise":
                    DisableFields();
                    DisableAoe();
                    DisableDuration();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "vomit":
                    DisableFields();
                    DisableDamage();
                    DisableDuration();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "explosion":
                    DisableFields();
                    DisableDuration();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "flashbang":
                    DisableFields();
                    DisableDuration();
                    DisableDamage();
                    DisableAoe();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "mod_moves":
                    DisableFields();
                    DisableDuration();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "map":
                    DisableFields();
                    DisableDuration();
                    DisableDamage();
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "morale":
                    DisableFields();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "charm_monster":
                    DisableFields();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "mutate":
                    DisableFields();
                    DisableDuration();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "bash":
                    DisableFields();
                    DisableDuration();
                    damage_type_combobox.Enabled = false;
                    effect_filter_listbox.Enabled = false;
                    effected_body_part_listbox.Enabled = false;
                    break;
                case "none":
                default:
                    break;
            }
            ResetDisabledFieldValues();
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

            if (spellsLearnedGrid.Rows.Count > 0)
            {
                main_spell.LearnSpells = new Dictionary<string, int> { };
            }
            foreach (DataGridViewRow row in spellsLearnedGrid.Rows)
            {
                main_spell.LearnSpells.Add((string)row.Cells[0].Value, (int)row.Cells[1].Value);
            }


            IgnoreEmptyEnumerablesResolver contractResolver = new IgnoreEmptyEnumerablesResolver
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
            EnableValidEffectValues();
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
