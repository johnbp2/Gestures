using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Windows.Forms
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Item
    {
        public string title
        {
            get; set;
        }
        public string text
        {
            get; set;
        }
        public string date
        {
            get; set;
        }
    }

    public class Reminders
    {
        public List<Item> items
        {
            get; set;
        }
    }

    public class Root
    {
        public RemindersForm reminders
        {
            get; set;
        }
    }


    //    public class Reminder
    //    {
    //        public string title
    //        {
    //            get; set;
    //        }
    //        public string text
    //        {
    //            get; set;
    //        }
    //        public string date
    //        {
    //            get; set;
    //        }
    //    }

    //    public class Root
    //    {
    //        public List<Reminder> reminders
    //        {
    //            get; set;
    //        }
    //    }

}
