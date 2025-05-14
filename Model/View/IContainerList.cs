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
        List<Domain.Entities.Container> MapToEntities();
        void MapFromEntities(List<Domain.Entities.Container> entities);
      

        IContainerList Replace(IContainer oldItem, IContainer newItem);
       // string PrepareDataToSaveAsOneSetting();
    }
}