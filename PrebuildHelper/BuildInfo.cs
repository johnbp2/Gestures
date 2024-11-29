﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using JohnBPearson.Application.Common;



namespace PrebuildHelper
{
    internal class BuildInfo
    {
        internal string[] updatedAssemblyInfoLines = [];   
        internal string[] updatedSettingsLines = [];

        internal BuildInfo(ProjectPropertiesFile assemblyInfoFileObject, SymanticVersion version, ProjectPropertiesFile settingsFileObject) :
            this(assemblyInfoFileObject, version.Major, version.Minor, version.Build, version.Revision, settingsFileObject)
        {

        }

        private BuildInfo(ProjectPropertiesFile assemblyInfoFileObject, int major,
            int minor, int build, int revision, ProjectPropertiesFile settingsFileObject)
        {
            FileInfo assemblyFileInfo = new FileInfo(assemblyInfoFileObject.FullPath);
            FileInfo settingsFileInfo = new FileInfo(settingsFileObject.FullPath);
            createBackupFile(assemblyInfoFileObject, assemblyFileInfo);
            updatedAssemblyInfoLines = assemblyInfoFileObject.Lines;
            updatedAssemblyInfoLines = updateFile(assemblyInfoFileObject, $"{Constants.searchString1}\"{major}.{minor}.{build}.{revision}\")]", assemblyFileInfo, Constants.searchString1, updatedAssemblyInfoLines);

            updatedAssemblyInfoLines = updateFile(assemblyInfoFileObject, $"{Constants.searchString2}\"{major}.{minor}.{build}.{revision}\")]", assemblyFileInfo, Constants.searchString2, updatedAssemblyInfoLines);

            //var linbesd= updateFile(settingsFileInfo, $"{Constants.searchString2}\"{major}.{minor}.{build}.{revision}\")]", settingsFileInfo, Constants.searchString1, updatedAssemblyInfoLines);

           


            //3  return currentRevi nsion;
        } 

        private void temp(string filePath)
        {
           
        }

        private static string[] updateFile(ProjectPropertiesFile ppFile, string insertLine,
            FileInfo ppFileInfo, string searchString, string[] lines)
        {

            var indexReplace = 0;
            for(global::System.Int32 i = (lines.Length) - (1); i >= 0; i--)
            {
                if(lines[i].StartsWith(searchString))
                {
                    indexReplace = i;
                    break;

                }
            }

           
            var listLines = lines.ToList();
            listLines.RemoveAt(indexReplace);

            listLines.Insert(indexReplace, insertLine);
            // return writeLines(ppFile, contents, listLines);
            return listLines.ToArray();
        }

       


        internal static int writeLines(ProjectPropertiesFile ppFile, List<string> listLines)
        {
            var contents = new StringBuilder();
            foreach(var item in listLines)
            {
                contents.AppendLine(item);
            }
            // int currentRevision = int.Parse(args[4]) + 1;

            File.WriteAllText(ppFile.FullPath, contents.ToString());
            return 1;//;
        }

        private static void createBackupFile(ProjectPropertiesFile ppFile, FileInfo ppFileInfo)
        {


            var backup = new FileInfo($"{ppFile}.backup");
            if(backup.Exists)
            {
                backup.Delete();
            }
            ppFileInfo.MoveTo($"{ppFile}.backup");

        }

        internal string PathToAssemblyInfo
        {
            get;
        }

        internal string pathToSettingsFile
        {
            get;
        }

        internal int Major
        {
            get;
        }

        internal int PreviousMajor
        {
            get;
        }
        internal int Minor
        {
            get;
        }
        internal int PreviousMinor
        {
            get;
        }
        internal int Build
        {
            get;
        }
        internal int PreviousBuild
        {
            get;
        }
        internal int Revision
        {
            get;
        }
        internal int PreviousRevision
        {
            get;
        }
    }
}
