using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.BusinessLogic.Animal_Management.Interface_Classes
{
    public interface IFeedingIngredientBl
    {
        List<FeedingIngredientViewParAll> GetAllFeedIngr();
        void AddFeedIngr(FeedingIngredientsView model);
        void DeleteFeedIngr(int id);
        FeedingIngredientViewParAll GetFeedIngrById(int id);
        void UpdateFeedIngr(FeedingIngredientsView model);
    }
}
