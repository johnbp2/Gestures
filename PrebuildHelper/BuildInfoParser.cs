using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace PrebuildHelper
{

    internal struct SymanticVersion
    {
        internal int Major;
        internal int Minor;
        internal int Build;
        internal int Revision;
    }
   static class BuildInfoParser
    {
         
        static BuildInfo Parse(string pathToAssemblyInfo, string strMajor, string strMinor, string strBuild, string strR4evision)
        {
            int temp = -1;
            SymanticVersion version = new SymanticVersion();
            int.TryParse(strMajor, out temp);
            version.Major= temp;
            temp = -1;
            int.TryParse(strMinor, out temp);
            version.Minor= temp;
            temp = -1;
            int.TryParse(strBuild, out temp);
            version.Build= temp;
            temp= -1;
            int.TryParse(strR4evision, out temp);
            version.Revision= temp;

            return new BuildInfo(pathToAssemblyInfo, version);

        }
    }
}
