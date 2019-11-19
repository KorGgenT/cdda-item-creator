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
            this.clipboard_button = new System.Windows.Forms.Button();
            this.effect_combobox = new System.Windows.Forms.ComboBox();
            this.spell_effect_description_label = new System.Windows.Forms.Label();
            this.flags_listbox = new System.Windows.Forms.CheckedListBox();
            this.flags_label = new System.Windows.Forms.Label();
            this.effect_label = new System.Windows.Forms.Label();
            this.damage_label = new System.Windows.Forms.Label();
            this.range_label = new System.Windows.Forms.Label();
            this.aoe_label = new System.Windows.Forms.Label();
            this.min_range_label = new System.Windows.Forms.Label();
            this.increment_range_label = new System.Windows.Forms.Label();
            this.max_range_label = new System.Windows.Forms.Label();
            this.min_damage_updown = new System.Windows.Forms.NumericUpDown();
            this.damage_increment_updown = new System.Windows.Forms.NumericUpDown();
            this.max_damage_updown = new System.Windows.Forms.NumericUpDown();
            this.min_range_updown = new System.Windows.Forms.NumericUpDown();
            this.range_increment_updown = new System.Windows.Forms.NumericUpDown();
            this.max_range_updown = new System.Windows.Forms.NumericUpDown();
            this.min_aoe_updown = new System.Windows.Forms.NumericUpDown();
            this.aoe_increment_updown = new System.Windows.Forms.NumericUpDown();
            this.max_aoe_updown = new System.Windows.Forms.NumericUpDown();
            this.allowedstringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allowedstringsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.difficulty_updown = new System.Windows.Forms.NumericUpDown();
            this.difficulty_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.min_damage_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damage_increment_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_damage_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_range_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.range_increment_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_range_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_aoe_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aoe_increment_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_aoe_updown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty_updown)).BeginInit();
            this.SuspendLayout();
            // 
            // spell_name_textbox
            // 
            this.spell_name_textbox.Location = new System.Drawing.Point(16, 30);
            this.spell_name_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.spell_name_textbox.Name = "spell_name_textbox";
            this.spell_name_textbox.Size = new System.Drawing.Size(132, 22);
            this.spell_name_textbox.TabIndex = 0;
            this.spell_name_textbox.TextChanged += new System.EventHandler(this.spell_name_textbox_TextChanged);
            // 
            // spell_description_textbox
            // 
            this.spell_description_textbox.Location = new System.Drawing.Point(16, 84);
            this.spell_description_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.spell_description_textbox.Multiline = true;
            this.spell_description_textbox.Name = "spell_description_textbox";
            this.spell_description_textbox.Size = new System.Drawing.Size(301, 68);
            this.spell_description_textbox.TabIndex = 1;
            this.spell_description_textbox.TextChanged += new System.EventHandler(this.spell_description_textbox_TextChanged);
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
            this.energy_type_combobox.Location = new System.Drawing.Point(26, 306);
            this.energy_type_combobox.Margin = new System.Windows.Forms.Padding(4);
            this.energy_type_combobox.Name = "energy_type_combobox";
            this.energy_type_combobox.Size = new System.Drawing.Size(92, 24);
            this.energy_type_combobox.TabIndex = 0;
            this.energy_type_combobox.SelectedIndexChanged += new System.EventHandler(this.energy_type_combobox_SelectedIndexChanged);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(29, 10);
            this.name_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(45, 17);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Name";
            // 
            // id_textbox
            // 
            this.id_textbox.Location = new System.Drawing.Point(185, 30);
            this.id_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.id_textbox.Name = "id_textbox";
            this.id_textbox.Size = new System.Drawing.Size(132, 22);
            this.id_textbox.TabIndex = 3;
            this.id_textbox.TextChanged += new System.EventHandler(this.id_textbox_TextChanged);
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.Location = new System.Drawing.Point(209, 10);
            this.id_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(19, 17);
            this.id_label.TabIndex = 4;
            this.id_label.Text = "id";
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Location = new System.Drawing.Point(29, 64);
            this.description_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(79, 17);
            this.description_label.TabIndex = 5;
            this.description_label.Text = "Description";
            // 
            // energy_type_label
            // 
            this.energy_type_label.AutoSize = true;
            this.energy_type_label.Location = new System.Drawing.Point(30, 280);
            this.energy_type_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.energy_type_label.Name = "energy_type_label";
            this.energy_type_label.Size = new System.Drawing.Size(89, 17);
            this.energy_type_label.TabIndex = 6;
            this.energy_type_label.Text = "Energy Type";
            // 
            // clipboard_button
            // 
            this.clipboard_button.Location = new System.Drawing.Point(932, 10);
            this.clipboard_button.Margin = new System.Windows.Forms.Padding(4);
            this.clipboard_button.Name = "clipboard_button";
            this.clipboard_button.Size = new System.Drawing.Size(100, 28);
            this.clipboard_button.TabIndex = 7;
            this.clipboard_button.Text = "clipboard_button";
            this.clipboard_button.UseVisualStyleBackColor = true;
            this.clipboard_button.Click += new System.EventHandler(this.clipboard_button_Click);
            // 
            // effect_combobox
            // 
            this.effect_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effect_combobox.Items.AddRange(new object[] {
            "pain_split",
            "target_attack",
            "cone_attack",
            "line_attack",
            "spawn_item",
            "teleport_random",
            "recover_energy",
            "ter_transform",
            "vomit",
            "timed_event",
            "explosion",
            "flashbang",
            "mod_moves",
            "map",
            "morale",
            "charm_monster",
            "mutate",
            "bash",
            "none"});
            this.effect_combobox.Location = new System.Drawing.Point(16, 189);
            this.effect_combobox.Margin = new System.Windows.Forms.Padding(4);
            this.effect_combobox.Name = "effect_combobox";
            this.effect_combobox.Size = new System.Drawing.Size(120, 24);
            this.effect_combobox.TabIndex = 8;
            this.effect_combobox.SelectedIndexChanged += new System.EventHandler(this.effect_combobox_SelectedIndexChanged);
            // 
            // spell_effect_description_label
            // 
            this.spell_effect_description_label.AutoSize = true;
            this.spell_effect_description_label.Location = new System.Drawing.Point(169, 189);
            this.spell_effect_description_label.MaximumSize = new System.Drawing.Size(150, 0);
            this.spell_effect_description_label.Name = "spell_effect_description_label";
            this.spell_effect_description_label.Size = new System.Drawing.Size(149, 34);
            this.spell_effect_description_label.TabIndex = 9;
            this.spell_effect_description_label.Text = "spell_effect_description_label";
            // 
            // flags_listbox
            // 
            this.flags_listbox.FormattingEnabled = true;
            this.flags_listbox.Items.AddRange(new object[] {
            "PERMANENT",
            "IGNORE_WALLS",
            "HOSTILE_SUMMON",
            "HOSTILE_50",
            "SILENT",
            "LOUD",
            "VERBAL",
            "SOMATIC",
            "NO_HANDS",
            "UNSAFE_TELEPORT",
            "NO_LEGS",
            "CONCENTRATE",
            "RANDOM_AOE",
            "RANDOM_DAMAGE",
            "RANDOM_DURATION",
            "RANDOM_TARGET",
            "MUTATE_TRAIT",
            "WONDER"});
            this.flags_listbox.Location = new System.Drawing.Point(358, 47);
            this.flags_listbox.Name = "flags_listbox";
            this.flags_listbox.Size = new System.Drawing.Size(241, 344);
            this.flags_listbox.TabIndex = 10;
            this.flags_listbox.SelectedIndexChanged += new System.EventHandler(this.flags_listbox_SelectedIndexChanged);
            // 
            // flags_label
            // 
            this.flags_label.AutoSize = true;
            this.flags_label.Location = new System.Drawing.Point(374, 27);
            this.flags_label.Name = "flags_label";
            this.flags_label.Size = new System.Drawing.Size(42, 17);
            this.flags_label.TabIndex = 11;
            this.flags_label.Text = "Flags";
            // 
            // effect_label
            // 
            this.effect_label.AutoSize = true;
            this.effect_label.Location = new System.Drawing.Point(23, 165);
            this.effect_label.Name = "effect_label";
            this.effect_label.Size = new System.Drawing.Size(79, 17);
            this.effect_label.TabIndex = 13;
            this.effect_label.Text = "Spell Effect";
            // 
            // damage_label
            // 
            this.damage_label.AutoSize = true;
            this.damage_label.Location = new System.Drawing.Point(605, 84);
            this.damage_label.Name = "damage_label";
            this.damage_label.Size = new System.Drawing.Size(61, 17);
            this.damage_label.TabIndex = 23;
            this.damage_label.Text = "Damage";
            // 
            // range_label
            // 
            this.range_label.AutoSize = true;
            this.range_label.Location = new System.Drawing.Point(608, 112);
            this.range_label.Name = "range_label";
            this.range_label.Size = new System.Drawing.Size(50, 17);
            this.range_label.TabIndex = 24;
            this.range_label.Text = "Range";
            // 
            // aoe_label
            // 
            this.aoe_label.AutoSize = true;
            this.aoe_label.Location = new System.Drawing.Point(608, 140);
            this.aoe_label.Name = "aoe_label";
            this.aoe_label.Size = new System.Drawing.Size(37, 17);
            this.aoe_label.TabIndex = 25;
            this.aoe_label.Text = "AOE";
            // 
            // min_range_label
            // 
            this.min_range_label.AutoSize = true;
            this.min_range_label.Location = new System.Drawing.Point(682, 59);
            this.min_range_label.Name = "min_range_label";
            this.min_range_label.Size = new System.Drawing.Size(30, 17);
            this.min_range_label.TabIndex = 26;
            this.min_range_label.Text = "min";
            // 
            // increment_range_label
            // 
            this.increment_range_label.AutoSize = true;
            this.increment_range_label.Location = new System.Drawing.Point(753, 59);
            this.increment_range_label.Name = "increment_range_label";
            this.increment_range_label.Size = new System.Drawing.Size(46, 17);
            this.increment_range_label.TabIndex = 27;
            this.increment_range_label.Text = "per lvl";
            // 
            // max_range_label
            // 
            this.max_range_label.AutoSize = true;
            this.max_range_label.Location = new System.Drawing.Point(838, 59);
            this.max_range_label.Name = "max_range_label";
            this.max_range_label.Size = new System.Drawing.Size(33, 17);
            this.max_range_label.TabIndex = 28;
            this.max_range_label.Text = "max";
            // 
            // min_damage_updown
            // 
            this.min_damage_updown.Location = new System.Drawing.Point(669, 79);
            this.min_damage_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.min_damage_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.min_damage_updown.Name = "min_damage_updown";
            this.min_damage_updown.Size = new System.Drawing.Size(71, 22);
            this.min_damage_updown.TabIndex = 29;
            this.min_damage_updown.ValueChanged += new System.EventHandler(this.min_damage_updown_ValueChanged);
            // 
            // damage_increment_updown
            // 
            this.damage_increment_updown.DecimalPlaces = 3;
            this.damage_increment_updown.Location = new System.Drawing.Point(746, 79);
            this.damage_increment_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.damage_increment_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.damage_increment_updown.Name = "damage_increment_updown";
            this.damage_increment_updown.Size = new System.Drawing.Size(71, 22);
            this.damage_increment_updown.TabIndex = 30;
            this.damage_increment_updown.ValueChanged += new System.EventHandler(this.damage_increment_updown_ValueChanged);
            // 
            // max_damage_updown
            // 
            this.max_damage_updown.Location = new System.Drawing.Point(823, 79);
            this.max_damage_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.max_damage_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.max_damage_updown.Name = "max_damage_updown";
            this.max_damage_updown.Size = new System.Drawing.Size(71, 22);
            this.max_damage_updown.TabIndex = 31;
            this.max_damage_updown.ValueChanged += new System.EventHandler(this.max_damage_updown_ValueChanged);
            // 
            // min_range_updown
            // 
            this.min_range_updown.Location = new System.Drawing.Point(669, 107);
            this.min_range_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.min_range_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.min_range_updown.Name = "min_range_updown";
            this.min_range_updown.Size = new System.Drawing.Size(71, 22);
            this.min_range_updown.TabIndex = 32;
            this.min_range_updown.ValueChanged += new System.EventHandler(this.min_range_updown_ValueChanged);
            // 
            // range_increment_updown
            // 
            this.range_increment_updown.DecimalPlaces = 3;
            this.range_increment_updown.Location = new System.Drawing.Point(746, 107);
            this.range_increment_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.range_increment_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.range_increment_updown.Name = "range_increment_updown";
            this.range_increment_updown.Size = new System.Drawing.Size(71, 22);
            this.range_increment_updown.TabIndex = 33;
            this.range_increment_updown.ValueChanged += new System.EventHandler(this.range_increment_updown_ValueChanged);
            // 
            // max_range_updown
            // 
            this.max_range_updown.Location = new System.Drawing.Point(823, 107);
            this.max_range_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.max_range_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.max_range_updown.Name = "max_range_updown";
            this.max_range_updown.Size = new System.Drawing.Size(71, 22);
            this.max_range_updown.TabIndex = 34;
            this.max_range_updown.ValueChanged += new System.EventHandler(this.max_range_updown_ValueChanged);
            // 
            // min_aoe_updown
            // 
            this.min_aoe_updown.Location = new System.Drawing.Point(669, 135);
            this.min_aoe_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.min_aoe_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.min_aoe_updown.Name = "min_aoe_updown";
            this.min_aoe_updown.Size = new System.Drawing.Size(71, 22);
            this.min_aoe_updown.TabIndex = 35;
            this.min_aoe_updown.ValueChanged += new System.EventHandler(this.min_aoe_updown_ValueChanged);
            // 
            // aoe_increment_updown
            // 
            this.aoe_increment_updown.DecimalPlaces = 3;
            this.aoe_increment_updown.Location = new System.Drawing.Point(746, 135);
            this.aoe_increment_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.aoe_increment_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.aoe_increment_updown.Name = "aoe_increment_updown";
            this.aoe_increment_updown.Size = new System.Drawing.Size(71, 22);
            this.aoe_increment_updown.TabIndex = 36;
            this.aoe_increment_updown.ValueChanged += new System.EventHandler(this.aoe_increment_updown_ValueChanged);
            // 
            // max_aoe_updown
            // 
            this.max_aoe_updown.Location = new System.Drawing.Point(823, 135);
            this.max_aoe_updown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.max_aoe_updown.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.max_aoe_updown.Name = "max_aoe_updown";
            this.max_aoe_updown.Size = new System.Drawing.Size(71, 22);
            this.max_aoe_updown.TabIndex = 37;
            this.max_aoe_updown.ValueChanged += new System.EventHandler(this.max_aoe_updown_ValueChanged);
            // 
            // allowedstringsBindingSource
            // 
            this.allowedstringsBindingSource.DataSource = typeof(cdda_item_creator.spell.allowed_strings);
            // 
            // allowedstringsBindingSource1
            // 
            this.allowedstringsBindingSource1.DataSource = typeof(cdda_item_creator.spell.allowed_strings);
            // 
            // difficulty_updown
            // 
            this.difficulty_updown.Location = new System.Drawing.Point(76, 348);
            this.difficulty_updown.Name = "difficulty_updown";
            this.difficulty_updown.Size = new System.Drawing.Size(76, 22);
            this.difficulty_updown.TabIndex = 38;
            // 
            // difficulty_label
            // 
            this.difficulty_label.AutoSize = true;
            this.difficulty_label.Location = new System.Drawing.Point(12, 350);
            this.difficulty_label.Name = "difficulty_label";
            this.difficulty_label.Size = new System.Drawing.Size(58, 17);
            this.difficulty_label.TabIndex = 39;
            this.difficulty_label.Text = "Dfficulty";
            // 
            // spell_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.difficulty_label);
            this.Controls.Add(this.difficulty_updown);
            this.Controls.Add(this.max_aoe_updown);
            this.Controls.Add(this.aoe_increment_updown);
            this.Controls.Add(this.min_aoe_updown);
            this.Controls.Add(this.max_range_updown);
            this.Controls.Add(this.range_increment_updown);
            this.Controls.Add(this.min_range_updown);
            this.Controls.Add(this.max_damage_updown);
            this.Controls.Add(this.damage_increment_updown);
            this.Controls.Add(this.min_damage_updown);
            this.Controls.Add(this.max_range_label);
            this.Controls.Add(this.increment_range_label);
            this.Controls.Add(this.min_range_label);
            this.Controls.Add(this.aoe_label);
            this.Controls.Add(this.range_label);
            this.Controls.Add(this.damage_label);
            this.Controls.Add(this.effect_label);
            this.Controls.Add(this.flags_label);
            this.Controls.Add(this.flags_listbox);
            this.Controls.Add(this.spell_effect_description_label);
            this.Controls.Add(this.effect_combobox);
            this.Controls.Add(this.clipboard_button);
            this.Controls.Add(this.energy_type_label);
            this.Controls.Add(this.description_label);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.id_textbox);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.energy_type_combobox);
            this.Controls.Add(this.spell_description_textbox);
            this.Controls.Add(this.spell_name_textbox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "spell_form";
            this.Text = "Spell";
            ((System.ComponentModel.ISupportInitialize)(this.min_damage_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damage_increment_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_damage_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_range_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.range_increment_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_range_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_aoe_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aoe_increment_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_aoe_updown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allowedstringsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty_updown)).EndInit();
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
        private System.Windows.Forms.Button clipboard_button;
        private System.Windows.Forms.ComboBox effect_combobox;
        private System.Windows.Forms.Label spell_effect_description_label;
        private System.Windows.Forms.CheckedListBox flags_listbox;
        private System.Windows.Forms.Label flags_label;
        private System.Windows.Forms.Label effect_label;
        private System.Windows.Forms.Label damage_label;
        private System.Windows.Forms.Label range_label;
        private System.Windows.Forms.Label aoe_label;
        private System.Windows.Forms.Label min_range_label;
        private System.Windows.Forms.Label increment_range_label;
        private System.Windows.Forms.Label max_range_label;
        private System.Windows.Forms.NumericUpDown min_damage_updown;
        private System.Windows.Forms.NumericUpDown damage_increment_updown;
        private System.Windows.Forms.NumericUpDown max_damage_updown;
        private System.Windows.Forms.NumericUpDown min_range_updown;
        private System.Windows.Forms.NumericUpDown range_increment_updown;
        private System.Windows.Forms.NumericUpDown max_range_updown;
        private System.Windows.Forms.NumericUpDown min_aoe_updown;
        private System.Windows.Forms.NumericUpDown aoe_increment_updown;
        private System.Windows.Forms.NumericUpDown max_aoe_updown;
        private System.Windows.Forms.NumericUpDown difficulty_updown;
        private System.Windows.Forms.Label difficulty_label;
    }
}

