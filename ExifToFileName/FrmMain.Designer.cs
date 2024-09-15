namespace ExifToFileName
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TPFilenames = new System.Windows.Forms.TabPage();
            this.CBMoveDuplicates = new System.Windows.Forms.CheckBox();
            this.CBMoveMode = new System.Windows.Forms.CheckBox();
            this.TBDupSubFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBForepart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BGo = new System.Windows.Forms.Button();
            this.SPDestination = new ExifToFileName.UCtrlSelectPath();
            this.SPSource = new ExifToFileName.UCtrlSelectPath();
            this.TPAdvanced = new System.Windows.Forms.TabPage();
            this.GBVariables = new System.Windows.Forms.GroupBox();
            this.LBVariables = new System.Windows.Forms.ListBox();
            this.GBNoExif = new System.Windows.Forms.GroupBox();
            this.TBNoExifFilename = new System.Windows.Forms.TextBox();
            this.GBExifFilenames = new System.Windows.Forms.GroupBox();
            this.CBIgnoreSubfolder = new System.Windows.Forms.CheckBox();
            this.TBExifFilename = new System.Windows.Forms.TextBox();
            this.CBCreateDaySubDirectory = new System.Windows.Forms.CheckBox();
            this.TPLog = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBShowErrorLog = new System.Windows.Forms.CheckBox();
            this.TCMain.SuspendLayout();
            this.TPFilenames.SuspendLayout();
            this.TPAdvanced.SuspendLayout();
            this.GBVariables.SuspendLayout();
            this.GBNoExif.SuspendLayout();
            this.GBExifFilenames.SuspendLayout();
            this.TPLog.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCMain
            // 
            this.TCMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCMain.Controls.Add(this.TPFilenames);
            this.TCMain.Controls.Add(this.TPAdvanced);
            this.TCMain.Controls.Add(this.TPLog);
            this.TCMain.Location = new System.Drawing.Point(12, 15);
            this.TCMain.Margin = new System.Windows.Forms.Padding(4);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(823, 202);
            this.TCMain.TabIndex = 0;
            // 
            // TPFilenames
            // 
            this.TPFilenames.BackColor = System.Drawing.SystemColors.Control;
            this.TPFilenames.Controls.Add(this.CBMoveDuplicates);
            this.TPFilenames.Controls.Add(this.CBMoveMode);
            this.TPFilenames.Controls.Add(this.TBDupSubFolder);
            this.TPFilenames.Controls.Add(this.label3);
            this.TPFilenames.Controls.Add(this.TBForepart);
            this.TPFilenames.Controls.Add(this.label1);
            this.TPFilenames.Controls.Add(this.BGo);
            this.TPFilenames.Controls.Add(this.SPDestination);
            this.TPFilenames.Controls.Add(this.SPSource);
            this.TPFilenames.Location = new System.Drawing.Point(4, 25);
            this.TPFilenames.Margin = new System.Windows.Forms.Padding(4);
            this.TPFilenames.Name = "TPFilenames";
            this.TPFilenames.Padding = new System.Windows.Forms.Padding(4);
            this.TPFilenames.Size = new System.Drawing.Size(815, 173);
            this.TPFilenames.TabIndex = 0;
            this.TPFilenames.Text = "Paths";
            // 
            // CBMoveDuplicates
            // 
            this.CBMoveDuplicates.AutoSize = true;
            this.CBMoveDuplicates.Location = new System.Drawing.Point(151, 76);
            this.CBMoveDuplicates.Margin = new System.Windows.Forms.Padding(4);
            this.CBMoveDuplicates.Name = "CBMoveDuplicates";
            this.CBMoveDuplicates.Size = new System.Drawing.Size(164, 20);
            this.CBMoveDuplicates.TabIndex = 102;
            this.CBMoveDuplicates.Text = "Copy\\Move duplicates";
            this.CBMoveDuplicates.UseVisualStyleBackColor = true;
            this.CBMoveDuplicates.CheckedChanged += new System.EventHandler(this.CBMoveDuplicates_CheckedChanged);
            // 
            // CBMoveMode
            // 
            this.CBMoveMode.AutoSize = true;
            this.CBMoveMode.Location = new System.Drawing.Point(16, 76);
            this.CBMoveMode.Margin = new System.Windows.Forms.Padding(4);
            this.CBMoveMode.Name = "CBMoveMode";
            this.CBMoveMode.Size = new System.Drawing.Size(101, 20);
            this.CBMoveMode.TabIndex = 101;
            this.CBMoveMode.Text = "Move mode";
            this.CBMoveMode.UseVisualStyleBackColor = true;
            // 
            // TBDupSubFolder
            // 
            this.TBDupSubFolder.Location = new System.Drawing.Point(151, 103);
            this.TBDupSubFolder.Margin = new System.Windows.Forms.Padding(4);
            this.TBDupSubFolder.Name = "TBDupSubFolder";
            this.TBDupSubFolder.Size = new System.Drawing.Size(223, 22);
            this.TBDupSubFolder.TabIndex = 20;
            this.TBDupSubFolder.Text = "_duplicates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Duplicates subfolder";
            // 
            // TBForepart
            // 
            this.TBForepart.Location = new System.Drawing.Point(151, 138);
            this.TBForepart.Margin = new System.Windows.Forms.Padding(4);
            this.TBForepart.Name = "TBForepart";
            this.TBForepart.Size = new System.Drawing.Size(223, 22);
            this.TBForepart.TabIndex = 30;
            this.TBForepart.Text = "Forepart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filename forepart";
            // 
            // BGo
            // 
            this.BGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BGo.Location = new System.Drawing.Point(571, 81);
            this.BGo.Margin = new System.Windows.Forms.Padding(4);
            this.BGo.Name = "BGo";
            this.BGo.Size = new System.Drawing.Size(233, 81);
            this.BGo.TabIndex = 100;
            this.BGo.Text = "Go";
            this.BGo.UseVisualStyleBackColor = true;
            this.BGo.Click += new System.EventHandler(this.BGo_Click);
            // 
            // SPDestination
            // 
            this.SPDestination.Caption = "Destination";
            this.SPDestination.CaptionTextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SPDestination.CaptionWidth = 66;
            this.SPDestination.Location = new System.Drawing.Point(8, 43);
            this.SPDestination.Margin = new System.Windows.Forms.Padding(5);
            this.SPDestination.Name = "SPDestination";
            this.SPDestination.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.SPDestination.SelectedFolder = "";
            this.SPDestination.ShowNewFolderButton = false;
            this.SPDestination.Size = new System.Drawing.Size(796, 25);
            this.SPDestination.TabIndex = 1;
            this.SPDestination.OnSelectedFolderChange += new System.EventHandler(this.SPDestination_OnSelectedFolderChange);
            // 
            // SPSource
            // 
            this.SPSource.Caption = "Source";
            this.SPSource.CaptionTextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SPSource.CaptionWidth = 66;
            this.SPSource.Location = new System.Drawing.Point(8, 10);
            this.SPSource.Margin = new System.Windows.Forms.Padding(5);
            this.SPSource.Name = "SPSource";
            this.SPSource.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.SPSource.SelectedFolder = "";
            this.SPSource.ShowNewFolderButton = false;
            this.SPSource.Size = new System.Drawing.Size(796, 25);
            this.SPSource.TabIndex = 0;
            this.SPSource.OnSelectedFolderChange += new System.EventHandler(this.SPSource_OnSelectedFolderChange);
            // 
            // TPAdvanced
            // 
            this.TPAdvanced.BackColor = System.Drawing.SystemColors.Control;
            this.TPAdvanced.Controls.Add(this.GBVariables);
            this.TPAdvanced.Controls.Add(this.GBNoExif);
            this.TPAdvanced.Controls.Add(this.GBExifFilenames);
            this.TPAdvanced.Location = new System.Drawing.Point(4, 25);
            this.TPAdvanced.Margin = new System.Windows.Forms.Padding(4);
            this.TPAdvanced.Name = "TPAdvanced";
            this.TPAdvanced.Padding = new System.Windows.Forms.Padding(4);
            this.TPAdvanced.Size = new System.Drawing.Size(815, 173);
            this.TPAdvanced.TabIndex = 1;
            this.TPAdvanced.Text = "Advanced";
            // 
            // GBVariables
            // 
            this.GBVariables.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GBVariables.Controls.Add(this.LBVariables);
            this.GBVariables.Location = new System.Drawing.Point(653, 12);
            this.GBVariables.Margin = new System.Windows.Forms.Padding(4);
            this.GBVariables.Name = "GBVariables";
            this.GBVariables.Padding = new System.Windows.Forms.Padding(4);
            this.GBVariables.Size = new System.Drawing.Size(148, 145);
            this.GBVariables.TabIndex = 13;
            this.GBVariables.TabStop = false;
            this.GBVariables.Text = "Variables";
            // 
            // LBVariables
            // 
            this.LBVariables.FormattingEnabled = true;
            this.LBVariables.ItemHeight = 16;
            this.LBVariables.Items.AddRange(new object[] {
            "%forepart%",
            "%year%",
            "%month%",
            "%day%",
            "%hour%",
            "%minute%",
            "%second%",
            "%number%",
            "%noexifnumber%",
            "%dayname%",
            "%daynameshort%",
            "%equip1%",
            "%equipfull%"});
            this.LBVariables.Location = new System.Drawing.Point(8, 23);
            this.LBVariables.Margin = new System.Windows.Forms.Padding(4);
            this.LBVariables.Name = "LBVariables";
            this.LBVariables.Size = new System.Drawing.Size(131, 116);
            this.LBVariables.TabIndex = 50;
            this.LBVariables.SelectedIndexChanged += new System.EventHandler(this.LBVariables_SelectedIndexChanged);
            this.LBVariables.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LBVariables_MouseDown);
            // 
            // GBNoExif
            // 
            this.GBNoExif.Controls.Add(this.TBNoExifFilename);
            this.GBNoExif.Location = new System.Drawing.Point(8, 100);
            this.GBNoExif.Margin = new System.Windows.Forms.Padding(4);
            this.GBNoExif.Name = "GBNoExif";
            this.GBNoExif.Padding = new System.Windows.Forms.Padding(4);
            this.GBNoExif.Size = new System.Drawing.Size(637, 58);
            this.GBNoExif.TabIndex = 12;
            this.GBNoExif.TabStop = false;
            this.GBNoExif.Text = "No exif filename";
            // 
            // TBNoExifFilename
            // 
            this.TBNoExifFilename.AllowDrop = true;
            this.TBNoExifFilename.Location = new System.Drawing.Point(9, 23);
            this.TBNoExifFilename.Margin = new System.Windows.Forms.Padding(4);
            this.TBNoExifFilename.Name = "TBNoExifFilename";
            this.TBNoExifFilename.Size = new System.Drawing.Size(619, 22);
            this.TBNoExifFilename.TabIndex = 40;
            this.TBNoExifFilename.Text = "NoExifInfo_%noexifnumber%_%number%";
            this.TBNoExifFilename.DragDrop += new System.Windows.Forms.DragEventHandler(this.TBExifFilename_DragDrop);
            this.TBNoExifFilename.DragEnter += new System.Windows.Forms.DragEventHandler(this.TBExifFilename_DragEnter);
            // 
            // GBExifFilenames
            // 
            this.GBExifFilenames.Controls.Add(this.CBIgnoreSubfolder);
            this.GBExifFilenames.Controls.Add(this.TBExifFilename);
            this.GBExifFilenames.Controls.Add(this.CBCreateDaySubDirectory);
            this.GBExifFilenames.Location = new System.Drawing.Point(8, 7);
            this.GBExifFilenames.Margin = new System.Windows.Forms.Padding(4);
            this.GBExifFilenames.Name = "GBExifFilenames";
            this.GBExifFilenames.Padding = new System.Windows.Forms.Padding(4);
            this.GBExifFilenames.Size = new System.Drawing.Size(637, 85);
            this.GBExifFilenames.TabIndex = 11;
            this.GBExifFilenames.TabStop = false;
            this.GBExifFilenames.Text = "Exif filename";
            // 
            // CBIgnoreSubfolder
            // 
            this.CBIgnoreSubfolder.AutoSize = true;
            this.CBIgnoreSubfolder.Location = new System.Drawing.Point(252, 55);
            this.CBIgnoreSubfolder.Margin = new System.Windows.Forms.Padding(4);
            this.CBIgnoreSubfolder.Name = "CBIgnoreSubfolder";
            this.CBIgnoreSubfolder.Size = new System.Drawing.Size(184, 20);
            this.CBIgnoreSubfolder.TabIndex = 30;
            this.CBIgnoreSubfolder.Text = "Ignore original sub-folders";
            this.CBIgnoreSubfolder.UseVisualStyleBackColor = true;
            // 
            // TBExifFilename
            // 
            this.TBExifFilename.AllowDrop = true;
            this.TBExifFilename.Location = new System.Drawing.Point(9, 23);
            this.TBExifFilename.Margin = new System.Windows.Forms.Padding(4);
            this.TBExifFilename.Name = "TBExifFilename";
            this.TBExifFilename.Size = new System.Drawing.Size(619, 22);
            this.TBExifFilename.TabIndex = 10;
            this.TBExifFilename.Text = "%forepart%_%year%%month%%day%_%hour%%minute%%second%";
            this.TBExifFilename.DragDrop += new System.Windows.Forms.DragEventHandler(this.TBExifFilename_DragDrop);
            this.TBExifFilename.DragEnter += new System.Windows.Forms.DragEventHandler(this.TBExifFilename_DragEnter);
            // 
            // CBCreateDaySubDirectory
            // 
            this.CBCreateDaySubDirectory.AutoSize = true;
            this.CBCreateDaySubDirectory.Checked = true;
            this.CBCreateDaySubDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCreateDaySubDirectory.Location = new System.Drawing.Point(9, 55);
            this.CBCreateDaySubDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.CBCreateDaySubDirectory.Name = "CBCreateDaySubDirectory";
            this.CBCreateDaySubDirectory.Size = new System.Drawing.Size(177, 20);
            this.CBCreateDaySubDirectory.TabIndex = 20;
            this.CBCreateDaySubDirectory.Text = "Create DAY subdirectory";
            this.CBCreateDaySubDirectory.UseVisualStyleBackColor = true;
            // 
            // TPLog
            // 
            this.TPLog.BackColor = System.Drawing.SystemColors.Control;
            this.TPLog.Controls.Add(this.groupBox2);
            this.TPLog.Location = new System.Drawing.Point(4, 25);
            this.TPLog.Margin = new System.Windows.Forms.Padding(4);
            this.TPLog.Name = "TPLog";
            this.TPLog.Padding = new System.Windows.Forms.Padding(4);
            this.TPLog.Size = new System.Drawing.Size(815, 173);
            this.TPLog.TabIndex = 3;
            this.TPLog.Text = "Error log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CBShowErrorLog);
            this.groupBox2.Location = new System.Drawing.Point(8, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(268, 161);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logging";
            // 
            // CBShowErrorLog
            // 
            this.CBShowErrorLog.AutoSize = true;
            this.CBShowErrorLog.Location = new System.Drawing.Point(8, 23);
            this.CBShowErrorLog.Margin = new System.Windows.Forms.Padding(4);
            this.CBShowErrorLog.Name = "CBShowErrorLog";
            this.CBShowErrorLog.Size = new System.Drawing.Size(115, 20);
            this.CBShowErrorLog.TabIndex = 0;
            this.CBShowErrorLog.Text = "Show error log";
            this.CBShowErrorLog.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 226);
            this.Controls.Add(this.TCMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exif to filename";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.TCMain.ResumeLayout(false);
            this.TPFilenames.ResumeLayout(false);
            this.TPFilenames.PerformLayout();
            this.TPAdvanced.ResumeLayout(false);
            this.GBVariables.ResumeLayout(false);
            this.GBNoExif.ResumeLayout(false);
            this.GBNoExif.PerformLayout();
            this.GBExifFilenames.ResumeLayout(false);
            this.GBExifFilenames.PerformLayout();
            this.TPLog.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.TabPage TPFilenames;
        private System.Windows.Forms.TabPage TPAdvanced;
        private UCtrlSelectPath SPDestination;
        private UCtrlSelectPath SPSource;
        private System.Windows.Forms.GroupBox GBVariables;
        private System.Windows.Forms.ListBox LBVariables;
        private System.Windows.Forms.GroupBox GBNoExif;
        private System.Windows.Forms.TextBox TBNoExifFilename;
        private System.Windows.Forms.GroupBox GBExifFilenames;
        private System.Windows.Forms.TextBox TBExifFilename;
        private System.Windows.Forms.CheckBox CBCreateDaySubDirectory;
        private System.Windows.Forms.Button BGo;
        private System.Windows.Forms.TextBox TBForepart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TPLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CBShowErrorLog;
        private System.Windows.Forms.CheckBox CBIgnoreSubfolder;
        private System.Windows.Forms.TextBox TBDupSubFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CBMoveMode;
        private System.Windows.Forms.CheckBox CBMoveDuplicates;
    }
}

