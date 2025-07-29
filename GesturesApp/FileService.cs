using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace JohnBPearson.Windows.Forms.Gestures
{
    public static class FileService
    {
        public static string FileNameUsingDateTime()
        {
            var now = System.DateTime.Now;
            var FileName = $"{now.Date.Month}-{now.Day}-{now.Year}-{now.TimeOfDay.TotalSeconds}";
            return FileName;
        }


        public static string determineJsonDefaultFilePath()
        {


            string currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(currentDir, "JsonObjects");

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, FileNameUsingDateTime());
            return path;


        }


        public static string determineJsonDefaultFolderPath()
        {


            string currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(currentDir, "JsonObjects");

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            // path = Path.Combine(path, FileNameUsingDateTime());
            return path;


        }

        /// <summary>
        /// returns a file stream using path. 
        /// </summary>
        /// <param  name="path">
        /// Is a path a a json file or the directory where json files are stored.
        /// </param>
        /// <returns>FileStream</returns>
        /// <exception cref="ArgumentException"></exception>
        public static FileStream OpenFile()
        {
            System.Windows.Forms.OpenFileDialog dlg;
            //if(!string.IsNullOrEmpty(path) && File.Exists(path))
            //{
            //    System.IO.FileStream st = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            //    return st;
            //}
            //else
            //{
            using(dlg = new System.Windows.Forms.OpenFileDialog())
            {
                dlg.Filter = "json text|*.json";
                dlg.InitialDirectory = FileService.determineJsonDefaultFolderPath();
                dlg.RestoreDirectory = true;
                dlg.ShowDialog();


                if(dlg.FileName != string.Empty)
                    return (System.IO.FileStream)dlg.OpenFile();
                else
                    throw new ArgumentException($"path must be a valid directory or .json file.");
            }

        }
        public static FileStream OpenFile(string path)
        {
            System.IO.FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return fs;
        }
    }
}
