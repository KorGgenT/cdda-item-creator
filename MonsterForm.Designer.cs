namespace cdda_item_creator
{
    partial class MonsterForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.clipboardButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.pluralNameTextBox = new System.Windows.Forms.TextBox();
            this.pluralNameLabel = new System.Windows.Forms.Label();
            this.hpUpDown = new System.Windows.Forms.NumericUpDown();
            this.hpLabel = new System.Windows.Forms.Label();
            this.volumeUpDown = new System.Windows.Forms.NumericUpDown();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeListbox = new System.Windows.Forms.ComboBox();
            this.weightComboBox = new System.Windows.Forms.ComboBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.weightUpDown = new System.Windows.Forms.NumericUpDown();
            this.symbolTextBox = new System.Windows.Forms.TextBox();
            this.symbolLabel = new System.Windows.Forms.Label();
            this.armorPanel = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.armorLabel = new System.Windows.Forms.Label();
            this.bashArmorLabel = new System.Windows.Forms.Label();
            this.cutArmorLabel = new System.Windows.Forms.Label();
            this.stabArmorLabel = new System.Windows.Forms.Label();
            this.acidArmorLabel = new System.Windows.Forms.Label();
            this.fireArmorLabel = new System.Windows.Forms.Label();
            this.bodytypeComboBox = new System.Windows.Forms.ComboBox();
            this.bodytypeId = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.mtypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monsterNameStringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hpUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightUpDown)).BeginInit();
            this.armorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterNameStringsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.monsterNameStringsBindingSource, "Str", true));
            this.nameTextBox.Location = new System.Drawing.Point(12, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // clipboardButton
            // 
            this.clipboardButton.Location = new System.Drawing.Point(659, 9);
            this.clipboardButton.Name = "clipboardButton";
            this.clipboardButton.Size = new System.Drawing.Size(129, 23);
            this.clipboardButton.TabIndex = 1;
            this.clipboardButton.Text = "Copy JSON to Clipboard";
            this.clipboardButton.UseVisualStyleBackColor = true;
            this.clipboardButton.Click += new System.EventHandler(this.clipboardButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mtypeBindingSource, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(118, 25);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 3;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(120, 9);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(15, 13);
            this.idLabel.TabIndex = 4;
            this.idLabel.Text = "id";
            // 
            // pluralNameTextBox
            // 
            this.pluralNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.monsterNameStringsBindingSource, "StrPl", true));
            this.pluralNameTextBox.Location = new System.Drawing.Point(12, 65);
            this.pluralNameTextBox.Name = "pluralNameTextBox";
            this.pluralNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.pluralNameTextBox.TabIndex = 5;
            // 
            // pluralNameLabel
            // 
            this.pluralNameLabel.AutoSize = true;
            this.pluralNameLabel.Location = new System.Drawing.Point(12, 49);
            this.pluralNameLabel.Name = "pluralNameLabel";
            this.pluralNameLabel.Size = new System.Drawing.Size(105, 13);
            this.pluralNameLabel.TabIndex = 6;
            this.pluralNameLabel.Text = "Plural (defaults to +s)";
            // 
            // hpUpDown
            // 
            this.hpUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mtypeBindingSource, "Hp", true));
            this.hpUpDown.Location = new System.Drawing.Point(224, 64);
            this.hpUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.hpUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hpUpDown.Name = "hpUpDown";
            this.hpUpDown.Size = new System.Drawing.Size(58, 20);
            this.hpUpDown.TabIndex = 7;
            this.hpUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // hpLabel
            // 
            this.hpLabel.AutoSize = true;
            this.hpLabel.Location = new System.Drawing.Point(226, 48);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(22, 13);
            this.hpLabel.TabIndex = 8;
            this.hpLabel.Text = "HP";
            // 
            // volumeUpDown
            // 
            this.volumeUpDown.Location = new System.Drawing.Point(224, 104);
            this.volumeUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.volumeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.volumeUpDown.Name = "volumeUpDown";
            this.volumeUpDown.Size = new System.Drawing.Size(58, 20);
            this.volumeUpDown.TabIndex = 9;
            this.volumeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(226, 88);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(42, 13);
            this.volumeLabel.TabIndex = 10;
            this.volumeLabel.Text = "Volume";
            // 
            // volumeListbox
            // 
            this.volumeListbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.volumeListbox.Items.AddRange(new object[] {
            "mL",
            "L"});
            this.volumeListbox.Location = new System.Drawing.Point(288, 104);
            this.volumeListbox.Name = "volumeListbox";
            this.volumeListbox.Size = new System.Drawing.Size(41, 21);
            this.volumeListbox.TabIndex = 44;
            // 
            // weightComboBox
            // 
            this.weightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weightComboBox.Items.AddRange(new object[] {
            "mg",
            "g",
            "kg"});
            this.weightComboBox.Location = new System.Drawing.Point(288, 143);
            this.weightComboBox.Name = "weightComboBox";
            this.weightComboBox.Size = new System.Drawing.Size(41, 21);
            this.weightComboBox.TabIndex = 47;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(226, 127);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(41, 13);
            this.weightLabel.TabIndex = 46;
            this.weightLabel.Text = "Weight";
            // 
            // weightUpDown
            // 
            this.weightUpDown.Location = new System.Drawing.Point(224, 143);
            this.weightUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.weightUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightUpDown.Name = "weightUpDown";
            this.weightUpDown.Size = new System.Drawing.Size(58, 20);
            this.weightUpDown.TabIndex = 45;
            this.weightUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // symbolTextBox
            // 
            this.symbolTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mtypeBindingSource, "Symbol", true));
            this.symbolTextBox.Location = new System.Drawing.Point(298, 63);
            this.symbolTextBox.MaxLength = 1;
            this.symbolTextBox.Name = "symbolTextBox";
            this.symbolTextBox.Size = new System.Drawing.Size(22, 20);
            this.symbolTextBox.TabIndex = 48;
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Location = new System.Drawing.Point(286, 49);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(41, 13);
            this.symbolLabel.TabIndex = 49;
            this.symbolLabel.Text = "Symbol";
            // 
            // armorPanel
            // 
            this.armorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.armorPanel.Controls.Add(this.fireArmorLabel);
            this.armorPanel.Controls.Add(this.acidArmorLabel);
            this.armorPanel.Controls.Add(this.stabArmorLabel);
            this.armorPanel.Controls.Add(this.cutArmorLabel);
            this.armorPanel.Controls.Add(this.bashArmorLabel);
            this.armorPanel.Controls.Add(this.armorLabel);
            this.armorPanel.Controls.Add(this.numericUpDown5);
            this.armorPanel.Controls.Add(this.numericUpDown4);
            this.armorPanel.Controls.Add(this.numericUpDown3);
            this.armorPanel.Controls.Add(this.numericUpDown2);
            this.armorPanel.Controls.Add(this.numericUpDown1);
            this.armorPanel.Location = new System.Drawing.Point(347, 26);
            this.armorPanel.Name = "armorPanel";
            this.armorPanel.Size = new System.Drawing.Size(93, 150);
            this.armorPanel.TabIndex = 50;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mtypeBindingSource, "ArmorBash", true));
            this.numericUpDown1.Location = new System.Drawing.Point(36, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mtypeBindingSource, "ArmorFire", true));
            this.numericUpDown2.Location = new System.Drawing.Point(36, 124);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown2.TabIndex = 1;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mtypeBindingSource, "ArmorCut", true));
            this.numericUpDown3.Location = new System.Drawing.Point(36, 45);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown3.TabIndex = 2;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mtypeBindingSource, "ArmorAcid", true));
            this.numericUpDown4.Location = new System.Drawing.Point(36, 98);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown4.TabIndex = 3;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mtypeBindingSource, "ArmorStab", true));
            this.numericUpDown5.Location = new System.Drawing.Point(36, 72);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown5.TabIndex = 4;
            // 
            // armorLabel
            // 
            this.armorLabel.AutoSize = true;
            this.armorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armorLabel.Location = new System.Drawing.Point(39, 3);
            this.armorLabel.Name = "armorLabel";
            this.armorLabel.Size = new System.Drawing.Size(39, 13);
            this.armorLabel.TabIndex = 5;
            this.armorLabel.Text = "Armor";
            // 
            // bashArmorLabel
            // 
            this.bashArmorLabel.AutoSize = true;
            this.bashArmorLabel.Location = new System.Drawing.Point(3, 22);
            this.bashArmorLabel.Name = "bashArmorLabel";
            this.bashArmorLabel.Size = new System.Drawing.Size(31, 13);
            this.bashArmorLabel.TabIndex = 6;
            this.bashArmorLabel.Text = "Bash";
            // 
            // cutArmorLabel
            // 
            this.cutArmorLabel.AutoSize = true;
            this.cutArmorLabel.Location = new System.Drawing.Point(11, 48);
            this.cutArmorLabel.Name = "cutArmorLabel";
            this.cutArmorLabel.Size = new System.Drawing.Size(23, 13);
            this.cutArmorLabel.TabIndex = 7;
            this.cutArmorLabel.Text = "Cut";
            // 
            // stabArmorLabel
            // 
            this.stabArmorLabel.AutoSize = true;
            this.stabArmorLabel.Location = new System.Drawing.Point(5, 75);
            this.stabArmorLabel.Name = "stabArmorLabel";
            this.stabArmorLabel.Size = new System.Drawing.Size(29, 13);
            this.stabArmorLabel.TabIndex = 8;
            this.stabArmorLabel.Text = "Stab";
            // 
            // acidArmorLabel
            // 
            this.acidArmorLabel.AutoSize = true;
            this.acidArmorLabel.Location = new System.Drawing.Point(6, 101);
            this.acidArmorLabel.Name = "acidArmorLabel";
            this.acidArmorLabel.Size = new System.Drawing.Size(28, 13);
            this.acidArmorLabel.TabIndex = 9;
            this.acidArmorLabel.Text = "Acid";
            // 
            // fireArmorLabel
            // 
            this.fireArmorLabel.AutoSize = true;
            this.fireArmorLabel.Location = new System.Drawing.Point(10, 127);
            this.fireArmorLabel.Name = "fireArmorLabel";
            this.fireArmorLabel.Size = new System.Drawing.Size(24, 13);
            this.fireArmorLabel.TabIndex = 10;
            this.fireArmorLabel.Text = "Fire";
            // 
            // bodytypeComboBox
            // 
            this.bodytypeComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "human",
            "angel",
            "snake",
            "blob"});
            this.bodytypeComboBox.Items.AddRange(new object[] {
            "human",
            "angel",
            "snake",
            "blob"});
            this.bodytypeComboBox.Location = new System.Drawing.Point(118, 64);
            this.bodytypeComboBox.Name = "bodytypeComboBox";
            this.bodytypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.bodytypeComboBox.TabIndex = 51;
            // 
            // bodytypeId
            // 
            this.bodytypeId.AutoSize = true;
            this.bodytypeId.Location = new System.Drawing.Point(119, 48);
            this.bodytypeId.Name = "bodytypeId";
            this.bodytypeId.Size = new System.Drawing.Size(58, 13);
            this.bodytypeId.TabIndex = 52;
            this.bodytypeId.Text = "Body Type";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mtypeBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 104);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(206, 72);
            this.descriptionTextBox.TabIndex = 53;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 88);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 54;
            this.descriptionLabel.Text = "Description";
            // 
            // colorComboBox
            // 
            this.colorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mtypeBindingSource, "Color", true));
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.Location = new System.Drawing.Point(224, 25);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(105, 21);
            this.colorComboBox.TabIndex = 55;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(226, 9);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 56;
            this.colorLabel.Text = "Color";
            // 
            // mtypeBindingSource
            // 
            this.mtypeBindingSource.DataSource = typeof(cdda_item_creator.Mtype);
            // 
            // monsterNameStringsBindingSource
            // 
            this.monsterNameStringsBindingSource.DataSource = typeof(cdda_item_creator.Translation);
            // 
            // MonsterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.bodytypeId);
            this.Controls.Add(this.bodytypeComboBox);
            this.Controls.Add(this.armorPanel);
            this.Controls.Add(this.symbolLabel);
            this.Controls.Add(this.symbolTextBox);
            this.Controls.Add(this.weightComboBox);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.weightUpDown);
            this.Controls.Add(this.volumeListbox);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.volumeUpDown);
            this.Controls.Add(this.hpLabel);
            this.Controls.Add(this.hpUpDown);
            this.Controls.Add(this.pluralNameLabel);
            this.Controls.Add(this.pluralNameTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.clipboardButton);
            this.Controls.Add(this.nameTextBox);
            this.Name = "MonsterForm";
            this.Text = "Monster Creator";
            ((System.ComponentModel.ISupportInitialize)(this.hpUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightUpDown)).EndInit();
            this.armorPanel.ResumeLayout(false);
            this.armorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterNameStringsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button clipboardButton;
        private System.Windows.Forms.BindingSource mtypeBindingSource;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.BindingSource monsterNameStringsBindingSource;
        private System.Windows.Forms.TextBox pluralNameTextBox;
        private System.Windows.Forms.Label pluralNameLabel;
        private System.Windows.Forms.NumericUpDown hpUpDown;
        private System.Windows.Forms.Label hpLabel;
        private System.Windows.Forms.NumericUpDown volumeUpDown;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.ComboBox volumeListbox;
        private System.Windows.Forms.ComboBox weightComboBox;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.NumericUpDown weightUpDown;
        private System.Windows.Forms.TextBox symbolTextBox;
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.Panel armorPanel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label cutArmorLabel;
        private System.Windows.Forms.Label bashArmorLabel;
        private System.Windows.Forms.Label armorLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label acidArmorLabel;
        private System.Windows.Forms.Label stabArmorLabel;
        private System.Windows.Forms.Label fireArmorLabel;
        private System.Windows.Forms.ComboBox bodytypeComboBox;
        private System.Windows.Forms.Label bodytypeId;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label colorLabel;
    }
}