namespace cdda_item_creator
{
    partial class ViewerForm
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
            this.typeListBox = new System.Windows.Forms.ListBox();
            this.idListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // typeListBox
            // 
            this.typeListBox.FormattingEnabled = true;
            this.typeListBox.Location = new System.Drawing.Point(12, 12);
            this.typeListBox.Name = "typeListBox";
            this.typeListBox.Size = new System.Drawing.Size(208, 420);
            this.typeListBox.Sorted = true;
            this.typeListBox.TabIndex = 0;
            this.typeListBox.SelectedIndexChanged += new System.EventHandler(this.typeListBox_SelectedIndexChanged);
            // 
            // idListBox
            // 
            this.idListBox.FormattingEnabled = true;
            this.idListBox.Location = new System.Drawing.Point(226, 12);
            this.idListBox.Name = "idListBox";
            this.idListBox.Size = new System.Drawing.Size(208, 420);
            this.idListBox.Sorted = true;
            this.idListBox.TabIndex = 1;
            // 
            // ViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 440);
            this.Controls.Add(this.idListBox);
            this.Controls.Add(this.typeListBox);
            this.Name = "ViewerForm";
            this.Text = "Item ID Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox typeListBox;
        private System.Windows.Forms.ListBox idListBox;
    }
}