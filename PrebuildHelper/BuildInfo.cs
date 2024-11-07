using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Application.Common;

namespace PrebuildHelper
{



    internal class IncrementOptions
    {

        internal bool IncrementMajor
        {
            get; set;
        }
        internal bool IncrementMinor
        {
            get;set;
        }
        internal bool IncrementBuild
        {
            get; set;
        }
        internal bool IncrementRevision
        {
            get; set;
        }
    }
    internal class BuildInfo
    {
        internal BuildInfo(ProjectPropertiesFile assemblyInfoFileObject, SymanticVersion version, ProjectPropertiesFile settingsFileObject) : 
            this(assemblyInfoFileObject, version.Major, version.Minor, version.Build, version.Revision, settingsFileObject)
        {
      
        }

        private BuildInfo(ProjectPropertiesFile assemblyInfoFileObject, int major, int minor, int build, int revision, ProjectPropertiesFile settingsFileObject)
        {
            FileInfo assemblyFileInfo = new FileInfo(assemblyInfoFileObject.FullPath);
            FileInfo settingsFileInfo = new FileInfo(settingsFileObject.FullPath);


           
            var lines = File.ReadAllLines(assemblyFileInfo.FullName);
            // var contents = File.ReadAllText(assInfo.FullName);

            assemblyFileInfo.MoveTo($"{assemblyInfoFileObject}.backup");
            var indexReplace = 0;
            for(global::System.Int32 i = (lines.Length) - (1); i >= 0; i--)
            {
                if(lines[i].StartsWith(Constants.searchString1))
                {
                    indexReplace = i;
                    break;

                }
            }

            var contents = new StringBuilder();
            var listLines = lines.ToList();
            listLines.RemoveAt(indexReplace);
            int currentRevision = revision + 1;
            listLines.Insert(indexReplace, $"[assembly: AssemblyVersion(\"{major}.{minor}.{build}.{currentRevision}\")]");
            foreach(var item in listLines)
            {
                contents.AppendLine(item);
            }
            // int currentRevision = int.Parse(args[4]) + 1;

            File.WriteAllText(assemblyInfoFileObject.FullPath, contents.ToString());
            
            Major = major;
            Minor = minor;
            Build = build;
            Revision = currentRevision;
            PreviousRevision = revision;
          //3  return currentRevision;
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
        }internal int PreviousMinor
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
