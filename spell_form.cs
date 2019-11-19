using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cdda_item_creator
{
    public partial class spell_form : Form
    {
        static spell.spell_type main_spell = new spell.spell_type();

        public spell_form()
        {
            InitializeComponent();
            energy_type_combobox.SelectedIndex = 0;
            effect_combobox.SelectedIndex = 18;
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
            Clipboard.SetText(main_spell.create_json());

            main_spell.spell_tags.Clear();

            foreach (string item in flags_listbox.CheckedItems)
            {
                main_spell.spell_tags.Add(item);
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
        }

        private void flags_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            main_spell.spell_tags.Clear();
            
            foreach (string item in flags_listbox.CheckedItems)
            {
                main_spell.spell_tags.Add(item);
            }
        }

        private void min_damage_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.damage.update_min((int)min_damage_updown.Value);
        }

        private void damage_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.damage.update_increment((float)damage_increment_updown.Value);
        }

        private void max_damage_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.damage.update_max((int)max_damage_updown.Value);
        }

        private void min_range_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.range.update_min((int)min_damage_updown.Value);
        }

        private void range_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.range.update_increment((float)range_increment_updown.Value);
        }

        private void max_range_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.range.update_max((int)max_range_updown.Value);
        }

        private void min_aoe_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.aoe.update_min((int)min_aoe_updown.Value);
        }

        private void aoe_increment_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.aoe.update_increment((float)aoe_increment_updown.Value);
        }

        private void max_aoe_updown_ValueChanged(object sender, EventArgs e)
        {
            main_spell.aoe.update_max((int)max_aoe_updown.Value);
        }
    }
}
