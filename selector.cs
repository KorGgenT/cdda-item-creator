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
    public partial class SelectorForm : Form
    {
        public SelectorForm()
        {
            InitializeComponent();
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

        }
    }
}
