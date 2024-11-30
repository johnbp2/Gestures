using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Windows.Forms
{
    public class Reminder
    {
        public string titleKey
        {
            get; set;
        }
        public string text
        {
            get; set;
        }
        public string dueDate
        {
            get; set;
        }
    }

    public class Root
    {
        public List<Reminder> reminders
        {
            get; set;
        }
    }

}
