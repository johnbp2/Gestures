using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;


namespace JohnBPearson.Windows.Forms.Gestures
{
    public interface IPresenter<T>
    {
        T Form { get; }
        IEnumerable<JohnBPearson.Application.Gestures.Model.IGestureObject> Containers { get; }
        int executeSaveAsUserSettings(bool overrideAutoSaveSetting);

        void updateContainer(string newData, string description, string key);

        SaveFileDialog SaveDialog {
            get; set;
        }
       // JohnBPearson.Application.Gestures.Model.IGestureObject findKeyBoundValue(string keyValue, bool setToCurrent = false);
    }





}
