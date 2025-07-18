﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using JohnBPearson.Application.Gestures.Model;
using JohnBPearson.Application.Gestures.Model.Domain.Entities;
using Microsoft.Win32;
using Windows.Media.Protection.PlayReady;

namespace JohnBPearson.Windows.Forms.Gestures
{
    internal class JsonService
    {

        internal JsonService()
        {
        }

        internal static void Export(GestureFactory sourceList)
        {
            {
                var export = System.Text.Json.JsonSerializer.Serialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.ContainerEntity>>(sourceList.MapToEntities());
                //  System.Windows.Clipboard.SetText(export);

                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                var saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog1.Filter = "json text|*.json";
                saveFileDialog1.Title = "Save all your key bindings to json File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if(saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
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

                        fs.Close();
                    }
                }
            }
        }


        internal static void Import(GestureFactory _sourceList)
        {
            var of = new System.Windows.Forms.OpenFileDialog();
            of.Filter = "json text|*.json";

            if(of.FileName != string.Empty)
            {
                using(System.IO.FileStream fs =
                         (System.IO.FileStream)of.OpenFile())
                
                    {


                    var doc = System.Text.Json.JsonDocument.Parse(fs);
                    var root = doc.Deserialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.ContainerEntity>>();
                    _sourceList.MapFromEntities(root);

                }
                //  System.Text.Json.JsonSerializer.Deserialize<Containers[]>()


            }
            
        }
    }
}
