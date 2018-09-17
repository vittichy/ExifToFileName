using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ExifToFileName
{
    public partial class UCtrlSelectPath : UserControl
    {
        private bool _ShowNewFolderButton = false;
        private bool _AutoSizeCaption = true;
        private Environment.SpecialFolder _RootFolder = Environment.SpecialFolder.MyComputer;


        public UCtrlSelectPath()
        {
            InitializeComponent();
        }

        private void BSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();
            FBDialog.SelectedPath = TBSelectedName.Text.Trim();
            FBDialog.RootFolder = _RootFolder;
            FBDialog.ShowNewFolderButton = _ShowNewFolderButton;
            if(FBDialog.ShowDialog() == DialogResult.OK)
                TBSelectedName.Text = FBDialog.SelectedPath;
        }

        [Browsable(true)] /* ! umozni editaci v designerovi ! */
        public string SelectedFolder
        {
            get { return TBSelectedName.Text.Trim(); }
            set { TBSelectedName.Text = value; }
        }

        [Browsable(true)]
        public Environment.SpecialFolder RootFolder
        {
            get { return _RootFolder; }
            set { _RootFolder = value; }
        }

        [Browsable(true)]
        public bool ShowNewFolderButton
        {
            get { return _ShowNewFolderButton; }
            set { _ShowNewFolderButton = value; }
        }

        [Browsable(true)]
        public string Caption
        {
            get { return LDescription.Text; }
            set { LDescription.Text = value; }
        }

        [Browsable(true)]
        public ContentAlignment CaptionTextAlign
        {
            get { return LDescription.TextAlign; }
            set { LDescription.TextAlign = value; }
        }

        // nastaveni sirky labelu - o co je delsi, o to vic se zkracuje TextBox ! musim ho prepocist rucne !
        [Browsable(true)]
        public int CaptionWidth
        {
            get 
            { 
                return LDescription.Width; 
            }
            set 
            { 
                LDescription.Width = value;
                // nova sirka TextBoxu, ktery se musi zmenit dle nove Width labelu
                ResizeTextBox();
            }
        }

        // nova sirka TextBoxu
        private void ResizeTextBox()
        {
            TBSelectedName.Width = Width - LDescription.Width - BSelectPath.Width - TBSelectedName.Margin.Left - TBSelectedName.Margin.Right;
        }

        // pri resize Controlu musim prepocitat TextBox, ktery vyplnuje prostredek Controlu mezi Labelem
        // a Buttonkem 
        private void UCtrlSelectPath_Resize(object sender, EventArgs e)
        {
            ResizeTextBox();
        }

        private void UCtrlSelectPath_BackColorChanged(object sender, EventArgs e)
        {
            LDescription.BackColor = BackColor;
        }



        [Browsable(true)]
        public event EventHandler OnSelectedFolderChange;

        private void TBSelectedName_TextChanged(object sender, EventArgs e)
        {
            if (OnSelectedFolderChange != null)
                OnSelectedFolderChange(sender, e);
        }


        


    }
}
