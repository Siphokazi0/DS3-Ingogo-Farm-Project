using System.Collections.Generic;
using Ingogo.Model.Purchase_Management.Model_View;

//21225381 SD FIKENI: Changed namespace from 'Ingogo.BusinessLogic' to
//'Ingogo.BusinessLogic.Purchase_Management.Interface_Classes'

namespace Ingogo.BusinessLogic.Purchase_Management.Interface_Classes
{
    public interface IFeedingStockBussiness
    {
        List<FeedingStockView> GetAllFeedingStock();
        void AddFeedingStock(FeedingStockView model);
        void DeleteFeedingStock(int id);
        void UpdateFeedingStock(FeedingStockView id);
        FeedingStockView GetFeedingStockById(int id);
    }
}
