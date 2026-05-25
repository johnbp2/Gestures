using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Gestures.Model.Domain.Entities;
using JohnBPearson.Cypher;
using Microsoft.Win32;
using Windows.Networking.Sockets;


namespace JohnBPearson.Windows.Forms.Gestures
{
    internal class JsonService
    {

        internal JsonService()
        {
        }
        //internal static string Export(GestureFactory sourceList, string file)
        //{
        //    var export = System.Text.Json.JsonSerializer.Serialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.DomainGesture>>(sourceList.MapToEntities());
        //    byte[] exportBytes = new UTF8Encoding(true).GetBytes(export);
        //    if(File.Exists(file) || Directory.Exists(Path.GetDirectoryName(file)))
        //    {
        //   var str =   FileService.OpenFile(file);

        //       str.Write(exportBytes, 0, exportBytes.Length);
        //        str.Close();
        //        return file;
        //    }

        //    else
        //    {

        //        throw new FileNotFoundException(file);

        //            }


        //}


        internal static string Export(GestureFactory sourceList)
        {
            string path = string.Empty;

            string file = string.Empty;
            var jsonRoot = new JsonRoot();
            jsonRoot.Gestures = sourceList.MapToEntities();
            jsonRoot.AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var export = System.Text.Json.JsonSerializer.Serialize<JsonRoot>(jsonRoot);


            //  System.Windows.Clipboard.SetText(export);

            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            var saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "json text|*.json";
            saveFileDialog1.Title = "Save all your key bindings to json File";

            saveFileDialog1.FileName = FileService.FileNameUsingDateTime();

            saveFileDialog1.InitialDirectory = FileService.determineJsonDefaultFolderPath();

            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if(saveFileDialog1.FileName != "")
            {
                path = Path.GetFullPath(saveFileDialog1.FileName);

                // Saves the Image via a FileStream created by the OpenFile method.
                //if(System.IO.Directory.Exists(sys))
                //{
                using(System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile())
                {

                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch(saveFileDialog1.FilterIndex)
                    {

                        case 1:
                            byte[] exportBytes = new UTF8Encoding(true).GetBytes(export);
                            fs.Write(exportBytes, 0, exportBytes.Length);
                            break;
                    }
                    file = saveFileDialog1.FileName;
                    fs.Close();

                    var dp = new DataProtect();
                    var dirinfo = new DirectoryInfo(path);

                    // dp.encryptToFile(export, dirinfo, file.Replace(".json", ".dat"));
                    string encryptedFile = path.Replace(".json", ".dat");
                    File.Copy(path, encryptedFile);
                    File.Encrypt(encryptedFile);
                }
                //  }
                Properties.Settings.Default.LastSavedFile = path;
                Properties.Settings.Default.Save();
                return path;
            }
            return string.Empty;
            //  return System.IO.Path.Combine(path, file);
        }





        internal static string Import(GestureFactory sourceList, bool useDialog = false)
        {
            FileStream fs;
            string fileUsed = string.Empty;
            string dataFile = string.Empty;
            if(Properties.Settings.Default.UsedLastSavedNextSession &&
                File.Exists(Properties.Settings.Default.LastSavedFile) && !useDialog)
            {

                fs = FileService.OpenFile(Properties.Settings.Default.LastSavedFile);
                dataFile = Properties.Settings.Default.LastSavedFile.Replace(".json", ".dat");
                fileUsed = Path.GetFileName(Properties.Settings.Default.LastSavedFile) + " auto import";
                if(File.Exists(dataFile))
                {
                    File.Decrypt(dataFile);
                }

            }
            else
            {
                fs = FileService.OpenFile();
                fileUsed = fs.Name;
                dataFile = fs.Name.Replace(".json", ".dat");
                ;
            }



            //var dp = new DataProtect();

            //var fileinfo = new System.IO.FileInfo(Path.Combine(FileService.determineJsonDefaultFolderPath(), dataFile));
            //if(fileinfo.Exists)
            //{

            //    var decrypted = dp.decryptFromFile(fileinfo);
            //    System.Diagnostics.Debug.Print(decrypted);
            //}
            using(fs)

            {
                parseJson(sourceList, fs);
                return fileUsed;

            }

            //  System.Diagnostics.Trace.TraceInformation();
            // System.Text.Json.JsonSerializer.Deserialize<Containers[]>()


        }




        private static void parseJson(GestureFactory _sourceList, FileStream fs)
        {

            var doc = System.Text.Json.JsonDocument.Parse(fs);

            if(doc.RootElement.ValueKind == JsonValueKind.Array)
            {
                var root = doc.Deserialize<List<DomainGesture>>();
                _sourceList.MapFromEntities(root);
            }
            else
            {


                var root = doc.Deserialize<JsonRoot>();
                _sourceList.MapFromEntities(root.Gestures);
            }
        }
    }
}
