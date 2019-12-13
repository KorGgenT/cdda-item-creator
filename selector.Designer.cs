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
            this.loadGameDialog = new System.Windows.Forms.Button();
            this.currentPathLabelLabel = new System.Windows.Forms.Label();
            this.currentPathLabel = new System.Windows.Forms.Label();
            this.createMaterialButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spellButton
            // 
            this.spellButton.Location = new System.Drawing.Point(93, 79);
            this.spellButton.Name = "spellButton";
            this.spellButton.Size = new System.Drawing.Size(75, 61);
            this.spellButton.TabIndex = 0;
            this.spellButton.Text = "Create Spell";
            this.spellButton.UseVisualStyleBackColor = true;
            this.spellButton.Click += new System.EventHandler(this.spellButton_Click);
            // 
            // createMonster_button
            // 
            this.createMonster_button.Location = new System.Drawing.Point(174, 79);
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
            // loadGameDialog
            // 
            this.loadGameDialog.Location = new System.Drawing.Point(12, 12);
            this.loadGameDialog.Name = "loadGameDialog";
            this.loadGameDialog.Size = new System.Drawing.Size(75, 44);
            this.loadGameDialog.TabIndex = 3;
            this.loadGameDialog.Text = "Pick C:DDA Folder";
            this.loadGameDialog.UseVisualStyleBackColor = true;
            this.loadGameDialog.Click += new System.EventHandler(this.loadGameDialog_Click);
            // 
            // currentPathLabelLabel
            // 
            this.currentPathLabelLabel.AutoSize = true;
            this.currentPathLabelLabel.Location = new System.Drawing.Point(94, 13);
            this.currentPathLabelLabel.Name = "currentPathLabelLabel";
            this.currentPathLabelLabel.Size = new System.Drawing.Size(69, 13);
            this.currentPathLabelLabel.TabIndex = 4;
            this.currentPathLabelLabel.Text = "Current Path:";
            // 
            // currentPathLabel
            // 
            this.currentPathLabel.AutoSize = true;
            this.currentPathLabel.Location = new System.Drawing.Point(97, 30);
            this.currentPathLabel.MaximumSize = new System.Drawing.Size(150, 0);
            this.currentPathLabel.Name = "currentPathLabel";
            this.currentPathLabel.Size = new System.Drawing.Size(0, 13);
            this.currentPathLabel.TabIndex = 5;
            // 
            // createMaterialButton
            // 
            this.createMaterialButton.Location = new System.Drawing.Point(93, 146);
            this.createMaterialButton.Name = "createMaterialButton";
            this.createMaterialButton.Size = new System.Drawing.Size(75, 61);
            this.createMaterialButton.TabIndex = 6;
            this.createMaterialButton.Text = "Create Material";
            this.createMaterialButton.UseVisualStyleBackColor = true;
            this.createMaterialButton.Click += new System.EventHandler(this.createMaterialButton_Click);
            // 
            // SelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 214);
            this.Controls.Add(this.createMaterialButton);
            this.Controls.Add(this.currentPathLabel);
            this.Controls.Add(this.currentPathLabelLabel);
            this.Controls.Add(this.loadGameDialog);
            this.Controls.Add(this.viewLoadedItemsButton);
            this.Controls.Add(this.createMonster_button);
            this.Controls.Add(this.spellButton);
            this.Name = "SelectorForm";
            this.Text = "SelectorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button spellButton;
        private System.Windows.Forms.Button createMonster_button;
        private System.Windows.Forms.FolderBrowserDialog cddaFolderBrowserDialog;
        private System.Windows.Forms.Button viewLoadedItemsButton;
        private System.Windows.Forms.Button loadGameDialog;
        private System.Windows.Forms.Label currentPathLabelLabel;
        private System.Windows.Forms.Label currentPathLabel;
        private System.Windows.Forms.Button createMaterialButton;
    }
}