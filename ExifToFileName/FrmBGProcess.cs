using MetadataExtractor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vt.Common;


namespace ExifToFileName
{
    public partial class FrmBGProcess : Form
    {
        private LinkClass LinkParams;
        
        /// <summary>
        /// Seznam chyb pri nacitani JPEGu
        /// </summary>
        private string ErrorLog = "";
        
        /// <summary>
        /// Vyhledavani duplicit
        /// </summary>
        List<FileProp> CRCList = new List<FileProp>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public FrmBGProcess()
        {
            InitializeComponent();
            // na startu prazdny text
            LProcessMessage.Text = "";
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        public new DialogResult ShowDialog(IWin32Window owner, LinkClass LinkParams)
        {
            this.LinkParams = LinkParams;
            return base.ShowDialog(owner);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // zobrazeni formu = start procesu
        //
        private void FrmBGProcess_Shown(object sender, EventArgs e)
        {
            BGWorker.RunWorkerAsync();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // hlaseni o postupu procesu
        //
        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // TODO CheckPaths(LinkParams.SourceRoot, LinkParams.DestinationRoot);

            // zkratka na aktualne rozhety BGWorker
            BackgroundWorker AWorker = (sender as BackgroundWorker);

            // metoda nemusi byt zabalena v try-catch ->
            // If the operation raises an exception that your code does not handle, the BackgroundWorker 
            // catches the exception and passes it into the RunWorkerCompleted event handler, where it is 
            // exposed as the Error property of System.ComponentModel..::.RunWorkerCompletedEventArgs. If 
            // you are running under the Visual Studio debugger, the debugger will break at the point in 
            // the DoWork event handler where the unhandled exception was raised. If you have more than one 
            // BackgroundWorker, you should not reference any of them directly, as this would couple your 
            // DoWork event handler to a specific instance of BackgroundWorker. Instead, you should access 
            // your BackgroundWorker by casting the sender parameter in your DoWork event handler.

            // nacteni seznamu souboru
            AWorker.ReportProgress(0, "Searching for files...");

			// seznam adresaru, koncicich mezerami ... ty .net neumi zpracovat :-/ otrimuje je a pak hlasi, ze neexistuji :-)
			var ErrorPaths = new List<string>();
            var Files = VtIO.GetAllFilesEx(LinkParams.SourceRoot, "*.*", ref ErrorPaths); 
			if (ErrorPaths.Count > 0)
			{
				foreach (string err in ErrorPaths)
				{ }
			}

            DateTime StartTime = DateTime.Now;

            // seznam jiz vygenerovanych jmen souboru - napr. nektere fotky maji blby exif datum 1.1.1900 a jsou-li ve stejnem 
            // adresari, tak by se soubory prepisovaly (meli by vygenerovany stejny jmeno), tak si je musim pamatovat a pripadne
            // k nim neco pridam
            ArrayList PicFileNames = new ArrayList();
            int PicCount = 0;
            int NoExifCount = 0;

            // proces nad vsemi soubory
            int i = 0;
            foreach (string FileName in Files)
            {
                // prubeh procesu do pgbaru + labelu => reportuju v %
                int Ratio = (++i * 100) / Files.Count;
                AWorker.ReportProgress(Ratio, UserMsg(FileName, Files.Count, PicCount + 1, NoExifCount, StartTime));

                // TODO check known filetype (JPEG, HEIC???...)

                // zpracovani 1.souboru normalniho Jpeg apod souboru
                ProccessFile(
                            FileName, 
                            LinkParams.SourceRoot,
                            LinkParams.DestinationRoot,
                            LinkParams.Forepart,
                            LinkParams.ExifKey,
                            LinkParams.NoExifKey,
                            LinkParams.DupFolder,
                            LinkParams.MoveMode,
                            LinkParams.MoveDuplicates,
                            LinkParams.CreateDayDirectory,
                            LinkParams.IgnoreSubfolder,
                            ref PicCount, ref NoExifCount, ref PicFileNames, ref ErrorLog);

                // nebyl zmacknut cancel ??
                if (AWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void CheckPaths(string sourceRoot, string destinationRoot)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // hlaseni o postupu procesu
        //
        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // procenta => omezeni proti preteceni
            if (e.ProgressPercentage > PBar.Maximum)
                PBar.Value = PBar.Maximum;
            else 
                PBar.Value = e.ProgressPercentage;

            // hlaseni v labelu pod progressbarem
            if (e.UserState is string)
                if (!string.IsNullOrEmpty(e.UserState as string))
                    LProcessMessage.Text = (string)e.UserState;

            // LProcessMessage.Text = this.Handle.ToString();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // konec behu vlakna - prerusenni, vyjimka nebo opravdovy konec
        //
        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) {
                MessageBox.Show(this, "The task has been cancelled.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }  
            else if (e.Error != null)  
            {
                MessageBox.Show(this, "Details: " + Environment.NewLine + (e.Error as Exception).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }  
            else 
            {  
                // zobrazit okno s chybama ?
                if ((LinkParams.ShowErrorLog) && (!string.IsNullOrEmpty(this.ErrorLog)))
                {
                    FrmErrorLog FrmELog = new FrmErrorLog();
                    FrmELog.ShowDialog(this, ErrorLog);
                }
                
                // koncove hlaseni dle toho zda byly nejake chyby v JPEGach
                string Msg;        
                if (string.IsNullOrEmpty(this.ErrorLog))
                {
                    // bez chyb
                    Msg = "   All ok.   ";
                }
                else
                {
                    // nejake chyby
                    Msg = "Ok, but some JPEG errors occurred while processing task.";
                }
                MessageBox.Show(this, Msg, "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // stop tlacitko
        //
        private void BStop_Click(object sender, EventArgs e)
        {
            BGWorker.CancelAsync();
            BStop.Enabled = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // stop tlacitko
        //
        private string UserMsg(string FileName, int FilesCount, int PicCount, int NoExifCount, DateTime StartTime)
        {
            // cas od zacatku
            TimeSpan ts = DateTime.Now - StartTime;
            // odhad casu do konce
            TimeSpan ts2 = new TimeSpan(ts.Ticks / PicCount * FilesCount);

            return string.Format("[{0}/{1}]  Time:{3}  Remaining:{4}   {2}", PicCount, FilesCount, Path.GetFileName(FileName), TimeSpanToStr(ts), TimeSpanToStr(ts2));
        }


        private string TimeSpanToStr(TimeSpan ts)
        {
            string Hours = AddZero(ts.Hours.ToString(), 2);
            string Minutes = AddZero(ts.Minutes.ToString(), 2);
            string Seconds = AddZero(ts.Seconds.ToString(), 2);
            return Hours + ":" + Minutes + ":" + Seconds;
        }

        /// <summary>
        /// Process file
        /// </summary>
        private bool ProccessFile(string SourceFileName,
                                  string SourceRoot,
                                  string DestRoot,
                                  string Forepart,
                                  string ExifKey,
                                  string NoExifKey,
                                  string DupFolder,
                                  bool MoveMode,
                                  bool MoveDuplicate,
                                  bool CBCreateDaySubDirectoryChecked,
                                  bool IgnoreSubfolder,
                                  ref int PicCount,
                                  ref int NoExifCount,
                                  ref ArrayList PicFileNames,
                                  ref string ErrorLog)
        {
            bool loadResult = false; // zda se povedl nacist soubor
            string NewFileName = "";

            // kvuli duplicitam
            FileProp fp = new FileProp(SourceFileName);

            DateTime? exifDate = null;
            string exifEquip;
            try
            {
                var exif = GetExifDateTime(SourceFileName);
                exifDate = exif.date;
                exifEquip = exif.equip;

                if (exifDate.HasValue)
                {
                    NewFileName = MakeExifFileName(ExifKey, Forepart, exifDate.Value, PicCount, NoExifCount, exifEquip, fp.DupCount);
                }
                else
                {
                    NewFileName = MakeExifFileName(NoExifKey, Forepart, DateTime.MinValue, PicCount, NoExifCount, "", fp.DupCount);
                }
                loadResult = true;
            }
            catch (Exception ex)
            {
            }

            // koncovka (obsahuje i tecku !)
            string Extension = Path.GetExtension(SourceFileName);
            // stara cesta bez filename
            string OldPath = Path.GetDirectoryName(SourceFileName);
            // source root ze slashem
            string SourceRootEx = AddSlash(SourceRoot);

            // novy adresar
            // nebrat v uvahu sub adresare a fotky sypat jen do day-adresare rovnou pod root ?
            string NewPath;
            if (IgnoreSubfolder)
            {
                NewPath = AddSlash(DestRoot);
            }
            else
            {
                // relativni kus cety
                string RelativePath = OldPath.Remove(0, SourceRootEx.Length - 1);
                NewPath = AddSlash(AddSlash(DestRoot) + KillFirstSlash(RelativePath));
            }

            // tvorit sub-adresare dle jednotlivych dni ??
            if (CBCreateDaySubDirectoryChecked)
            {
                string DaySubDir = MakeDaySubDirName(exifDate.HasValue ? exifDate.Value : DateTime.MinValue, loadResult, DupFolder, fp.DupCount);
                NewPath = AddSlash(NewPath + DaySubDir);
            }

            // cele finalni nove filename i s cestou
			string NewFileNameNoExt = AddSlash(NewPath) + NewFileName;
            NewFileName = AddSlash(NewPath) + NewFileName + Extension;

            if (File.Exists(NewFileName))
                NewFileName = GenerateExtendedFileName(NewFileNameNoExt, Extension);

            // Text = NewFileName; => ve vlaknu nejde (neplatna operace mezi procesy)
            if (MoveDuplicate || (fp.DupCount <= 0)) // kopirovat i duplikovane soubory ?? 
            {
                CopyFile(SourceFileName, NewFileName, NewPath, MoveMode);
            }
            PicCount++;
			if (!exifDate.HasValue)
			{
				NoExifCount++;
			}
            PicFileNames.Add(NewFileName);

            // pridam so seznamu CRC - kvuli duplicitnim souboru
            fp.NewFileName = NewFileName;
            CRCList.Add(fp);

            // posilam zpet vysledek nacteni souboru
            return loadResult;
        }

        private (DateTime? date, string equip) GetExifDateTime(string fileName)
        {
            var exif = ImageMetadataReader.ReadMetadata(fileName);
            if (exif == null) return (null, null);

            var exifTags = exif.SelectMany(p => p.Tags)
                                    .Where(p => p.DirectoryName == "Exif SubIFD"
                                             || p.DirectoryName == "Exif IFD0"
                                             || p.DirectoryName == "QuickTime Track Header")
                                        .ToList();
            // 2024:08:15 12:40:04
            var digitizedTag = GetTagDescription(exifTags, "Date/Time Digitized");
            var date = DateTime.TryParseExact(digitizedTag, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result) ? result : (DateTime?)null;

            if (!date.HasValue)
            {
                // zkusim rozparsovat divny format z quick time tagu
                // "st led 31 20:02:14 2024"
                var mp4DateTag = GetTagDescription(exifTags, "Created");
                // precod na parsovatelnejsi format
                var quickTime = QuickTimeHeaderTag(mp4DateTag);
                //"MM dd HH:mm:ss yyyy"
                date = DateTime.TryParseExact(quickTime,
                                                   "MM dd HH:mm:ss yyyy",
                                                   CultureInfo.InvariantCulture,
                                                   DateTimeStyles.None,
                                                   out result) ? result : (DateTime?)null;
            }

            var model = GetTagDescription(exifTags, "Model");
            var make = GetTagDescription(exifTags, "Make");
            var equip = $"{make?.Trim()} {model?.Trim()}".Trim();
            return (date, equip);

            string GetTagDescription(List<Tag> exifTagSet, string tagName)
            {
                return exifTagSet?.FirstOrDefault(p => p.Name == tagName)?.Description;
            }
        }

        /// <summary>
        /// Pokus o odstraneni ceskych divnosti z quicktime datoveho tagu
        /// </summary>
        private string QuickTimeHeaderTag(string source)
        {
            if (string.IsNullOrWhiteSpace(source) || source.Length < 4) return null;

            // "st led 31 20:02:14 2024"
            string[] czMohth = { "led", "úno", "bře", "dub", "kvě", "čvn", "čvc", "srp", "zář", "říj", "lis", "pro" };
            
            // vyhodit den v tydnu
            var result = source.Substring(3);

            // nahradit ceskou zkratku mesice za index ... led => 01
            for (int i = 0; i < czMohth.Length; i++)
            {
                if (result.Contains(czMohth[i]))
                {
                    result = result.Replace(czMohth[i], $"{i + 1:D2}");
                    break;
                }
            }
            return result;
        }

        private string GenerateExtendedFileName(string FileName, string Extension)
        {
            string Result = "";
            int i = 1;
            do
            {
                Result = string.Format("{0}.{1}{2}", FileName, i, Extension);
                i++;
            }
            while (File.Exists(Result));
            return Result;
        }

        private string MakeExifFileName(string Key, string Forepart, DateTime Date, int PicNumber, int NoExifNumber, string Equip, int Duplicates) 
        {
            string Year = AddZero(Date.Year.ToString(), 4);
            string Month = AddZero(Date.Month.ToString(), 2);
            string Day = AddZero(Date.Day.ToString(), 2);
            string Hour = AddZero(Date.Hour.ToString(), 2);
            string Min = AddZero(Date.Minute.ToString(), 2);
            string Sec = AddZero(Date.Second.ToString(), 2);
            string PicNum = AddZero(PicNumber.ToString(), 5);
            string NoExNum = AddZero(NoExifNumber.ToString(), 5);
            string DayName = Date.DayOfWeek.ToString();
            string DayNameShort = "";
			if (DayName.Length <= 3)
			{
				DayNameShort = DayName;
			}
			else
			{
				DayNameShort = DayName.Remove(3);
			}

            // vyrobce a model fotaku
            string Equip1 = "";
            string EquipFull = "";
            if (!string.IsNullOrEmpty(Equip))
            {
                Equip1 = Equip.Substring(0, 1);
                EquipFull = Equip;
            }

            string Result = Key;
            Result = Result.Replace(@"%forepart%", Forepart.Trim());
            Result = Result.Replace(@"%year%", Year);
            Result = Result.Replace(@"%month%", Month);
            Result = Result.Replace(@"%day%", Day);
            Result = Result.Replace(@"%hour%", Hour);
            Result = Result.Replace(@"%minute%", Min);
            Result = Result.Replace(@"%second%", Sec);
            Result = Result.Replace(@"%number%", PicNum);
            Result = Result.Replace(@"%noexifnumber%", NoExNum);
            Result = Result.Replace(@"%dayname%", DayName);
            Result = Result.Replace(@"%daynameshort%", DayNameShort);
            Result = Result.Replace(@"%equip1%", Equip1);
            Result = Result.Replace(@"%equipfull%", EquipFull);

            // je to duplicita 
            if (Duplicates > 0)
            {
                Result += "_DUP";
            }

            return Result;
        }

        private string MakeDaySubDirName(DateTime Date, bool LoadResult, string DupFolder, int DupCount)
        {
            if (LoadResult)
            {
                // je-li to duplicita a je-li specifikovan dup folder
                if (!string.IsNullOrEmpty(DupFolder) && (DupCount > 0))
                {
                    return DupFolder;
                }
                else
                {
                    if (Date == DateTime.MinValue)
                        return "_no_exif";
                    else
                    {
                        string Year = AddZero(Date.Year.ToString(), 4);
                        string Month = AddZero(Date.Month.ToString(), 2);
                        string Day = AddZero(Date.Day.ToString(), 2);
                        return string.Format("{0}_{1}_{2}", Year, Month, Day);
                    }
                }
            }
            else
            {
                // jpeg co nejde nacist
                return "_bad_files";
            }
        }


        private string AddZero(string Number, int ZeroCount)
        {
            while (Number.Length < ZeroCount)
            {
                Number = "0" + Number;
            }
            return Number;
        }

        private string AddSlash(string s)
        {
            string Result = s;
            if (Result.Length > 0)
            {
                if (Result[Result.Length - 1] != '\\')
                {
                    Result += '\\';
                }
            }
            return Result;
        }

        private string KillFirstSlash(string s)
        {
            string Result = s;
            if (Result.Length > 0)
            {
                if (Result[0] == '\\')
                {
                    Result = Result.Remove(0, 1);
                }
            }
            return Result;
        }



        private void CopyFile(string SourceFileName, string NewFileName, string NewPath, bool MoveMode)
        {
            if (File.Exists(NewFileName))
            {
                // soubor existuje, tak mu vymazi readonly argumenty, aby se pekne smazat
                File.SetAttributes(NewFileName, FileAttributes.Normal);
            }
            else
            {
                // soubor neexistuje, tak musim predpripravit cesty, ktere nemusi existovat
                System.IO.Directory.CreateDirectory(NewPath);
            }

            if (MoveMode)
                File.Move(SourceFileName, NewFileName);
            else
                File.Copy(SourceFileName, NewFileName, true);
        }


        private void AddErrorLog(ref string ErrorLog, string FileName, Exception Ex)
        {
            if (!string.IsNullOrEmpty(ErrorLog))
            {
                ErrorLog = ErrorLog + Environment.NewLine + Environment.NewLine;
            }

            ErrorLog = ErrorLog 
                     + "Filename: "          + FileName  + Environment.NewLine
                     + "Exception source: "  + Ex.Source + Environment.NewLine
                     + "Exception message: " + Ex.Message;
        }


        private int FileIsDuplicate(FileProp fp)
        {
            //  nejake stejne dlouhe soubory ?
            int SameSizeCount = CRCList.Count(n => n.FileSize == fp.FileSize);

            if (SameSizeCount <= 0)
                return 0; // zadny stejne dlouhy souboru - nemusim tedy pocitat CRC
            else
            {
                // nejdriv spocitat CRC aktualniho souboru
                fp.CRC = Vt.Adler32.FileChecksum(fp.OrigFileName);

                // tak bohuzel nejake stejne velke soubory :-/ musim tedu u nich spocitat CRC :-/
                for (int i = 0; i < CRCList.Count; i++)
                {
                    if (CRCList[i].FileSize == fp.FileSize)
                    {
                        // jeste neni CRC spoctena ? - asi bych to nemusel pocitat u vsech ... ale nebudu to dale komplikovat :-)
                        if (CRCList[i].CRC <= 0)
                        {
                            CRCList[i].CRC = Vt.Adler32.FileChecksum(CRCList[i].NewFileName);
                        }
                    }
                }

                //  pres linq ;-) teda zjistim, zda tu jsou nejake stejne CRC
                return CRCList.Count(n => n.CRC == fp.CRC);
            }
        }







    }
}
