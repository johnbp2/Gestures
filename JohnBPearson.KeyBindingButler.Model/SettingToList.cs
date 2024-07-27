using JohnBPearson.com.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.KeyBindingButler.Model
{
    public class SettingToList
    {
        public IEnumerable<string> List {  get; set; }

        public SettingToList(string setting) {

            this.List = Parser.parseStringToList(setting, '|');
            
        }
    }
}
