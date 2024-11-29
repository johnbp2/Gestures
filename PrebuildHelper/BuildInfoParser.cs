using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Application.Common;

namespace PrebuildHelper
{
    public enum file
    {
    AssemblyInfo = 0,
    Settings= 1
    }
    internal static partial class BuildInfoParser
    {






        internal static void Parse(string projectPropertiesDirectory, string strMajor,
            string strMinor, string strBuild, string strRevision)
        {

            
            int temp = -1;
            SymanticVersion version = new SymanticVersion();
            int.TryParse(strMajor, out temp);
            version.Major = temp;
            temp = -1;
            int.TryParse(strMinor, out temp);
            version.Minor = temp;
            temp = -1;
            int.TryParse(strBuild, out temp);
            version.Build = temp;
            temp = -1;
            int.TryParse(strRevision, out temp);
            version.Revision = temp;
            //ProjectPropertiesFile assemblyInfo = null;
            //ProjectPropertiesFile settings = null;
            foreach(string file in Constants.fileNames)
            {
                validateFile(projectPropertiesDirectory, file);
                //var tempFile =     validateFile(projectPropertiesDirectory, file);
                //    if(tempFile.File == PrebuildHelper.file.AssemblyInfo)
                //    {
                //        assemblyInfo = tempFile;
                //    }
                //    else
                //    {

                //    settings = tempFile;
                //    }
            }
            //return new BuildInfo(assemblyInfo, version, settings);
        
        }

        private static void validateFile(string path, string fileName)
       {
          //  FileInfo assemblyFileInfo = new FileInfo(projectPropertiesDirectory);
        var fullPath =   Path.Combine(path, fileName);
            FileInfo fileInfo = new FileInfo(fullPath);
            var validatedPath = "";

            if(fileInfo.Exists)
            {

                if(fileInfo.Name == fileName)
                {
                    validatedPath = path;
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
                    throw new System.ArgumentException($"Found file named {fileInfo.Name.Replace(fileInfo.Extension, "")}, but expected AssemblyInfo.cs or a directory", $"{path}");
                }



            }
            else
            {

                // TODO: [] add code to create new AssemblyInfo.cs file
            }

            //var lines = File.ReadAllLines(fileInfo.FullName);
            
            //var ppFile = new ProjectPropertiesFile(lines, Utility.ToEnum<file>(fileInfo.Name.Replace(fileInfo.Extension, "")), fullPath);
       
            //return ppFile;
        }

    }
}
