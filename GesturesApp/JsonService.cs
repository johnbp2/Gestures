﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Gestures.Model.Domain.Entities;
using Microsoft.Win32;
using Windows.Media.Protection.PlayReady;
using Windows.Networking.Sockets;

namespace JohnBPearson.Windows.Forms.Gestures
{
    internal class JsonService
    {

        internal JsonService()
        {
        }

        internal static string Export(GestureFactory sourceList)
        {
            string path = string.Empty;
            string file = string.Empty;
            {
                var export = System.Text.Json.JsonSerializer.Serialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.GestureDTO>>(sourceList.MapToEntities());
                //  System.Windows.Clipboard.SetText(export);

                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                var saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Filter = "json text|*.json";
                saveFileDialog1.Title = "Save all your key bindings to json File";
                var now = System.DateTime.Now;
                saveFileDialog1.FileName = $"{now.Date.Month}-{now.Day}-{now.Year}-{now.TimeOfDay.TotalSeconds}";

            
                saveFileDialog1.InitialDirectory = determineJsonDefaultPath();
                
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if(saveFileDialog1.FileName != "")
                {
                    path= Path.GetFullPath(saveFileDialog1.FileName);
                   
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
                        } 
                  //  }
                   
                }
            }
            return path;
          //  return System.IO.Path.Combine(path, file);
        }

        private static string determineJsonDefaultPath()
        {
            string currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(currentDir, "JsonObjects");

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        private static FileStream openDefault(string path)
        {
            System.IO.FileStream st = new FileStream(path, FileMode.Open, FileAccess.Read);
            return st;
        }
        internal static void Import(GestureFactory _sourceList, string defaultFile = "")
        {
            if(string.IsNullOrEmpty(defaultFile))
            {

                var of = new System.Windows.Forms.OpenFileDialog();

                of.Filter = "json text|*.json";
                of.InitialDirectory = determineJsonDefaultPath();
                of.ShowDialog();


                if(of.FileName != string.Empty)
                {
                    using(System.IO.FileStream fs =
                             (System.IO.FileStream)of.OpenFile())

                    {
                        parseJson(_sourceList, fs);

                    }
                    //  System.Text.Json.JsonSerializer.Deserialize<Containers[]>()


                }
            }
            else
            {
                parseJson(_sourceList, openDefault(defaultFile));
            }
        }

        private static void parseJson(GestureFactory _sourceList, FileStream fs)
        {
            var doc = System.Text.Json.JsonDocument.Parse(fs);
            System.Diagnostics.Trace.TraceInformation(doc.ToString());
            var root = doc.Deserialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.GestureDTO>>();
            _sourceList.MapFromEntities(root);
        }
    }
}
