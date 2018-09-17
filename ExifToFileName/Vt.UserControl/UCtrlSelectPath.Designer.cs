namespace ExifToFileName
{
    partial class UCtrlSelectPath
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BSelectPath = new System.Windows.Forms.Button();
            this.TBSelectedName = new System.Windows.Forms.TextBox();
            this.LDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BSelectPath
            // 
            this.BSelectPath.Dock = System.Windows.Forms.DockStyle.Right;
            this.BSelectPath.Location = new System.Drawing.Point(285, 0);
            this.BSelectPath.Name = "BSelectPath";
            this.BSelectPath.Size = new System.Drawing.Size(24, 20);
            this.BSelectPath.TabIndex = 1;
            this.BSelectPath.Text = "...";
            this.BSelectPath.UseVisualStyleBackColor = true;
            this.BSelectPath.Click += new System.EventHandler(this.BSelectPath_Click);
            // 
            // TBSelectedName
            // 
            this.TBSelectedName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TBSelectedName.Location = new System.Drawing.Point(71, 0);
            this.TBSelectedName.Name = "TBSelectedName";
            this.TBSelectedName.Size = new System.Drawing.Size(214, 20);
            this.TBSelectedName.TabIndex = 0;
            this.TBSelectedName.TextChanged += new System.EventHandler(this.TBSelectedName_TextChanged);
            // 
            // LDescription
            // 
            this.LDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.LDescription.BackColor = System.Drawing.SystemColors.Control;
            this.LDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.LDescription.Location = new System.Drawing.Point(4, 4);
            this.LDescription.Name = "LDescription";
            this.LDescription.Size = new System.Drawing.Size(66, 13);
            this.LDescription.TabIndex = 2;
            this.LDescription.Text = "LDescription";
            // 
            // UCtrlSelectPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LDescription);
            this.Controls.Add(this.TBSelectedName);
            this.Controls.Add(this.BSelectPath);
            this.Name = "UCtrlSelectPath";
            this.Size = new System.Drawing.Size(309, 20);
            this.Resize += new System.EventHandler(this.UCtrlSelectPath_Resize);
            this.BackColorChanged += new System.EventHandler(this.UCtrlSelectPath_BackColorChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BSelectPath;
        private System.Windows.Forms.TextBox TBSelectedName;
        private System.Windows.Forms.Label LDescription;
    }
}
