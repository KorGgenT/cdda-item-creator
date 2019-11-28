using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
    public partial class MonsterForm : Form
    {
        Mtype main_monster = new Mtype { };
        public MonsterForm()
        {
            InitializeComponent();
            mtypeBindingSource.Add(main_monster);
            monsterNameStringsBindingSource.Add(main_monster.Name);
        }

        private void clipboardButton_Click(object sender, EventArgs e)
        {
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
