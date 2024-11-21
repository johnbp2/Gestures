using System.Collections.Generic;
using JohnBPearson.Application.Gestures.Model.Utility;

namespace JohnBPearson.Application.Gestures.Model
{
    public interface IContainerList
    {
        IEnumerable<IContainer> Items { get; }
        IList<IContainer> GetItems();
        IEnumerable<string> Keys { get; }

        KeyAndDataStringLiterals PrepareDataForSave();
        KeyAndDataStringLiterals ImportForSave(IEnumerable<IContainer> items);
        string PrepareDataToSaveAsOneSetting();
    }
}