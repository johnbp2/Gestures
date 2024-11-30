using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using JohnBPearson.Application.Common;



namespace PrebuildHelper
{
    internal class BuildInfo
    {
        internal string[] updatedAssemblyInfoLines;   
        internal string[] updatedSettingsLines;

        internal BuildInfo(ProjectPropertiesFile assemblyInfoFileObject, SymanticVersion version, ProjectPropertiesFile settingsFileObject) :
            this(assemblyInfoFileObject, version.Major, version.Minor, version.Build, version.Revision, settingsFileObject)
        {

        }

        private BuildInfo(ProjectPropertiesFile assemblyInfoFileObject, int major,
            int minor, int build, int revision, ProjectPropertiesFile settingsFileObject)
        {
            FileInfo assemblyFileInfo = new FileInfo(assemblyInfoFileObject.FullPath);
            this.PathToAssemblyInfo = assemblyInfoFileObject.FullPath;
            this.pathToSettingsFile = settingsFileObject.FullPath;
            FileInfo settingsFileInfo = new FileInfo(settingsFileObject.FullPath);
            createBackupFile(assemblyFileInfo);
            updatedAssemblyInfoLines = assemblyInfoFileObject.Lines;
            updatedAssemblyInfoLines = updateFile(assemblyInfoFileObject, $"{Constants.searchString1}\"{major}.{minor}.{build}.{revision}\")]", assemblyFileInfo, Constants.searchString1, updatedAssemblyInfoLines);
            updatedAssemblyInfoLines = updateFile(assemblyInfoFileObject, $"{Constants.searchString2}\"{major}.{minor}.{build}.{revision}\")]", assemblyFileInfo, Constants.searchString2, updatedAssemblyInfoLines);
            
           // createBackupFile(settingsFileInfo);
          
            //var updatedSettingsLines= updateFile(settingsFileInfo, $"{Constants.searchString2}\"{major}.{minor}.{build}.{revision}\")]", settingsFileInfo, Constants.searchString1, updatedAssemblyInfoLines);




            //3  return currentRevi nsion;
        }

        private void temp(string filePath)
        {
           
        }

        private static string[] updateFile(ProjectPropertiesFile ppFile, string insertLine,
            FileInfo ppFileInfo, string searchString, string[] lines)
        {

            var indexReplace = 0;
            //for(global::System.Int32 i = (lines.Length) - (1); i >= 0; i--)
            //{
            int i  = 0;
            foreach(var line in lines)
            {
                if(line.StartsWith(searchString))
                {
                    indexReplace = i;
                    break;

                }
                
                    ++i;
            }           // }

           
            var listLines = lines.ToList();
            listLines.RemoveAt(indexReplace);

            listLines.Insert(indexReplace, insertLine);
            // return writeLines(file, contents, listLines);
            return listLines.ToArray();
        }




        internal static int writeLines(string fullPath, IEnumerable<string> listLines)
        {
            var contents = new StringBuilder();
            foreach(var item in listLines)
            {
                contents.AppendLine(item);
            }
            // int currentRevision = int.Parse(args[4]) + 1;

            File.WriteAllText(fullPath, contents.ToString());
            return 1;//;
        }

        internal static bool createBackupFile(FileInfo fileInfo)
        {


            var backup = new FileInfo($"{fileInfo.FullName}.backup");
            if(backup.Exists)
            {
                backup.Delete();
            }
            // rename to the .backup file AssemblyInfo.cs.backup
            fileInfo.MoveTo($"{fileInfo.FullName}.backup");
            return true;
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
