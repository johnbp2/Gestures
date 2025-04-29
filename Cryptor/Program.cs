using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Cypher;

namespace Cryptor
{
    internal enum option
    {
        Encrypt = 1,
        Decrypt = 2,
    }
    internal class Program
    {
        static int Main(string[] args)
        {
         //   DataProtectionService mp = new DataProtectionService();
     
                if(args.Length == 0 || args.Length == 1 || string.IsNullOrWhiteSpace(args[1]))
                {
                    //  Console.Beep();
                    Console.WriteLine("you must provide 2 arguments.");
                    Console.WriteLine("cryptor {1|2} String");
                    return 0;
                }
            bool optionValid = false;
            int optionValue = 0;
            if(int.TryParse(args[0], out optionValue))
            {
                if(optionValue != 1 && optionValue != 2)
                {
                    Console.WriteLine("arguement out of range. must be 1 or 2.");
                    return 1;

                }
                optionValid = true;
            }


            if(optionValid)
            {
                switch(optionValue)
                {
                    case 1:
                     //   Console.WriteLine(mp.Encrypt(args[1]));
                     DataProtectionService.Encrypt(args[1]);
                        break;
                    case 2:
                       DataProtectionService.Decrypt(args[1]);
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
                return 0;
            }
            return 1;
        }
    }
}
