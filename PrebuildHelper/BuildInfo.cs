using System.IO;
using System.Linq;
using System.Text;
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

            int currentRevision = updateFile(assemblyInfoFileObject, $"[assembly: AssemblyVersion(\"{major}.{minor}.{build}.{revision}\")]",assemblyFileInfo ,Constants.searchString1);

            Major = major;
            Minor = minor;
            Build = build;
            Revision = currentRevision;
            PreviousRevision = revision;
            //3  return currentRevision;
        }

        private static int updateFile(ProjectPropertiesFile ppFile,string insertLine, FileInfo ppFileInfo, string searchString)
        {
            var ppLines = ppFile.Lines;
                    // var contents = File.ReadAllText(assInfo.FullName);

            ppFileInfo.MoveTo($"{ppFile}.backup");
            var indexReplace = 0;
            for(global::System.Int32 i = (ppLines.Length) - (1); i >= 0; i--)
            {
                if(ppLines[i].StartsWith(searchString))
                {
                    indexReplace = i;
                    break;

                }
            }

            var contents = new StringBuilder();
            var listLines = ppLines.ToList();
            listLines.RemoveAt(indexReplace);
            
            listLines.Insert(indexReplace, insertLine);
            foreach(var item in listLines)
            {
                contents.AppendLine(item);
            }
            // int currentRevision = int.Parse(args[4]) + 1;

            File.WriteAllText(ppFile.FullPath, contents.ToString());
            return 1;//;
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
