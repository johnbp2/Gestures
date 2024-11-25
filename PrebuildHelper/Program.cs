using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrebuildHelper
{
    internal static class Constants
    {

      internal static string searchString1 = @"[assembly: AssemblyVersion(";
        internal static string searchString2 = @"[assembly: AssemblyFileVersion(";
    }
    internal class Program
    {


        //   const replaceString1 = $"[assembly: AssemblyVersion(\"{0}.2.0.0\")]";
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

            BuildInfoParser.Parse(args[0], args[1], args[2], args[3], args[4]);
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

            //        }
            //    }

            //    var contents = new StringBuilder();
            //    var listLines = lines.ToList();
            //    listLines.RemoveAt(indexReplace);
            //    int thisBuild = int.Parse(args[4]) + 1;
            //    listLines.Insert(indexReplace, $"[assembly: AssemblyVersion(\"{args[1]}.{args[2]}.{args[3]}.{thisBuild}\")]");
            //    foreach(var item in listLines)
            //    {
            //        contents.AppendLine(item);
            //    }
            //    // int thisBuild = int.Parse(args[4]) + 1;

            //    File.WriteAllText(args[0], contents.ToString());
            //    return thisBuild;
            //}
            return -1;
        }
    }
}
