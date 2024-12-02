using System;
using System.ComponentModel;
using System.Text;

namespace Extension
{
    public static class Extension
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }


        public static string ReplaceOne(this string str, string oldStr, string newStr)
        {
            StringBuilder sb = new StringBuilder(str);
            int index = str.IndexOf(oldStr);
            if(index > -1)
                return str.Substring(0, index) + newStr + str.Substring(index + oldStr.Length);
            return str;
        }

        //public static T GetEnumValueByDescription<T>(this Enum description) where T : Enum
        //{
        //    foreach (Enum enumItem in Enum.GetValues(typeof(T)))
        //    {
        //        if (enumItem.GetEnumDescription() == description)
        //        {
        //            return (T)enumItem;
        //        }
        //    }
        //    throw new ArgumentException("Not found.", nameof(description));
        //}

    }
}