using System.Collections.Generic;

namespace JohnBPearson.KeyBindingButler.Model
{
    public interface IContainerList
    {
        IEnumerable<IContainer> Items { get; }
        IList<IContainer> GetItems();
        IEnumerable<string> Keys { get; }

        KeyAndDataStringLiterals PrepareDataForSave();
        string PrepareDataToSaveAsOneSetting();
    }
}