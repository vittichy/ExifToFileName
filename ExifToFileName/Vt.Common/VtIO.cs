using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Vt.Common
{
    public class VtIO
    {

        static public void SaveToFile(string FileName, string s)
        {
            FileInfo FInfo = new FileInfo(FileName);
            FileStream FStream = new FileStream(FileName, FileMode.Create);
            // musim takhle, jinak se to nezapise cesky
            StreamWriter SWriter = new StreamWriter(FStream, Encoding.Default);
            SWriter.Write(s);
            SWriter.Flush();
            SWriter.Close();
        }

        static public string SaveToTempFile(string s)
        {
            string TempName = Path.GetTempFileName();
            SaveToFile(TempName, s);
            return TempName;
        }




        static public void SaveBinaryToFile(string FileName, byte[] ChArray)
        {
            FileInfo FInfo = new FileInfo(FileName);
            FileStream FStream = new FileStream(FileName, FileMode.Create);
            BinaryWriter SWriter = new BinaryWriter(FStream);

            foreach (byte b in ChArray)
                SWriter.Write(b);
            SWriter.Flush();
            SWriter.Close();
        }

        static public string SaveBinaryToTempFile(byte[] Bytes)
        {
            string TempName = Path.GetTempFileName();
            SaveBinaryToFile(TempName, Bytes);
            return TempName;
        }



        static public void SaveBinaryToFile(string FileName, string Source)
        {
            FileInfo FInfo = new FileInfo(FileName);
            FileStream FStream = new FileStream(FileName, FileMode.Create);
            // musim takhle, jinak se to nezapise cesky
            BinaryWriter SWriter = new BinaryWriter(FStream);
            SWriter.Write(Source);
            SWriter.Flush();
            SWriter.Close();
        }

        static public string SaveBinaryToTempFile(string Source)
        {
            string TempName = Path.GetTempFileName();
            SaveBinaryToFile(TempName, Source);
            return TempName;
        }





        // vraci vsechny soubory z adresare a podadresaru
		static public List<string> GetAllFiles(string PathName)
		{
			return GetAllFiles(PathName, "*.*");
		}
		
        static public List<string> GetAllFiles(string PathName, string SearchPattern)
        {
            var Result = new List<string>();
            GetAllSubFiles(PathName, SearchPattern, ref Result);
            return Result;
        }

		// privatni pomocna
		static private void GetAllSubFiles(string RootPath, string SearchPattern, ref List<string> Result)
		{
			// pridam soubory
			string[] SubFiles = Directory.GetFiles(RootPath, SearchPattern);
			foreach (string FileName in SubFiles)
				Result.Add(FileName);
			// rekurzivne pustim na sub-adresare
			string[] SubPaths = Directory.GetDirectories(RootPath);
			foreach (string SubPath in SubPaths)
				GetAllSubFiles(SubPath, SearchPattern, ref Result);
		}
		

   	    /// <summary>
		/// resi problem s mezerami na konci jmena adresare - .net to otrimuje a adresar pak nenajde :-/
		/// viz community content: http://msdn.microsoft.com/en-us/library/system.io.directory.aspx#3
		/// </summary>
		/// <param name="PathName"></param>
		/// <param name="SearchPattern"></param>
		/// <param name="ErrorPaths"></param>
		/// <returns></returns>
		static public List<string> GetAllFilesEx(string PathName, string SearchPattern, ref List<string> ErrorPaths)
		{
			var Result = new List<string>();
			GetAllSubFilesEx(PathName, SearchPattern, ref Result, ref ErrorPaths);
			return Result;
		}	
		
		static private void GetAllSubFilesEx(string RootPath, string SearchPattern, ref List<string> Result, ref List<string> ErrorPaths)
		{
			if ((!string.IsNullOrEmpty(RootPath)) && RootPath.EndsWith(" "))
			{
				ErrorPaths.Add(RootPath);
			}
			else
			{
				// pridam soubory
				string[] SubFiles = Directory.GetFiles(RootPath, SearchPattern);
				foreach (string FileName in SubFiles)
					Result.Add(FileName);
				// rekurzivne pustim na sub-adresare
				string[] SubPaths = Directory.GetDirectories(RootPath);
				foreach (string SubPath in SubPaths)
					GetAllSubFilesEx(SubPath, SearchPattern, ref Result, ref ErrorPaths);
			}
		}


		static public void GetAllSubDirectories(string rootPath, ref List<string> resultSet)
		{
			string[] subDirectories = Directory.GetDirectories(rootPath);//, SearchPattern);
			foreach (string directroryName in subDirectories)
			{
				resultSet.Add(directroryName);
				GetAllSubDirectories(directroryName, ref resultSet);
			}
			// rekurzivne pustim na sub-adresare
//			string[] SubPaths = Directory.GetDirectories(RootPath);
			//foreach (string SubPath in SubPaths)
				//GetAllSubFiles(SubPath, SearchPattern, ref Result);
		}

		static public List<string> GetAllSubDirectories(string rootPath)
		{
			var resultSet = new List<string>();
			GetAllSubDirectories(rootPath, ref resultSet);
			return resultSet;
		}





        static public void ForceCopyFile(string SourceFileName, string NewFileName)
        {
            if (File.Exists(NewFileName))
            {
                // soubor existuje, tak mu vymazi readonly argumenty, aby se pekne smazal
                File.SetAttributes(NewFileName, FileAttributes.Normal);
            }
            File.Copy(SourceFileName, NewFileName, true);
        }

        static public void ForceCopyFile(string SourceFileName, string NewFileName, string NewPath)
        {
            if (File.Exists(NewFileName))
            {
                // soubor existuje, tak mu vymazi readonly argumenty, aby se pekne smazal
                File.SetAttributes(NewFileName, FileAttributes.Normal);
            }
            else
            {
                // soubor neexistuje, tak musim predpripravit cesty, ktere nemusi existovat
                Directory.CreateDirectory(NewPath);
            }
            File.Copy(SourceFileName, NewFileName, true);
        }



        static public void ForceMoveFile(string SourceFileName, string NewFileName)
        {
            if (File.Exists(NewFileName))
            {
                // soubor existuje, tak mu vymazi readonly argumenty, aby se pekne smazal
                File.SetAttributes(NewFileName, FileAttributes.Normal);
                File.Delete(NewFileName);
            }
            File.Move(SourceFileName, NewFileName);
        }




        static public void CreateSubDirectories(string FilePath)
        {
            string PathName = Path.GetDirectoryName(FilePath);
            Directory.CreateDirectory(PathName);
        }



		static public long GetDirectorySize(string rootPath)
		{
			long result = 0;

			var fileList = GetAllFiles(rootPath);
			foreach (var filename in fileList)
			{
				var fileInfo = new FileInfo(filename);
				result += fileInfo.Length;
			}
			return result;
		}





		public static DirectoryInfo CreateTemporaryDirectory()
		{
			string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			return Directory.CreateDirectory(tempDirectory);
		}

    }
}
