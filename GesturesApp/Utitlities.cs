using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohnBPearson.NET.Extensions
{
    static class Utitlities
    {
        static string reminderString = "Reminder";
        public static string ToReminderString(string string1, int myNumber, int maximumReminders)
        {
            var maximumRemindersString = maximumReminders.ToString();
            var paddingCount = maximumRemindersString.Count();
            paddingCount++;
            var numberText = myNumber.ToString();
            paddingCount= paddingCount - numberText.Count();
            if (paddingCount > 0)
            {


                numberText = numberText.PadLeft(paddingCount + numberText.Count(), '0');

            }

            return string.Concat(Utitlities.reminderString, numberText);
                
                //return str.Split(new char[] { ' ', '.', '?' },
            //                 StringSplitOptions.RemoveEmptyEntries).Length;
        }   
    }
}