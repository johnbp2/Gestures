using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Common
{
     public interface IBuildInfo
    {

         string PathToAssemblyInfo
        {
            get;
        }

         int Major
        {
            get;
        }
         int Minor
        {
            get;
        }
         int Build
        {
            get;
        }
         int Revision
        {
            get;
        }
    }
}
