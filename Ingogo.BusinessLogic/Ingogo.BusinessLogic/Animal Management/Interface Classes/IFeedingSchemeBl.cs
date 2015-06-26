using System.Collections.Generic;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.BusinessLogic.Animal_Management.Interface_Classes
{
    public interface IFeedingSchemeBl
    {
        FeedingSchemePartialView GetFeedSchemeById(int id);
        List<FeedingSchemePartialView> GetAllFeedSchemeViews();
        void AddFeedScheme(FeedingSchemeView model);
        void UpdateFeedScheme(FeedingSchemePartialView model);
        void DeleteFeedScheme(FeedingSchemeView model);
      //  void FeedSchemeDetails(FeedingSchemeView model);
    }
}
