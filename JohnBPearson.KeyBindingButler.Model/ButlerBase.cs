using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model
{
    public enum TimeDayOrNight
    {
    PM,    
    AM
    }
    public class ButlerBase
    {
        private string _myName = "";
        /// <summary>
        /// constructs a new butler and provides a name for him. 
        /// </summary>
        /// <param name="hisName">your butler's name for god sake man</param>
        protected ButlerBase(string hisName)
        {
            if (string.IsNullOrWhiteSpace(hisName)){
                throw new ButlerIndiscretion("Shame on you. He needs a name.", new ArgumentException("Parameter must be an english name", "hisName"));
            }
            this._myName = hisName;
        }

       public TimeDayOrNight TellMeTheTime()
        {
            // -1 = before noon; 0 = noon; 1 = afternoon
            var test = DateTime.Now.CompareTo(DateTime.ParseExact($"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day} 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
        if(test < 0) { return TimeDayOrNight.AM; }
            return TimeDayOrNight.PM;
        
        }
       // var test = DateTime.Now.CompareTo(DateTime.ParseExact($"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day} 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
    }


    public class ButlerIndiscretion: Exception
    {
        public ButlerIndiscretion(string message) : base(message) { 
        }


        public ButlerIndiscretion(string message, Exception innerException) : base(message, innerException) { 
        }
    }
}
