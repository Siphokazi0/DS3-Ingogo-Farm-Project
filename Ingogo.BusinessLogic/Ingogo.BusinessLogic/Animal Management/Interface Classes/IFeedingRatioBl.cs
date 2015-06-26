using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.BusinessLogic.Animal_Management.Interface_Classes
{
    public interface IFeedingRatioBl
    {
        List<FeedingRatioView> GetAllFeedRatio();
        void AddFeedRatio(FeedingRatioView model);
        void DeleteAllIngredientsFromList();
        FeedingRatioView GetFeedRatioById(int id);
    }
}
