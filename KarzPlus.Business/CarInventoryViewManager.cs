using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarzPlus.Entities;
using KarzPlus.Data;

namespace KarzPlus.Business
{
    /// <summary>
    /// This class encapsulates the business logic of CarInventoryViewManager entity
    /// </summary>
    public static class CarInventoryViewManager
    {
        /// <summary>
        /// Searches for CarInventoryView
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of CarInventoryView</returns>
        public static IEnumerable<CarInventoryView> Search(CarInventoryViewSearch search)
        {
            return search == null ? new List<CarInventoryView>() : CarInventoryViewDao.Search(search);
        }

        public static IEnumerable<CarInventoryView> GetOnSearchFields(int? makeId, int? modelId, string state)
        {
            CarInventoryViewSearch search = new CarInventoryViewSearch
            {
                MakeId = makeId,
                ModelId = modelId,
                State = state
            };
            return Search(search);
        }
    }
}
