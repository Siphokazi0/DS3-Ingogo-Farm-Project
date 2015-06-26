using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes;
using Ingogo.Data.Treatment_Managemnt.Models;
using Ingogo.Model.Treatment_Managemnt.Model_View;
using Ingogo.Service.Treatment_Managemnt.Implementation_Classes;

namespace Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes
{
    public class TreatmentIngredientsBl : ITreatmentIngredientsBl
    {
        public List<IngredientsViewPar> GetAll()
        {
            using (var ingredient = new IngredientsRepository())
            {
                return ingredient.GetAll().Select(x => new IngredientsViewPar
                {
                    IngredientId = x.IngredientId,
                    IngredientName = x.IngredientName,
                    NumIngredients = x.NumIngredients,
                    IngredientMass = x.IngredientMass,
                    Ingredientprice = x.Ingredientprice,
                    TotalPrice = x.TotalPrice,
                    TotalMass = x.TotalMass,   
                }).ToList();
            }
        }

        public void Add(IngredientsModelView model)
        {
            using (var ingredient = new IngredientsRepository())
            {
                var treat = new TreatmentIngredients
                {
                    IngredientId = model.IngredientId,
                    IngredientName = model.IngredientName,
                    NumIngredients = model.NumIngredients,
                    IngredientMass = model.IngredientMass,
                    Ingredientprice = model.Ingredientprice,
                    TotalPrice = model.Ingredientprice*model.NumIngredients,
                    TotalMass = model.IngredientMass * model.NumIngredients   
                };
                ingredient.Insert(treat);
            }
        }

        public void Delete(int id)
        {
            using (var ingredient = new IngredientsRepository())
            {
                TreatmentIngredients treat = ingredient.GetById(id);
                if (treat != null)
                {
                    ingredient.Delete(treat);
                }
            }
        }

        public IngredientsViewPar GetById(int id)
        {
            using (var ingredient = new IngredientsRepository())
            {
                TreatmentIngredients treat = ingredient.GetById(id);
                var ingredientview = new IngredientsViewPar();
                if (treat != null)
                {
                    ingredientview.IngredientId = treat.IngredientId;
                    ingredientview.IngredientName = treat.IngredientName;
                    ingredientview.NumIngredients = treat.NumIngredients;
                    ingredientview.IngredientMass = treat.IngredientMass;
                    ingredientview.Ingredientprice = treat.Ingredientprice;
                    ingredientview.TotalPrice = treat.TotalPrice;
                    ingredientview.TotalMass = treat.TotalMass;

                }
                return ingredientview;
            }
        }

        public void Update(IngredientsViewPar model)
        {
            using (var ingredient = new IngredientsRepository())
            {
                TreatmentIngredients treat = ingredient.GetById(model.IngredientId);
                if (treat != null)
                {
                    treat.IngredientId = model.IngredientId;
                    treat.IngredientName = model.IngredientName;
                    treat.NumIngredients = model.NumIngredients;
                    treat.IngredientMass = model.IngredientMass;
                    treat.Ingredientprice = model.Ingredientprice;
                    treat.TotalPrice = model.Ingredientprice*model.NumIngredients;
                    treat.TotalMass = model.IngredientMass * model.NumIngredients;
                    ingredient.Update(treat);
                }
            }
        }
    }
}
