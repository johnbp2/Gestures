using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;


namespace JohnBPearson.Windows.Forms.Gestures
{
    public interface IPresenter<T>
    {
        T Form { get; }
        IEnumerable<JohnBPearson.Application.Gestures.Model.IValueObjectFactory> Containers { get; }
        int executeSave(bool overrideAutoSaveSetting);

        void updateContainer(string newData, string description, string key, bool isProtected, string hexString);

        SaveFileDialog SaveDialog {
            get; set;
        }
       // JohnBPearson.Application.Gestures.Model.IValueObjectFactory findKeyBoundValue(string keyValue, bool setToCurrent = false);
    }





}
