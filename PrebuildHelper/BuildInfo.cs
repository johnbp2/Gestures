using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrebuildHelper
{
    internal class BuildInfo
    {
        internal BuildInfo(string pathToAssemblyInfo, SymanticVersion version) : 
            this(pathToAssemblyInfo, version.Major, version.Minor, version.Build, version.Revision)
        {
      
        }

        private BuildInfo(string pathToAssemblyInfo, int major, int minor, int build, int revision)
        {
            FileInfo fileInfo = new FileInfo(pathToAssemblyInfo);


            if(fileInfo.Exists)
            {

                if(fileInfo.Name == "AssemblyInfo.cs")
                {
                    PathToAssemblyInfo = pathToAssemblyInfo;
                }
                else
                {
                    //foreach(var item in this.GetType().GetConstructors())
                    //{
                    //    foreach(var param in item.GetParameters())
                    //    {
                    //        param.Name
                    //    }    
                    //       // item.GetParameters()
                    throw new System.ArgumentException($"Found file named {fileInfo.Name}, but expected AssemblyInfo.cs or a directory", $"{pathToAssemblyInfo}");
                }
            
            

            }
            else
            {
            
            // TODO: [] add code to create new AssemblyInfo.cs file
            }
            var lines = File.ReadAllLines(fileInfo.FullName);
            // var contents = File.ReadAllText(assInfo.FullName);

            fileInfo.MoveTo($"{pathToAssemblyInfo}.backup");
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
            int thisBuild = int.Parse("1") + 1;
            listLines.Insert(indexReplace, $"[assembly: AssemblyVersion(\"{major}.{minor}.{build}.{thisBuild}\")]");
            foreach(var item in listLines)
            {
                contents.AppendLine(item);
            }
            // int thisBuild = int.Parse(args[4]) + 1;

            File.WriteAllText(pathToAssemblyInfo, contents.ToString());
            
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
          //3  return thisBuild;
        }

        public string PathToAssemblyInfo
        {
            get;
        }
        public int Major
        {
            get;
        }
        public int Minor
        {
            get;
        }
        public int Build
        {
            get;
        }
        public int Revision
        {
            get;
        }
    }
}
