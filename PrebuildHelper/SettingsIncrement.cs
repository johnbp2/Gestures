
using System;
using System.Collections;
using System.Configuration;
using JohnBPearson.Application.Common;

namespace PrebuildHelper
{
    internal class SettingsIncrement // : JohnBPearson.Application.Common.IIncrement
    {
        public SymanticVersion Increment(string AssemblyName)
        {
          
          var test = Properties.Settings.Default.GesturesApp_Revision;

        
          //  SettingsBase.Synchronized();
            foreach(var property in Properties.Settings.Default.PropertyValues )
            {
                SettingsPropertyValue propertValue = (SettingsPropertyValue)property;
                AssemblyName = AssemblyName + "_Revision";
                if(AssemblyName.Equals(propertValue.Name))
                {
                    int revision = (int)propertValue.PropertyValue;
                    int incrementedRevision = revision + 1;
                    propertValue.PropertyValue = incrementedRevision;
                    var ver = new SymanticVersion();
                    ver.Revision = incrementedRevision;
                    Properties.Settings.Default.Save();
                    return ver;
                }

            }
            //while(enumerator.MoveNext())
            //{
            //    SettingsPropertyValue item = (SettingsPropertyValue)enumerator.Current;

            //    //    foreach(DataGridViewRow row in dg_values.Rows)
            //    //    {
            //    if(AssemblyName.Equals(item.Name))
            //    {
            //        int revision = (int)item.PropertyValue;
            //        int incrementedRevision = revision + 1;
            //        item.PropertyValue = incrementedRevision;
            //        var ver = new SymanticVersion();
            //        ver.Revision = incrementedRevision;
            //        Properties.Settings.Default.Save();
            //        return ver;
            //    }

            //}
            var emptyVer = new  SymanticVersion();
            emptyVer.Major = -1;
            emptyVer.Minor = -1;
            emptyVer.Build = -1;
            emptyVer.Revision = -1;
            return emptyVer;
        //    bool found = false;
        //    var exists = Properties.Settings.Default.Properties; // .OfType<SettingsProperty>().Any(p => p.Name == "x");
        //    foreach (var item in exists)
        //    {
        //        var setting = item as SettingsProperty;
        //        if(setting != null)
        //        {
        //            if(setting.Name == AssemblyName + "_Revision")
        //            {
        //                  found = true;
        //                break;
        //            }
        //        }
        //    }
        //    if(!found)
        //    {
        //        Properties.Settings.Default.
        }
    }
}

