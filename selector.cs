using Newtonsoft.Json;
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
    public partial class SelectorForm : Form
    {
        private void TryLoadObjectLists()
        {
            cddaFolderBrowserDialog.ShowDialog();
            if(cddaFolderBrowserDialog.SelectedPath == "")
            {
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(cddaFolderBrowserDialog.SelectedPath);
            foreach (FileInfo file in dir.GetFiles("*.json", SearchOption.AllDirectories))
            {
                string file_text = File.ReadAllText(file.FullName);
                try
                {
                    JArray ja = JArray.Parse(file_text);
                    List<GenericTypedObject> temp_list = (List<GenericTypedObject>)ja.ToObject(typeof(List<GenericTypedObject>));
                    foreach (GenericTypedObject obj in temp_list)
                    {
                        if (obj.valid())
                        {
                            Program.LoadedObjectDictionary.Add(obj.Type, obj.Id);
                        }
                    }
                } catch
                {

                }
            }
        }
        public SelectorForm()
        {
            InitializeComponent();
            TryLoadObjectLists();
        }

        private void spellButton_Click(object sender, EventArgs e)
        {
            spell_form form = new spell_form();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void createMonster_button_Click(object sender, EventArgs e)
        {
            MonsterForm form = new MonsterForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void viewLoadedItemsButton_Click(object sender, EventArgs e)
        {
            ViewerForm form = new ViewerForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
    public class GenericTypedObject
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public bool valid()
        {
            return Type != null && Id != null;
        }
    }
}
