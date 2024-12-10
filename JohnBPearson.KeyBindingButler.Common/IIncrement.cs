using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Application.Common;

namespace JohnBPearson.Application.Common
{
    public interface IIncrement
    {

        SymanticVersion Increment(SymanticVersion version);
    }
}
