using System.Collections.Generic;

namespace JohnBPearson.KeyBindingButler.Model
{
    public interface IKeyBoundDataList
    {
        IEnumerable<IKeyBoundData> Items { get; }
        IEnumerable<string> Keys { get; }

        KeyAndDataStringLiterals PrepareDataForSave();
        string PrepareDataToSaveAsOneSetting();
    }
}