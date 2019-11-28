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
            volumeListbox.SelectedIndex = 0;
            weightComboBox.SelectedIndex = 1;
            colorComboBox.SelectedIndex = 0;
        }

        private void clipboardButton_Click(object sender, EventArgs e)
        {
            main_monster.UpdateVolume((int)volumeUpDown.Value, volumeListbox.Text);
            main_monster.UpdateWeight((int)weightUpDown.Value, weightComboBox.Text);

            DefaultContractResolver contractResolver = new DefaultContractResolver
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
    }
}
