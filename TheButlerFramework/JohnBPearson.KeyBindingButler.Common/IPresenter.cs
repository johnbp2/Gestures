using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.KeyBindingButler.Common
{
    public interface IPresenter<T>
    {
        T Form
        {
            get;
        }
        IEnumerable<JohnBPearson.KeyBindingButler.Model.IContainer> Containers
        {
            get;
        }
        int executeAutoSave(bool overrideAutoSaveSetting, string encryptionFlags, bool encrypt);

        void updateContainer(string newData, string description, string key, bool isSecured);


        JohnBPearson.KeyBindingButler.Model.IContainer findKeyBoundValue(string keyValue);
    }
}
