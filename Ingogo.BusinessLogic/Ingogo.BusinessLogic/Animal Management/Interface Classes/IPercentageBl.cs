using System.Collections.Generic;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.BusinessLogic.Animal_Management.Interface_Classes
{
    public interface IPercentageBl
    {
        List<PercentagePartialView> GetAllIngredients();
        PercentagePartialView GetPercView(int id);
        void AddPercent(PercentageView model);
        void DeletePercent(PercentageView model);
       // void UpdatePercent(PercentagePartialView model);
        //void PercentDetails(PercentageView model);
    }
}
