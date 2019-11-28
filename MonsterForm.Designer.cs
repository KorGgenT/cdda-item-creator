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
            this.mtypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monsterNameStringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.clipboardButton);
            this.Controls.Add(this.nameTextBox);
            this.Name = "MonsterForm";
            this.Text = "MonsterForm";
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
    }
}