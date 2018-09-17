using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExifToFileName
{
    class FileProp
    {
        private string _OrigFileName = "";
        private string _NewFileName = "";
        private long _CRC = 0;
        private long _FileSize = 0;
        private int _DupCount = 0; // kolik je duplicit

        public FileProp(string OrigFileName)
        {
            this.OrigFileName = OrigFileName;
            this.NewFileName = "";
            this.CRC = 0;
            this.FileSize = 0;
            this.DupCount = 0;
        }

        public string OrigFileName
        {
            get { return _OrigFileName; }
            set { _OrigFileName = value; }
        }

        public string NewFileName
        {
            get { return _NewFileName; }
            set { _NewFileName = value; }
        }

        public long CRC
        {
            get { return _CRC; }
            set { _CRC = value; }
        }

        public long FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }

        public int DupCount
        {
            get { return _DupCount; }
            set { _DupCount = value; }
        }
    }
}
