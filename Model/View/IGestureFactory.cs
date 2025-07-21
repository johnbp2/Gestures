using System.Collections.Generic;
using System.IO;
using JohnBPearson.Application.Gestures.Model.Utility;

namespace JohnBPearson.Application.Gestures.Model
{
    public interface IGestureFactory
    {
        IEnumerable<IGestureObject> Items { get; }
        IList<IGestureObject> GetItems();
        IEnumerable<string> Keys { get; }

        Dto PrepareDataForSave();
        List<Domain.Entities.GestureDTO> MapToEntities();
        void MapFromEntities(List<Domain.Entities.GestureDTO> entities);
      

        IGestureFactory Replace(IGestureObject oldItem, IGestureObject newItem);
       // string PrepareDataToSaveAsOneSetting();
    }
}