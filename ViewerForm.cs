﻿using System;
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
    public partial class ViewerForm : Form
    {
        private void InitializeTypeList()
        {
            foreach(string type in Program.LoadedObjectDictionary.Keys())
            {
                typeListBox.Items.Add(type);
            }
        }
        public ViewerForm()
        {
            InitializeComponent();
            InitializeTypeList();
        }

        private void typeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            idListBox.Items.Clear();
            string s = "";
            foreach (string id in Program.LoadedObjectDictionary.GetList((string)typeListBox.SelectedItem))
            {
                idListBox.Items.Add(id);
                s += id + "\n";
            }
            Clipboard.SetText(s);
        }
    }
}
