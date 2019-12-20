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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spellButton
            // 
            this.spellButton.Location = new System.Drawing.Point(84, 3);
            this.spellButton.Name = "spellButton";
            this.spellButton.Size = new System.Drawing.Size(75, 61);
            this.spellButton.TabIndex = 3;
            this.spellButton.Text = "Create Spell";
            this.spellButton.UseVisualStyleBackColor = true;
            this.spellButton.Click += new System.EventHandler(this.spellButton_Click);
            // 
            // createMonster_button
            // 
            this.createMonster_button.Location = new System.Drawing.Point(165, 3);
            this.createMonster_button.Name = "createMonster_button";
            this.createMonster_button.Size = new System.Drawing.Size(75, 61);
            this.createMonster_button.TabIndex = 4;
            this.createMonster_button.Text = "Create Monster";
            this.createMonster_button.UseVisualStyleBackColor = true;
            this.createMonster_button.Click += new System.EventHandler(this.createMonster_button_Click);
            // 
            // cddaFolderBrowserDialog
            // 
            this.cddaFolderBrowserDialog.Description = "Choose the folder where C:DDA is located:";
            // 
            // viewLoadedItemsButton
            // 
            this.viewLoadedItemsButton.Location = new System.Drawing.Point(3, 3);
            this.viewLoadedItemsButton.Name = "viewLoadedItemsButton";
            this.viewLoadedItemsButton.Size = new System.Drawing.Size(75, 61);
            this.viewLoadedItemsButton.TabIndex = 2;
            this.viewLoadedItemsButton.Text = "View Loaded Items";
            this.viewLoadedItemsButton.UseVisualStyleBackColor = true;
            this.viewLoadedItemsButton.Click += new System.EventHandler(this.viewLoadedItemsButton_Click);
            // 
            // loadGameDialog
            // 
            this.loadGameDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadGameDialog.Location = new System.Drawing.Point(3, 3);
            this.loadGameDialog.Name = "loadGameDialog";
            this.loadGameDialog.Size = new System.Drawing.Size(98, 44);
            this.loadGameDialog.TabIndex = 1;
            this.loadGameDialog.Text = "Pick C:DDA Folder";
            this.loadGameDialog.UseVisualStyleBackColor = true;
            this.loadGameDialog.Click += new System.EventHandler(this.loadGameDialog_Click);
            // 
            // currentPathLabelLabel
            // 
            this.currentPathLabelLabel.Location = new System.Drawing.Point(2, 9);
            this.currentPathLabelLabel.Name = "currentPathLabelLabel";
            this.currentPathLabelLabel.Size = new System.Drawing.Size(209, 18);
            this.currentPathLabelLabel.TabIndex = 4;
            this.currentPathLabelLabel.Text = "Current Path:";
            // 
            // currentPathLabel
            // 
            this.currentPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentPathLabel.Location = new System.Drawing.Point(3, 27);
            this.currentPathLabel.Name = "currentPathLabel";
            this.currentPathLabel.Size = new System.Drawing.Size(200, 20);
            this.currentPathLabel.TabIndex = 5;
            // 
            // createMaterialButton
            // 
            this.createMaterialButton.Location = new System.Drawing.Point(3, 70);
            this.createMaterialButton.Name = "createMaterialButton";
            this.createMaterialButton.Size = new System.Drawing.Size(75, 61);
            this.createMaterialButton.TabIndex = 5;
            this.createMaterialButton.Text = "Create Material";
            this.createMaterialButton.UseVisualStyleBackColor = true;
            this.createMaterialButton.Click += new System.EventHandler(this.createMaterialButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(314, 201);
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.loadGameDialog);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.currentPathLabelLabel);
            this.splitContainer2.Panel2.Controls.Add(this.currentPathLabel);
            this.splitContainer2.Size = new System.Drawing.Size(314, 61);
            this.splitContainer2.SplitterDistance = 104;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.viewLoadedItemsButton);
            this.flowLayoutPanel1.Controls.Add(this.spellButton);
            this.flowLayoutPanel1.Controls.Add(this.createMonster_button);
            this.flowLayoutPanel1.Controls.Add(this.createMaterialButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(314, 136);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // SelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 201);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(260, 240);
            this.Name = "SelectorForm";
            this.Text = "CDDA JSON Helper";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}