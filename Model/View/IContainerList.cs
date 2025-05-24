using System.Collections.Generic;
using System.IO;
using JohnBPearson.Application.Gestures.Model.Utility;

namespace JohnBPearson.Application.Gestures.Model
{
    public interface IContainerList
    {
        IEnumerable<IContainer> Items { get; }
        IList<IContainer> GetItems();
        IEnumerable<string> Keys { get; }

        KeyAndDataStringLiterals PrepareDataForSave();
        List<Domain.Entities.ContainerEntity> MapToEntities();
        void MapFromEntities(List<Domain.Entities.ContainerEntity> entities);
      

        IContainerList Replace(IContainer oldItem, IContainer newItem);
       // string PrepareDataToSaveAsOneSetting();
    }
}