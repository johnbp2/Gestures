using System.Collections.Generic;
using System.IO;
using JohnBPearson.Application.Gestures.Model.Utility;

namespace JohnBPearson.Application.Gestures.Model
{
    public interface IEntityFactory
    {
        IEnumerable<IValueObjectFactory> Items { get; }
        IList<IValueObjectFactory> GetItems();
        IEnumerable<string> Keys { get; }

        KeyAndDataStringLiterals PrepareDataForSave();
        List<Domain.Entities.ContainerEntity> MapToEntities();
        void MapFromEntities(List<Domain.Entities.ContainerEntity> entities);
      

        IEntityFactory Replace(IValueObjectFactory oldItem, IValueObjectFactory newItem);
       // string PrepareDataToSaveAsOneSetting();
    }
}