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
            spelltypeBindingSource.Add(main_spell);
            energy_type_combobox.SelectedIndex = 0;
            effect_combobox.SelectedIndex = 21;
            damage_type_combobox.SelectedIndex = 8;
            sound_type_combobox.SelectedIndex = 10;
        }

        private void clipboard_button_Click(object sender, EventArgs e)
        {
            if (flags_listbox.CheckedItems.Count > 0)
            {
                main_spell.spell_tags = new List<string> { };

                foreach (string item in flags_listbox.CheckedItems)
                {
                    main_spell.spell_tags.Add(item);
                }
            } else {
                main_spell.spell_tags = null;
            }

            if (valid_targets_listbox.CheckedItems.Count > 0)
            {
                main_spell.valid_targets = new List<string> { };

                foreach (string item in valid_targets_listbox.CheckedItems)
                {
                    main_spell.valid_targets.Add(item);
                }
            } else {
                main_spell.valid_targets = null;
            }

            if (effected_body_part_listbox.CheckedItems.Count > 0)
            {
                main_spell.affected_bps = new List<string> { };

                foreach (string item in effected_body_part_listbox.CheckedItems)
                {
                    main_spell.affected_bps.Add(item);
                }
            } else {
                main_spell.affected_bps = null;
            }

            if(effect_filter_listbox.CheckedItems.Count > 0)
            {
                main_spell.effect_targets = new List<string> { };

                foreach(string item in effect_filter_listbox.CheckedItems)
                {
                    main_spell.effect_targets.Add(item);
                }
            } else {
                main_spell.effect_targets = null;
            }

            Clipboard.SetText(JsonConvert.SerializeObject(
                main_spell,
                Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }
                ));
        }

        private void effect_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string effect = spell.allowed_strings.effects[effect_combobox.SelectedIndex];
            spell_effect_description_label.Text = spell.allowed_strings.effect_descriptions[effect];
            update_effect_str(effect);
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

        private void spell_message_textbox_TextChanged(object sender, EventArgs e)
        {
            main_spell.message = spell_message_textbox.Text;
        }
    }
}
