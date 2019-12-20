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
    public partial class MaterialForm : Form
    {
        MaterialType main_material = new MaterialType() { BurnData = new List<BurnDataChunk>() { } };
        BindingList<BurnDataChunk> burn_data_list;
        private BindingSource MaterialBindingSource;
        private void LoadMaterialDataBinding()
        {
            components = new Container();
            MaterialBindingSource = new BindingSource(components);
            burn_data_list = new BindingList<BurnDataChunk>(main_material.BurnData);
            burnDataGrid.DataSource = new BindingSource(burn_data_list, null);

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

            burnDataGrid.Rows.Clear();
            if (main_material.BurnData != null)
            {
                burn_data_list = new BindingList<BurnDataChunk>(main_material.BurnData);
                burnDataGrid.DataSource = new BindingSource(burn_data_list, null);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {

            IgnoreEmptyEnumerablesResolver contractResolver = new IgnoreEmptyEnumerablesResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            Clipboard.SetText(JsonConvert.SerializeObject(
                main_material,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    ContractResolver = contractResolver
                }
                ));
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            main_material = new MaterialType() { };
            materialLoaderComboBox.SelectedIndex = -1;
            UpdateMainMaterialBindings();
        }
    }
}
