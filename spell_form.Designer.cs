namespace cdda_item_creator
{
    partial class spell_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spell_name_textbox = new System.Windows.Forms.TextBox();
            this.spell_description_textbox = new System.Windows.Forms.TextBox();
            this.energy_type_combobox = new System.Windows.Forms.ComboBox();
            this.name_label = new System.Windows.Forms.Label();
            this.id_textbox = new System.Windows.Forms.TextBox();
            this.id_label = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.energy_type_label = new System.Windows.Forms.Label();
            this.allowedstringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allowedstringsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // spell_name_textbox
            // 
            this.spell_name_textbox.Location = new System.Drawing.Point(12, 24);
            this.spell_name_textbox.Name = "spell_name_textbox";
            this.spell_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.spell_name_textbox.TabIndex = 0;
            this.spell_name_textbox.TextChanged += new System.EventHandler(this.spell_name_textbox_TextChanged);
            // 
            // spell_description_textbox
            // 
            this.spell_description_textbox.Location = new System.Drawing.Point(12, 68);
            this.spell_description_textbox.Multiline = true;
            this.spell_description_textbox.Name = "spell_description_textbox";
            this.spell_description_textbox.Size = new System.Drawing.Size(227, 56);
            this.spell_description_textbox.TabIndex = 1;
            // 
            // energy_type_combobox
            // 
            this.energy_type_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.energy_type_combobox.Items.AddRange(new object[] {
            "NONE",
            "HP",
            "MANA",
            "STAMINA",
            "BIONIC",
            "FATGIUE"});
            this.energy_type_combobox.Location = new System.Drawing.Point(12, 148);
            this.energy_type_combobox.Name = "energy_type_combobox";
            this.energy_type_combobox.Size = new System.Drawing.Size(70, 21);
            this.energy_type_combobox.TabIndex = 0;
            this.energy_type_combobox.SelectedIndexChanged += new System.EventHandler(this.energy_type_combobox_SelectedIndexChanged);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(22, 8);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(35, 13);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Name";
            // 
            // id_textbox
            // 
            this.id_textbox.Location = new System.Drawing.Point(139, 24);
            this.id_textbox.Name = "id_textbox";
            this.id_textbox.Size = new System.Drawing.Size(100, 20);
            this.id_textbox.TabIndex = 3;
            this.id_textbox.TextChanged += new System.EventHandler(this.id_textbox_TextChanged);
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new System.Drawing.Point(157, 8);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(15, 13);
            this.id_label.TabIndex = 4;
            this.id_label.Text = "id";
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Location = new System.Drawing.Point(22, 52);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(60, 13);
            this.description_label.TabIndex = 5;
            this.description_label.Text = "Description";
            // 
            // energy_type_label
            // 
            this.energy_type_label.AutoSize = true;
            this.energy_type_label.Location = new System.Drawing.Point(15, 127);
            this.energy_type_label.Name = "energy_type_label";
            this.energy_type_label.Size = new System.Drawing.Size(67, 13);
            this.energy_type_label.TabIndex = 6;
            this.energy_type_label.Text = "Energy Type";
            // 
            // allowedstringsBindingSource
            // 
            this.allowedstringsBindingSource.DataSource = typeof(cdda_item_creator.spell.allowed_strings);
            // 
            // allowedstringsBindingSource1
            // 
            this.allowedstringsBindingSource1.DataSource = typeof(cdda_item_creator.spell.allowed_strings);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // spell_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.energy_type_label);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.id_textbox);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.energy_type_combobox);
            this.Controls.Add(this.spell_description_textbox);
            this.Controls.Add(this.spell_name_textbox);
            this.Name = "spell_form";
            this.Text = "Spell";
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox spell_name_textbox;
        private System.Windows.Forms.TextBox spell_description_textbox;
        private System.Windows.Forms.ComboBox energy_type_combobox;
        private System.Windows.Forms.BindingSource allowedstringsBindingSource1;
        private System.Windows.Forms.BindingSource allowedstringsBindingSource;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox id_textbox;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.Label energy_type_label;
        private System.Windows.Forms.Button button1;
    }
}

