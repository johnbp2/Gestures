using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Cypher
{
    internal class Logger
    {
        internal static void logToConsole(string toLog)
        {
            logToConsole(toLog, true);
        }
        internal static void logToConsole(string toLog, bool writeLine)
        {
            logToConsole(toLog, null, writeLine);
        }
        internal static void logToConsole(string toLog, string[] formattingStrings, bool writeLine = true)
        {
            if(string.IsNullOrEmpty(toLog))
            {
                return;
            }

            string output = "";
            if(formattingStrings == null || formattingStrings.Length == 0)
            {

                output = toLog;

            }
            else
            {
                output = string.Format(toLog, formattingStrings);
            }
            if(writeLine)
            {

                Console.WriteLine(output);
            }
            else
            {
                Console.Write(output);
            }

        }

    }
}
