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
    }
}
