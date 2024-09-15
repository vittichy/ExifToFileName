/*
 
 * 2007-07
 *  - zda se funkcni :-)
 * 
 * 2007-08 
 *  - bylo by potreba pridant promennou %millisecond% - pri foceni na seriove snimky se bezne vejde vic fotek do sekundy,
 *    ale fotak udava v exifu maximalne sekundy :-/  
 * 
 * 2007
 *  [+] pridany promenne %dayname% a %daynameshort%
 * 
 * 2009-12
 *  [+] pouzit BackgroundWorker, funkcionalita presunuta do druheho formu
 *  [*] Vt* tridy presunuty natvrdo do tohoto projektu
 *  [+] spatne jpeg soubory, co nejdou nacist, skladam do adresare !bad_files!
 *  
 * 2010-01
 *  [-] !!! zapomenute zpomaleni ve smycce backgroundworkera !!
 *  [+] pridano zobrazovani logu s chybami pri nacitani JPEGu
 *  [-] vsechny formu pod jednu ikonu 
 *  
 * 2010-07
 *  [-] chyba v rozpoznavani duplicit, pokud jich bylo vice !
 *  [+] duplicity se kopiruji do spec. folderu 
 *  
 * 2014-07
 *  [+] podpora pro NAR soubory, coz je vlastne zip s nekolika snimky z fotaku Nokia Lumia
 *  
 *  
 *  2024-09
 *  [-] vyhodit NAR - je to jen pozustatek od NOKIA telefonu
 *      - budu nacitat jen podporovane typy souboru, ostatni do unknown (TODO co videa?)
 *  
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.IO;

using Vt.Jpeg;
using Vt.JpegExifConstants;
using Vt.XmlConfig;


namespace ExifToFileName
{
    // Lookup "Table" with States for the Combobox
    public struct ExifDateTag
    {
        private PropertyTagId PTagId;
        private bool UseTag;

        public ExifDateTag(PropertyTagId PTagId, bool UseTag)
        {
            this.PTagId = PTagId;
            this.UseTag = UseTag;
        }
        public override string ToString()
        {
            return TagName;
        }
        public string TagNo { get { return PTagId.ToString(); } }
        public string TagName { get { return PTagId.ToString(); } }
        public bool Use { get { return UseTag; } }
    }



    public partial class FrmMain : Form
    {
        const string PRG_CAPTION = "Exif to filename (2014-07) v8";

        private ExifDateTag[] ExifDateTags = new ExifDateTag[] 
		{
            new ExifDateTag(PropertyTagId.DateTimeOriginal, true),
            new ExifDateTag(PropertyTagId.DateTimeDigitized, true),
            new ExifDateTag(PropertyTagId.DateTime, true),
        };


        public FrmMain()
        {
            InitializeComponent();

            Text = PRG_CAPTION;

            ReadXmlConfig();

            EnableActions();
        }


        private void EnableActions()
        {
            // TODO folder exists?

            BGo.Enabled = (SPDestination.SelectedFolder.Trim() != "") &
                          (SPSource.SelectedFolder.Trim() != "") &
                          (TBNoExifFilename.Text.Trim() != "") &
                          (TBExifFilename.Text.Trim() != "");

            BUp.Enabled   = (LBExifDates.SelectedIndex > -1) & (LBExifDates.Items.Count > 0) & (LBExifDates.SelectedIndex > 0);
            BDown.Enabled = (LBExifDates.SelectedIndex > -1) & (LBExifDates.Items.Count > 0) & (LBExifDates.SelectedIndex < (LBExifDates.Items.Count - 1));
        }

        private void SPSource_OnSelectedFolderChange(object sender, EventArgs e)
        {
            EnableActions();
        }

        private void SPDestination_OnSelectedFolderChange(object sender, EventArgs e)
        {
            EnableActions();
        }

        // zmena na CheckedListBoxu - jinymi eventy to nezjistim !
        private void ChLBExtensions_KeyUp(object sender, KeyEventArgs e)
        {
            EnableActions();
        }
        private void ChLBExtensions_MouseUp(object sender, MouseEventArgs e)
        {
            EnableActions();
        }
        
        
        
        private void BGo_Click(object sender, EventArgs e)
        {
            // objekt pro prenost parametru do druheho formulare
            LinkClass LinkParams = CreateLink();

            // spusteni procesu ve vlaknu background workera
            FrmBGProcess BGProcess = new FrmBGProcess();
            DialogResult DResult = BGProcess.ShowDialog(this, LinkParams);
        }



        // objekt pro prenos parametru do druheho formulare
        private LinkClass CreateLink()
        {
            // seznam preferovanych exif datumu
            ArrayList PreferExifDate = new ArrayList(LBExifDates.Items);

            return new LinkClass(
                            SPSource.SelectedFolder,
                            SPDestination.SelectedFolder,
                            TBForepart.Text,
                            TBExifFilename.Text,
                            TBNoExifFilename.Text,
                            TBDupSubFolder.Text.Trim(),
                            CBMoveMode.Checked,
                            CBMoveDuplicates.Checked,
                            CBCreateDaySubDirectory.Checked, 
                            PreferExifDate,
                            CBShowErrorLog.Checked,
                            CBIgnoreSubfolder.Checked);
        }



        private string GetXmlCfgFileName()
        {
            return AppDomain.CurrentDomain.FriendlyName + ".cfg.xml";
        }



        private void ReadXmlConfig()
        {
            XmlConfig XCfg = new XmlConfig();
            XCfg.Load(GetXmlCfgFileName());
            SPSource.SelectedFolder = XCfg.GetString("SourcePath", SPSource.SelectedFolder);
            SPDestination.SelectedFolder = XCfg.GetString("DestinationPath", SPDestination.SelectedFolder);
            TBForepart.Text = XCfg.GetString("Forepart", TBForepart.Text);
            TBExifFilename.Text = XCfg.GetString("ExifFilename", TBExifFilename.Text);
            TBNoExifFilename.Text = XCfg.GetString("NoExifFilename", TBNoExifFilename.Text);
            CBCreateDaySubDirectory.Checked = XCfg.GetBool("CreateDaySubDirectory", true);
			CBIgnoreSubfolder.Checked = XCfg.GetBool("IgnoreSubfolder", true);

            // exif list box
            XCfg.GetListBox("PreferedExifDateTimeTag", ref LBExifDates);
            if (LBExifDates.Items.Count <= 0) // pokud by se z XML nic nenacetlo, tak nahraju defaultni hodnoty
                SetLBExifDateTags();

            // [vt] 01-2010
            CBShowErrorLog.Checked = XCfg.GetBool("CBShowErrorLog", true);

            // 07-2011
            TBDupSubFolder.Text = XCfg.GetString("DupSubFolder", TBDupSubFolder.Text);
            CBMoveMode.Checked = XCfg.GetBool("MoveMode", CBMoveMode.Checked);
            CBMoveDuplicates.Checked = XCfg.GetBool("MoveDuplicates", CBMoveDuplicates.Checked);

            // eventy po nahrani konfigurace
            CBMoveDuplicates_CheckedChanged(null, null);
        }


        private void SetLBExifDateTags()
        {
            LBExifDates.Items.Clear();
            LBExifDates.Items.Add(PropertyTagId.DateTimeOriginal.ToString());
            LBExifDates.Items.Add(PropertyTagId.DateTimeDigitized.ToString());
            LBExifDates.Items.Add(PropertyTagId.DateTime.ToString());
            LBExifDates.SelectedIndex = 0;
        }

        private void SaveXmlConfig()
        {
            XmlConfig XCfg = new XmlConfig();
            XCfg.Load(GetXmlCfgFileName());

            XCfg.SetString("SourcePath", SPSource.SelectedFolder.Trim());
            XCfg.SetString("DestinationPath", SPDestination.SelectedFolder.Trim());
            XCfg.SetString("Forepart", TBForepart.Text.Trim());
            XCfg.SetString("ExifFilename", TBExifFilename.Text.Trim());
            XCfg.SetString("NoExifFilename", TBNoExifFilename.Text.Trim());
            XCfg.SetBool("CreateDaySubDirectory", CBCreateDaySubDirectory.Checked);
			XCfg.SetListBox("PreferedExifDateTimeTag", ref LBExifDates);
            // [vt] 01-2010
            XCfg.SetBool("CBShowErrorLog", CBShowErrorLog.Checked);
            XCfg.SetBool("IgnoreSubfolder", CBIgnoreSubfolder.Checked);
            // 07-2011
            XCfg.SetString("DupSubFolder", TBDupSubFolder.Text.Trim());
            XCfg.SetBool("MoveMode", CBMoveMode.Checked);
            XCfg.SetBool("MoveDuplicates", CBMoveDuplicates.Checked);

            XCfg.Save(GetXmlCfgFileName());
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveXmlConfig();
        }


        private void LBExifDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableActions();
        }

        private void SwapItems(ref ListBox LBox, int a, int b)
        {
            string AItem = LBox.Items[a].ToString();
            LBox.Items[a] = LBox.Items[b].ToString();
            LBox.Items[b] = AItem;
            LBox.SelectedIndex = a;
        }

        private void BUp_Click(object sender, EventArgs e)
        {
            if ((LBExifDates.SelectedIndex > -1) & (LBExifDates.SelectedIndex > 0))
            {
                SwapItems(ref LBExifDates, LBExifDates.SelectedIndex - 1, LBExifDates.SelectedIndex);
            }
        }

        private void BDown_Click(object sender, EventArgs e)
        {
            if ((LBExifDates.SelectedIndex > -1) & (LBExifDates.SelectedIndex < (LBExifDates.Items.Count - 1)))
            {
                SwapItems(ref LBExifDates, LBExifDates.SelectedIndex + 1, LBExifDates.SelectedIndex);
            }
        }

        private void LBVariables_MouseDown(object sender, MouseEventArgs e)
        {
            int IndexOfItem = LBVariables.IndexFromPoint(e.X, e.Y);
            if ((IndexOfItem >= 0) && (IndexOfItem < LBVariables.Items.Count))  
            {
                // Set allowed DragDropEffect to Copy selected 
                // from DragDropEffects enumberation of None, Move, All etc.
                LBVariables.DoDragDrop(LBVariables.Items[IndexOfItem], DragDropEffects.Copy);
            }
        }

        private void TBExifFilename_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                (sender as TextBox).Text += e.Data.GetData(DataFormats.Text);
        }

        private void TBExifFilename_DragEnter(object sender, DragEventArgs e)
        {
            // change the drag cursor to show valid data ready
            if (e.Data.GetDataPresent(DataFormats.StringFormat) && (e.AllowedEffect == DragDropEffects.Copy))
                e.Effect = DragDropEffects.Copy;
        }

        private void LBVariables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBMoveDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            TBDupSubFolder.Enabled = CBMoveDuplicates.Checked;
        }

		private void ChLBExtensions_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

    }
}