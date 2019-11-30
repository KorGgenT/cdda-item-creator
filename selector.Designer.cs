namespace cdda_item_creator
{
    partial class SelectorForm
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
            this.spellButton = new System.Windows.Forms.Button();
            this.createMonster_button = new System.Windows.Forms.Button();
            this.cddaFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.viewLoadedItemsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spellButton
            // 
            this.spellButton.Location = new System.Drawing.Point(12, 12);
            this.spellButton.Name = "spellButton";
            this.spellButton.Size = new System.Drawing.Size(75, 61);
            this.spellButton.TabIndex = 0;
            this.spellButton.Text = "Create Spell";
            this.spellButton.UseVisualStyleBackColor = true;
            this.spellButton.Click += new System.EventHandler(this.spellButton_Click);
            // 
            // createMonster_button
            // 
            this.createMonster_button.Location = new System.Drawing.Point(103, 12);
            this.createMonster_button.Name = "createMonster_button";
            this.createMonster_button.Size = new System.Drawing.Size(75, 61);
            this.createMonster_button.TabIndex = 1;
            this.createMonster_button.Text = "Create monster";
            this.createMonster_button.UseVisualStyleBackColor = true;
            this.createMonster_button.Click += new System.EventHandler(this.createMonster_button_Click);
            // 
            // cddaFolderBrowserDialog
            // 
            this.cddaFolderBrowserDialog.Description = "Choose the folder where C:DDA is located:";
            // 
            // viewLoadedItemsButton
            // 
            this.viewLoadedItemsButton.Location = new System.Drawing.Point(12, 79);
            this.viewLoadedItemsButton.Name = "viewLoadedItemsButton";
            this.viewLoadedItemsButton.Size = new System.Drawing.Size(75, 61);
            this.viewLoadedItemsButton.TabIndex = 2;
            this.viewLoadedItemsButton.Text = "View Loaded Items";
            this.viewLoadedItemsButton.UseVisualStyleBackColor = true;
            this.viewLoadedItemsButton.Click += new System.EventHandler(this.viewLoadedItemsButton_Click);
            // 
            // SelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 146);
            this.Controls.Add(this.viewLoadedItemsButton);
            this.Controls.Add(this.createMonster_button);
            this.Controls.Add(this.spellButton);
            this.Name = "SelectorForm";
            this.Text = "SelectorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button spellButton;
        private System.Windows.Forms.Button createMonster_button;
        private System.Windows.Forms.FolderBrowserDialog cddaFolderBrowserDialog;
        private System.Windows.Forms.Button viewLoadedItemsButton;
    }
}