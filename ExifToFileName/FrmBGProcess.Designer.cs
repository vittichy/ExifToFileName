namespace ExifToFileName
{
    partial class FrmBGProcess
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
            this.BStop = new System.Windows.Forms.Button();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.LProcessMessage = new System.Windows.Forms.Label();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // BStop
            // 
            this.BStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BStop.Location = new System.Drawing.Point(459, 11);
            this.BStop.Name = "BStop";
            this.BStop.Size = new System.Drawing.Size(144, 40);
            this.BStop.TabIndex = 0;
            this.BStop.Text = "S t o p";
            this.BStop.UseVisualStyleBackColor = true;
            this.BStop.Click += new System.EventHandler(this.BStop_Click);
            // 
            // PBar
            // 
            this.PBar.Location = new System.Drawing.Point(12, 12);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(441, 23);
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 1;
            // 
            // LProcessMessage
            // 
            this.LProcessMessage.Location = new System.Drawing.Point(12, 40);
            this.LProcessMessage.Name = "LProcessMessage";
            this.LProcessMessage.Size = new System.Drawing.Size(441, 23);
            this.LProcessMessage.TabIndex = 2;
            this.LProcessMessage.Text = "LProcessMessage";
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerReportsProgress = true;
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorker_ProgressChanged);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // FrmBGProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 60);
            this.Controls.Add(this.LProcessMessage);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.BStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBGProcess";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Process ...";
            this.Shown += new System.EventHandler(this.FrmBGProcess_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BStop;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.Label LProcessMessage;
        private System.ComponentModel.BackgroundWorker BGWorker;
    }
}