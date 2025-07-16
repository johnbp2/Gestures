using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Application.Gestures.Model.Utility
{
    public class Mapper
    {


        public  static Dto mapToDto(StringCollection isProtected, StringCollection dataLengths, StringCollection hexStrings, StringCollection description, StringCollection data)
        {
            var dto = new Dto();
            //dto.Values = Properties.Settings.Default.DataValues;
            //dto.Keys = Properties.Settings.Default.BindableKeys;
            //dto.Descriptions = Properties.Settings.Default.Descriptions;;

            //dto.Protect = GestureFactory.ParseStringsToBools(Properties.Settings.Default.Protect);
            string item = "false";
            UserSettingsValidator.validateCollection(isProtected, true, item);
            dto.IsProtected = GestureFactory.ParseStringsToBools(isProtected);
            dto.DataLengths = GestureFactory.paresStringsToInts(dataLengths);
            dto.HexStrings = hexStrings.Cast<string>().ToList();
            dto.Data = new string[26];
          //  UserSettingsValidator.validateStringCollection<string>(data as IList<string>, true);

           data.CopyTo(dto.Data, 0);
            dto.Description = new string[26];
            description.CopyTo(dto.Description, 0);
            data.CopyTo(dto.Data, 0);
            return dto;
            //this._containerList = new JohnBPearson.Application.Gestures.Model.GestureFactory(dto);
        }
    }
}
