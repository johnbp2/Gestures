using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Application.Common;

namespace PrebuildHelper
{
    internal static class Constants
    {

        internal static string searchString1 = @"[assembly: AssemblyVersion(";
        internal static string searchString2 = @"[assembly: AssemblyFileVersion(";
        internal static string[] fileNames = { "AssemblyInfo.cs", "Settings.settings" };
    }
    internal class Program
    {

        //internal static ProjectPropertiesFile assemblyInfo = null;
        //internal static ProjectPropertiesFile settings = null;
        //internal static SymanticVersion symanticVersion;



        /// <summary>
        /// 
        /// assemblyinfo path or dir to create assembllyinfo , major version, minor version, build, revision, project name
        /// </summary>
        /// 
        /// <param name="args">
        /// ordinal |  value
        /// ------------------
        /// 0       | path to prpject properties
        /// 1       | Major Version
        /// 2       | Minor Version
        /// 3       | Build 
        /// 4       | Revision 
        /// </param>
        static int Main(string[] args)
        {
            ProjectPropertiesFile assemblyInfo = null;
            ProjectPropertiesFile settings = null;
 SymanticVersion symanticVersion;


            BuildInfoParser.Parse(args[0], args[1], args[2], args[3], args[4]);

            foreach(string file in Constants.fileNames)
            {

                var filePath = Path.Combine(args[0], file);
                FileInfo fileInfo = new FileInfo(filePath);
                var lines = File.ReadAllLines(filePath);
                if(file.StartsWith("Ass"))
                {

                    //  var filePath = Path.Combine(args[0], file);
                    //  FileInfo fileInfo = new FileInfo(filePath);
                    //    var lines = File.ReadAllLines(filePath);
                    assemblyInfo = new ProjectPropertiesFile(lines, Utility.ToEnum<file>(fileInfo.Name.Replace(fileInfo.Extension, "")), filePath);
                    //foreach(string fileName in Constants.fileNames)
                    //{

                    //    if(tempFile.File == PrebuildHelper.file.AssemblyInfo)
                    //    {
                    //        assemblyInfo = tempFile;
                    //    }
                    //    else
                    //    {

                    //        settings = tempFile;
                    //    }
                }
                else
                {

                    settings = new ProjectPropertiesFile(lines, Utility.ToEnum<file>(fileInfo.Name.Replace(fileInfo.Extension, "")), filePath);

                }
            }
   
            var bi = new BuildInfo(assemblyInfo, BuildInfoParser.version, settings);
            BuildInfo.writeLines(bi.PathToAssemblyInfo, bi.updatedAssemblyInfoLines); 
            //FileInfo assInfo = new FileInfo(args[0]);
            //if(assInfo.Exists)
            //{
            //    var lines = File.ReadAllLines(assInfo.FullName);
            //    // var contents = File.ReadAllText(assInfo.FullName);

            //    assInfo.MoveTo($"{args[0]}.back");
            //    var indexReplace = 0;
            //    for(global::System.Int32 i = (lines.Length) - (1); i >= 0; i--)
            //    {
            //        if(lines[i].StartsWith(Constants.searchString1))
            //        {
            //            indexReplace = i;
            //            break;

            return -1;

        }
    }
}
