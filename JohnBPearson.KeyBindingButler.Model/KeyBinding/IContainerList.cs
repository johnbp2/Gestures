using System.Collections.Generic;

namespace JohnBPearson.KeyBindingButler.Model
{
    public interface IContainerList
    {
        IEnumerable<IContainer> Items { get; }
        IEnumerable<string> Keys { get; }

        KeyAndDataStringLiterals PrepareDataForSave();
        string PrepareDataToSaveAsOneSetting();
    }
}