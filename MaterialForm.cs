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
    public partial class MaterialForm : Form
    {
        MaterialType main_material = new MaterialType() { };
        private BindingSource MaterialBindingSource;
        private void LoadMaterialDataBinding()
        {
            MaterialBindingSource = new BindingSource(components);
            ((ISupportInitialize)(MaterialBindingSource)).BeginInit();

            identTextBox.DataBindings.Add(new Binding("Text", MaterialBindingSource, "Ident", true));
            nameTextBox.DataBindings.Add(new Binding("Text", MaterialBindingSource, "Name", true));

            bashResistUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "BashResist", true));
            cutResistUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "CutResist", true));
            acidResistUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "AcidResist", true));
            elecResistUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "ElecResist", true));
            fireResistUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "fireResist", true));
            chipResistUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "ChipResist", true));

            densityUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "Density", true));

            specificHeatLiquidUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "SpecificHeatLiquid", true));
            specificHeatSolidUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "SpecificHeatSolid", true));
            latentHeatUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "LatentHeat", true));
            freezePointUpDown.DataBindings.Add(new Binding("Value", MaterialBindingSource, "FreezePoint", true));

            salvagedIntoTextBox.DataBindings.Add(new Binding("Text", MaterialBindingSource, "SalvagedInto", true));
            repairedIntoTextBox.DataBindings.Add(new Binding("Text", MaterialBindingSource, "RepairedInto", true));

            edibleCheckBox.DataBindings.Add(new Binding("Checked", MaterialBindingSource, "Edible", true));
            rottingCheckBox.DataBindings.Add(new Binding("Checked", MaterialBindingSource, "Rotting", true));
            softCheckBox.DataBindings.Add(new Binding("Checked", MaterialBindingSource, "Soft", true));
            reinforcesCheckBox.DataBindings.Add(new Binding("Checked", MaterialBindingSource, "Reinforces", true));

            bashDmgVerbTextBox.DataBindings.Add(new Binding("Text", MaterialBindingSource, "BashDmgVerb", true));
            cutDmgVerbTextBox.DataBindings.Add(new Binding("Text", MaterialBindingSource, "CutDmgVerb", true));

            ((ISupportInitialize)(MaterialBindingSource)).EndInit();

            MaterialBindingSource.Add(main_material);
        }
        private void LoadMaterialList()
        {
            materialLoaderComboBox.Items.AddRange(Program.LoadedObjectDictionary.GetList("material").ToArray());
        }
        public MaterialForm()
        {
            InitializeComponent();
            LoadMaterialList();
            LoadMaterialDataBinding();
        }
        private void UpdateMainMaterialBindings()
        {
            MaterialBindingSource.Clear();
            MaterialBindingSource.Add(main_material);
            MaterialBindingSource.ResetBindings(false);
        }
        private void materialLoaderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialLoaderComboBox.SelectedIndex == -1)
            {
                return;
            }
            // TODO: selector for items, and show what mod they're from
            List<MaterialType> mats = Program.LoadedObjectDictionary.GetMaterials(materialLoaderComboBox.Text);
            main_material = mats[0].DeepCopy();
            UpdateMainMaterialBindings();
        }
    }
}
