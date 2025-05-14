using System.Collections.Generic;
using Microsoft.Toolkit.Uwp.Notifications;


namespace JohnBPearson.Windows.Forms.Gestures
{
    public interface IPresenter<T>
    {
        T Form { get; }
        IEnumerable<JohnBPearson.Application.Gestures.Model.IContainer> Containers { get; }
        int executeSave(bool overrideAutoSaveSetting);

        void updateContainer(string newData, string description, string key, bool protect);


        JohnBPearson.Application.Gestures.Model.IContainer findKeyBoundValue(string keyValue, bool setToCurrent = false);
    }





}
