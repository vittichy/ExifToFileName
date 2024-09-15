//using System.Linq;
using System.Collections;

namespace ExifToFileName
{
    /// <summary>
    /// Spojovaci trida pro zaslani parametru z jednoho formu do druheho
    /// </summary>
    public class LinkClass
    {
        public string DestinationRoot;
        public string SourceRoot;
        public string Forepart;
        public string ExifKey;
        public string NoExifKey;
        public bool CreateDayDirectory;
        public ArrayList PreferExifDate;
        public bool ShowErrorLog;
        public bool IgnoreSubfolder;
        public string DupFolder;
        public bool MoveMode;
        public bool MoveDuplicates;

        public LinkClass(
                        string SourceRoot,
                        string DestinationRoot,
                        string Forepart,
                        string ExifKey,
                        string NoExifKey,
                        string DupFolder,   
                        bool MoveMode,
                        bool MoveDuplicates,
                        bool CreateDayDirectory,
                        ArrayList PreferExifDate,
                        bool ShowErrorLog,
                        bool IgnoreSubfolder)
        {
            this.SourceRoot = SourceRoot;
            this.DestinationRoot = DestinationRoot;
            this.Forepart = Forepart;
            this.ExifKey = ExifKey;
            this.NoExifKey = NoExifKey;
            this.CreateDayDirectory = CreateDayDirectory;
            this.PreferExifDate = PreferExifDate;
            this.ShowErrorLog = ShowErrorLog;
            this.IgnoreSubfolder = IgnoreSubfolder;
            this.DupFolder = DupFolder;
            this.MoveMode = MoveMode;
            this.MoveDuplicates = MoveDuplicates;
        }
    }
}
