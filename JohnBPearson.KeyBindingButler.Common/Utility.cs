using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Common
{
   public static class Utility
    {

        public static T ToEnum<T>(this string value)
    where T : struct
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
