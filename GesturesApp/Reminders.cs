using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JohnBPearson.Windows.Forms
{
    public partial class Reminders : Form
    {
        public Reminders()
        {
            InitializeComponent();
            this.initializeReminders();
        }


        private void initializeReminders()
        {
            int maxReminders = Properties.Settings.Default.MaximumReminders;
            for (int i = 1; i <= maxReminders; i++)
            {

            }


        }
    }
}
