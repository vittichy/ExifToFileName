using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;

namespace ExifToFileName
{
    // spojovaci trida pro zaslani parametru z jednoho formu do druheho

    public class LinkClass
    {
        public string DestinationRoot;
        public string SourceRoot;
        public string Forepart;
        public string ExifKey;
        public string NoExifKey;
        public ArrayList SelectedExt;
        public bool CreateDayDirectory;
        public ArrayList PreferExifDate;
        public bool ShowErrorLog;
        public bool IgnoreSubfolder;
        public string DupFolder;
        public bool MoveMode;
        public bool MoveDuplicates;

        //public int PicCount;
        //public int NoExifCount;
        //public ArrayList PicFileNames;

        public LinkClass(
                        string SourceRoot,
                        string DestinationRoot,
                        string Forepart,
                        string ExifKey,
                        string NoExifKey,
                        string DupFolder,   
                        bool MoveMode,
                        bool MoveDuplicates,
                        ArrayList SelectedExt,
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
            this.SelectedExt = SelectedExt;
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
