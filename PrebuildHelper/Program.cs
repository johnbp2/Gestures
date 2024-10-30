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
    internal class Program
    {
        const string searchString1 = @"[assembly: AssemblyVersion(";
        const string searchString2 = @"[assembly: AssemblyFileVersion(";

        //   const replaceString1 = $"[assembly: AssemblyVersion(\"{0}.2.0.0\")]";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            FileInfo assInfo = new FileInfo(args[0]);
            if(assInfo.Exists)
            {
                var lines = File.ReadAllLines(assInfo.FullName);
                // var contents = File.ReadAllText(assInfo.FullName);

                assInfo.MoveTo($"{args[0]}.back");
                var indexReplace = 0;
                for(global::System.Int32 i = (lines.Length) - (1); i >= 0; i--)
                {
                    if(lines[i].StartsWith(searchString1))
                    {
                        indexReplace = i;
                        break;

                    }
                }

                var contents = new StringBuilder();
                var listLines = lines.ToList();
                listLines.RemoveAt(indexReplace);
                listLines.Insert(indexReplace, $"[assembly: AssemblyVersion(\"{args[1]}.{args[2]}.{args[3]}.{args[4]}\")]");
                foreach(var item in listLines)
                {
                    contents.AppendLine(item);
                }


                File.WriteAllText(args[0], contents.ToString());
            }
        }
    }
}
