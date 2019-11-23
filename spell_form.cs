using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            InitializeComponent();
            energy_type_combobox.SelectedIndex = 0;
            effect_combobox.SelectedIndex = 21;
            damage_type_combobox.SelectedIndex = 8;
            sound_type_combobox.SelectedIndex = 10;
        }

        private void spell_name_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.name = spell_name_textbox.Text;
        }

        private void energy_type_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main_spell.energy_source 
                = spell.allowed_strings.energy_types[energy_type_combobox.SelectedIndex];
        }

        private void id_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.id = id_textbox.Text;
        }

        private void clipboard_button_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(JsonConvert.SerializeObject(
                main_spell, 
                Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }
                ));

            main_spell.spell_tags.Clear();

            foreach (string item in flags_listbox.CheckedItems)
            {
                main_spell.spell_tags.Add(item);
            }

            main_spell.valid_targets.Clear();

            foreach (string item in valid_targets_listbox.CheckedItems)
            {
                main_spell.valid_targets.Add(item);
            }
        }

        private void spell_description_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.description = spell_description_textbox.Text;
        }

        private void effect_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string effect = spell.allowed_strings.effects[effect_combobox.SelectedIndex];
            main_spell.effect = effect;
            spell_effect_description_label.Text = spell.allowed_strings.effect_descriptions[effect];
            update_effect_str(effect);
        }

        private void flags_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag_description_labe.Text = spell.allowed_strings.spell_flags_description[(string)flags_listbox.SelectedItem];
            main_spell.spell_tags.Clear();
            
            foreach (string item in flags_listbox.CheckedItems)
            {
                main_spell.spell_tags.Add(item);
            }
        }

        private void min_damage_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.min_damage = (int)min_damage_updown.Value;
        }

        private void damage_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.damage_increment = (float)damage_increment_updown.Value;
        }

        private void max_damage_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.max_damage = (int)max_damage_updown.Value;
        }

        private void min_range_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.min_range = (int)min_damage_updown.Value;
        }

        private void range_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.range_increment = (float)range_increment_updown.Value;
        }

        private void max_range_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.max_range = (int)max_range_updown.Value;
        }

        private void min_aoe_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.min_aoe = (int)min_aoe_updown.Value;
        }

        private void aoe_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.aoe_increment = (float)aoe_increment_updown.Value;
        }

        private void max_aoe_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.max_aoe = (int)max_aoe_updown.Value;
        }

        private void effect_str_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main_spell.effect_str = effect_str_combobox.Text;
        }

        private void max_level_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.max_level = (int)max_level_updown.Value;
        }

        private void difficulty_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.difficulty = (int)difficulty_updown.Value;
        }

        private void damage_type_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main_spell.damage_type = damage_type_combobox.Text;
        }

        private void valid_targets_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main_spell.valid_targets.Clear();

            foreach (string item in valid_targets_listbox.CheckedItems)
            {
                main_spell.valid_targets.Add(item);
            }
        }

        private void effected_body_part_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main_spell.affected_bps.Clear();

            foreach (string item in flags_listbox.CheckedItems)
            {
                main_spell.affected_bps.Add(item);
            }
        }

        private void base_casting_time_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.base_casting_time = (int)base_casting_time_updown.Value;
        }

        private void casting_time_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.casting_time_increment = (int)casting_time_increment_updown.Value;
        }

        private void final_casting_time_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.final_casting_time = (int)final_casting_time_updown.Value;
        }

        private void min_field_intensity_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.min_field_intensity = (int)min_field_intensity_updown.Value;
        }

        private void min_casting_cost_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.base_energy_cost = (int)min_casting_cost_updown.Value;
        }

        private void casting_cost_increment_ValueChanged(object sender, EventArgs e)
        {
            main_spell.energy_increment = (int)casting_cost_increment.Value;
        }

        private void max_casting_cost_ValueChanged(object sender, EventArgs e)
        {
            main_spell.final_energy_cost = (int)max_casting_cost.Value;
        }

        private void field_intensity_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.field_intensity_increment = (float)field_intensity_increment_updown.Value;
        }

        private void max_field_intensity_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.max_field_intensity = (int)max_field_intensity_updown.Value;
        }

        private void min_duration_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.min_duration = (int)min_duration_updown.Value;
        }

        private void duration_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.duration_increment = (int)duration_increment_updown.Value;
        }

        private void max_duration_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.max_duration = (int)max_duration_updown.Value;
        }

        private void field_id_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.field = field_id_textbox.Text;
        }

        private void sound_description_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.sound_description = sound_description_textbox.Text;
        }

        private void sound_type_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.sound_type = sound_type_combobox.Text;
        }

        private void sound_id_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.sound_id = sound_id_textbox.Text;
        }

        private void sound_variant_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.sound_variant = sound_variant_textbox.Text;
        }

        private void sound_ambient_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            main_spell.sound_ambient = sound_ambient_checkbox.Checked;
        }

        private void effect_filter_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main_spell.effect_targets.Clear();

            foreach (string item in valid_targets_listbox.CheckedItems)
            {
                main_spell.effect_targets.Add(item);
            }
        }

        private void spell_message_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.message = spell_message_textbox.Text;
        }
    }
}
