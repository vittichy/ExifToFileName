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
			this.label2 = new System.Windows.Forms.Label();
			this.ChLBExtensions = new System.Windows.Forms.CheckedListBox();
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
			this.TPExifDate = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.BDown = new System.Windows.Forms.Button();
			this.BUp = new System.Windows.Forms.Button();
			this.LBExifDates = new System.Windows.Forms.ListBox();
			this.TPLog = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.CBShowErrorLog = new System.Windows.Forms.CheckBox();
			this.TCMain.SuspendLayout();
			this.TPFilenames.SuspendLayout();
			this.TPAdvanced.SuspendLayout();
			this.GBVariables.SuspendLayout();
			this.GBNoExif.SuspendLayout();
			this.GBExifFilenames.SuspendLayout();
			this.TPExifDate.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			this.TCMain.Controls.Add(this.TPExifDate);
			this.TCMain.Controls.Add(this.TPLog);
			this.TCMain.Location = new System.Drawing.Point(9, 12);
			this.TCMain.Name = "TCMain";
			this.TCMain.SelectedIndex = 0;
			this.TCMain.Size = new System.Drawing.Size(617, 164);
			this.TCMain.TabIndex = 0;
			// 
			// TPFilenames
			// 
			this.TPFilenames.BackColor = System.Drawing.SystemColors.Control;
			this.TPFilenames.Controls.Add(this.CBMoveDuplicates);
			this.TPFilenames.Controls.Add(this.CBMoveMode);
			this.TPFilenames.Controls.Add(this.TBDupSubFolder);
			this.TPFilenames.Controls.Add(this.label3);
			this.TPFilenames.Controls.Add(this.label2);
			this.TPFilenames.Controls.Add(this.ChLBExtensions);
			this.TPFilenames.Controls.Add(this.TBForepart);
			this.TPFilenames.Controls.Add(this.label1);
			this.TPFilenames.Controls.Add(this.BGo);
			this.TPFilenames.Controls.Add(this.SPDestination);
			this.TPFilenames.Controls.Add(this.SPSource);
			this.TPFilenames.Location = new System.Drawing.Point(4, 22);
			this.TPFilenames.Name = "TPFilenames";
			this.TPFilenames.Padding = new System.Windows.Forms.Padding(3);
			this.TPFilenames.Size = new System.Drawing.Size(609, 138);
			this.TPFilenames.TabIndex = 0;
			this.TPFilenames.Text = "Paths";
			// 
			// CBMoveDuplicates
			// 
			this.CBMoveDuplicates.AutoSize = true;
			this.CBMoveDuplicates.Location = new System.Drawing.Point(113, 62);
			this.CBMoveDuplicates.Name = "CBMoveDuplicates";
			this.CBMoveDuplicates.Size = new System.Drawing.Size(133, 17);
			this.CBMoveDuplicates.TabIndex = 102;
			this.CBMoveDuplicates.Text = "Copy\\Move duplicates";
			this.CBMoveDuplicates.UseVisualStyleBackColor = true;
			this.CBMoveDuplicates.CheckedChanged += new System.EventHandler(this.CBMoveDuplicates_CheckedChanged);
			// 
			// CBMoveMode
			// 
			this.CBMoveMode.AutoSize = true;
			this.CBMoveMode.Location = new System.Drawing.Point(12, 62);
			this.CBMoveMode.Name = "CBMoveMode";
			this.CBMoveMode.Size = new System.Drawing.Size(82, 17);
			this.CBMoveMode.TabIndex = 101;
			this.CBMoveMode.Text = "Move mode";
			this.CBMoveMode.UseVisualStyleBackColor = true;
			// 
			// TBDupSubFolder
			// 
			this.TBDupSubFolder.Location = new System.Drawing.Point(113, 84);
			this.TBDupSubFolder.Name = "TBDupSubFolder";
			this.TBDupSubFolder.Size = new System.Drawing.Size(168, 20);
			this.TBDupSubFolder.TabIndex = 20;
			this.TBDupSubFolder.Text = "_duplicates";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Duplicates subfolder";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(296, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Extension ";
			// 
			// ChLBExtensions
			// 
			this.ChLBExtensions.FormattingEnabled = true;
			this.ChLBExtensions.Items.AddRange(new object[] {
            "jpg",
            "jpeg",
            "nar"});
			this.ChLBExtensions.Location = new System.Drawing.Point(354, 66);
			this.ChLBExtensions.Name = "ChLBExtensions";
			this.ChLBExtensions.Size = new System.Drawing.Size(65, 64);
			this.ChLBExtensions.TabIndex = 40;
			this.ChLBExtensions.SelectedIndexChanged += new System.EventHandler(this.ChLBExtensions_SelectedIndexChanged);
			this.ChLBExtensions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChLBExtensions_KeyUp);
			this.ChLBExtensions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChLBExtensions_MouseUp);
			// 
			// TBForepart
			// 
			this.TBForepart.Location = new System.Drawing.Point(113, 112);
			this.TBForepart.Name = "TBForepart";
			this.TBForepart.Size = new System.Drawing.Size(168, 20);
			this.TBForepart.TabIndex = 30;
			this.TBForepart.Text = "Forepart";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Filename forepart";
			// 
			// BGo
			// 
			this.BGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.BGo.Location = new System.Drawing.Point(428, 66);
			this.BGo.Name = "BGo";
			this.BGo.Size = new System.Drawing.Size(175, 66);
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
			this.SPDestination.Location = new System.Drawing.Point(6, 35);
			this.SPDestination.Name = "SPDestination";
			this.SPDestination.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.SPDestination.SelectedFolder = "";
			this.SPDestination.ShowNewFolderButton = false;
			this.SPDestination.Size = new System.Drawing.Size(597, 20);
			this.SPDestination.TabIndex = 1;
			this.SPDestination.OnSelectedFolderChange += new System.EventHandler(this.SPDestination_OnSelectedFolderChange);
			// 
			// SPSource
			// 
			this.SPSource.Caption = "Source";
			this.SPSource.CaptionTextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.SPSource.CaptionWidth = 66;
			this.SPSource.Location = new System.Drawing.Point(6, 8);
			this.SPSource.Name = "SPSource";
			this.SPSource.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.SPSource.SelectedFolder = "";
			this.SPSource.ShowNewFolderButton = false;
			this.SPSource.Size = new System.Drawing.Size(597, 20);
			this.SPSource.TabIndex = 0;
			this.SPSource.OnSelectedFolderChange += new System.EventHandler(this.SPSource_OnSelectedFolderChange);
			// 
			// TPAdvanced
			// 
			this.TPAdvanced.BackColor = System.Drawing.SystemColors.Control;
			this.TPAdvanced.Controls.Add(this.GBVariables);
			this.TPAdvanced.Controls.Add(this.GBNoExif);
			this.TPAdvanced.Controls.Add(this.GBExifFilenames);
			this.TPAdvanced.Location = new System.Drawing.Point(4, 22);
			this.TPAdvanced.Name = "TPAdvanced";
			this.TPAdvanced.Padding = new System.Windows.Forms.Padding(3);
			this.TPAdvanced.Size = new System.Drawing.Size(609, 138);
			this.TPAdvanced.TabIndex = 1;
			this.TPAdvanced.Text = "Advanced";
			// 
			// GBVariables
			// 
			this.GBVariables.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.GBVariables.Controls.Add(this.LBVariables);
			this.GBVariables.Location = new System.Drawing.Point(490, 10);
			this.GBVariables.Name = "GBVariables";
			this.GBVariables.Size = new System.Drawing.Size(111, 118);
			this.GBVariables.TabIndex = 13;
			this.GBVariables.TabStop = false;
			this.GBVariables.Text = "Variables";
			// 
			// LBVariables
			// 
			this.LBVariables.FormattingEnabled = true;
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
			this.LBVariables.Location = new System.Drawing.Point(6, 19);
			this.LBVariables.Name = "LBVariables";
			this.LBVariables.Size = new System.Drawing.Size(99, 95);
			this.LBVariables.TabIndex = 50;
			this.LBVariables.SelectedIndexChanged += new System.EventHandler(this.LBVariables_SelectedIndexChanged);
			this.LBVariables.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LBVariables_MouseDown);
			// 
			// GBNoExif
			// 
			this.GBNoExif.Controls.Add(this.TBNoExifFilename);
			this.GBNoExif.Location = new System.Drawing.Point(6, 81);
			this.GBNoExif.Name = "GBNoExif";
			this.GBNoExif.Size = new System.Drawing.Size(478, 47);
			this.GBNoExif.TabIndex = 12;
			this.GBNoExif.TabStop = false;
			this.GBNoExif.Text = "No exif filename";
			// 
			// TBNoExifFilename
			// 
			this.TBNoExifFilename.AllowDrop = true;
			this.TBNoExifFilename.Location = new System.Drawing.Point(7, 19);
			this.TBNoExifFilename.Name = "TBNoExifFilename";
			this.TBNoExifFilename.Size = new System.Drawing.Size(465, 20);
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
			this.GBExifFilenames.Location = new System.Drawing.Point(6, 6);
			this.GBExifFilenames.Name = "GBExifFilenames";
			this.GBExifFilenames.Size = new System.Drawing.Size(478, 69);
			this.GBExifFilenames.TabIndex = 11;
			this.GBExifFilenames.TabStop = false;
			this.GBExifFilenames.Text = "Exif filename";
			// 
			// CBIgnoreSubfolder
			// 
			this.CBIgnoreSubfolder.AutoSize = true;
			this.CBIgnoreSubfolder.Location = new System.Drawing.Point(189, 45);
			this.CBIgnoreSubfolder.Name = "CBIgnoreSubfolder";
			this.CBIgnoreSubfolder.Size = new System.Drawing.Size(146, 17);
			this.CBIgnoreSubfolder.TabIndex = 30;
			this.CBIgnoreSubfolder.Text = "Ignore original sub-folders";
			this.CBIgnoreSubfolder.UseVisualStyleBackColor = true;
			// 
			// TBExifFilename
			// 
			this.TBExifFilename.AllowDrop = true;
			this.TBExifFilename.Location = new System.Drawing.Point(7, 19);
			this.TBExifFilename.Name = "TBExifFilename";
			this.TBExifFilename.Size = new System.Drawing.Size(465, 20);
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
			this.CBCreateDaySubDirectory.Location = new System.Drawing.Point(7, 45);
			this.CBCreateDaySubDirectory.Name = "CBCreateDaySubDirectory";
			this.CBCreateDaySubDirectory.Size = new System.Drawing.Size(142, 17);
			this.CBCreateDaySubDirectory.TabIndex = 20;
			this.CBCreateDaySubDirectory.Text = "Create DAY subdirectory";
			this.CBCreateDaySubDirectory.UseVisualStyleBackColor = true;
			// 
			// TPExifDate
			// 
			this.TPExifDate.BackColor = System.Drawing.SystemColors.Control;
			this.TPExifDate.Controls.Add(this.groupBox1);
			this.TPExifDate.Location = new System.Drawing.Point(4, 22);
			this.TPExifDate.Name = "TPExifDate";
			this.TPExifDate.Padding = new System.Windows.Forms.Padding(3);
			this.TPExifDate.Size = new System.Drawing.Size(609, 138);
			this.TPExifDate.TabIndex = 2;
			this.TPExifDate.Text = "Exif date";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BDown);
			this.groupBox1.Controls.Add(this.BUp);
			this.groupBox1.Controls.Add(this.LBExifDates);
			this.groupBox1.Location = new System.Drawing.Point(6, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(222, 131);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Prefered exif datetime tag";
			// 
			// BDown
			// 
			this.BDown.Location = new System.Drawing.Point(166, 102);
			this.BDown.Name = "BDown";
			this.BDown.Size = new System.Drawing.Size(49, 23);
			this.BDown.TabIndex = 5;
			this.BDown.Text = "Down";
			this.BDown.UseVisualStyleBackColor = true;
			this.BDown.Click += new System.EventHandler(this.BDown_Click);
			// 
			// BUp
			// 
			this.BUp.Location = new System.Drawing.Point(166, 19);
			this.BUp.Name = "BUp";
			this.BUp.Size = new System.Drawing.Size(49, 23);
			this.BUp.TabIndex = 4;
			this.BUp.Text = "Up";
			this.BUp.UseVisualStyleBackColor = true;
			this.BUp.Click += new System.EventHandler(this.BUp_Click);
			// 
			// LBExifDates
			// 
			this.LBExifDates.FormattingEnabled = true;
			this.LBExifDates.IntegralHeight = false;
			this.LBExifDates.Location = new System.Drawing.Point(10, 19);
			this.LBExifDates.Name = "LBExifDates";
			this.LBExifDates.Size = new System.Drawing.Size(150, 106);
			this.LBExifDates.TabIndex = 2;
			this.LBExifDates.SelectedIndexChanged += new System.EventHandler(this.LBExifDates_SelectedIndexChanged);
			// 
			// TPLog
			// 
			this.TPLog.BackColor = System.Drawing.SystemColors.Control;
			this.TPLog.Controls.Add(this.groupBox2);
			this.TPLog.Location = new System.Drawing.Point(4, 22);
			this.TPLog.Name = "TPLog";
			this.TPLog.Padding = new System.Windows.Forms.Padding(3);
			this.TPLog.Size = new System.Drawing.Size(609, 138);
			this.TPLog.TabIndex = 3;
			this.TPLog.Text = "Error log";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.CBShowErrorLog);
			this.groupBox2.Location = new System.Drawing.Point(6, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(201, 131);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Logging";
			// 
			// CBShowErrorLog
			// 
			this.CBShowErrorLog.AutoSize = true;
			this.CBShowErrorLog.Location = new System.Drawing.Point(6, 19);
			this.CBShowErrorLog.Name = "CBShowErrorLog";
			this.CBShowErrorLog.Size = new System.Drawing.Size(94, 17);
			this.CBShowErrorLog.TabIndex = 0;
			this.CBShowErrorLog.Text = "Show error log";
			this.CBShowErrorLog.UseVisualStyleBackColor = true;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(636, 184);
			this.Controls.Add(this.TCMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
			this.TPExifDate.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckedListBox ChLBExtensions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage TPExifDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LBExifDates;
        private System.Windows.Forms.BindingSource exifDateTagBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button BDown;
        private System.Windows.Forms.Button BUp;
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

