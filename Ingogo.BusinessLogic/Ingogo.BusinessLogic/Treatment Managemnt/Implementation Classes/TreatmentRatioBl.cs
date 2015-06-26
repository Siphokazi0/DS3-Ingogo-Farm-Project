using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.BusinessLogic.Treatment_Managemnt.Interface_Classes;
using Ingogo.Data.Treatment_Managemnt.Models;
using Ingogo.Model.Treatment_Managemnt.Model_View;
using Ingogo.Service.Treatment_Managemnt.Implementation_Classes;

namespace Ingogo.BusinessLogic.Treatment_Managemnt.Implementation_Classes
{
    public class TreatmentRatioBl : ITreatmentRatioBl
    {
        private readonly IngredientsRepository _ingredients = new IngredientsRepository();
        private readonly TreatmentPercentageRepository _percentage = new TreatmentPercentageRepository();
        private readonly TreatmentRepository _treatment = new TreatmentRepository();
        
        public List<TreatmentRatioViewPar> GetAll()
        {
            using (var ingredient = new TreatmentRatioRepository())
            {
                return ingredient.GetAll().Select(x => new TreatmentRatioViewPar
                {
                    TreatmentRatioId = x.TreatmentRatioId,
                    IngredientName = _ingredients.GetAll().ToList().Find(y => y.IngredientId == x.IngredientId).IngredientName,
                    TotalMass = x.TotalMass,
                    TreatPrice = x.TreatPrice,
                    TreatmentPercentage = (_percentage.GetAll().ToList().Find(y=>y.TreatmentPercentageId==x.TreatmentPercentageId).Percentage),
                    TreatmentName = _treatment.GetAll().ToList().Find(y=>y.Tid==x.Tid).Tname

                }).ToList();
            }
        }


        public void Add(TreatmentRatioModelView model)
        {
            using (var ratio = new TreatmentRatioRepository())
            {
                string percentage =_percentage.GetAll()
                    .ToList()
                    .Find(x => x.TreatmentPercentageId == model.TreatmentPercentageId)
                    .Percentage;
                int perc = percentage.Length;

                double ingredient =
                    _ingredients.GetAll().ToList().Find(x => x.IngredientId == model.IngredientId).TotalMass;
                decimal treatPriceTot =
                    _ingredients.GetAll().ToList().Find(x => x.IngredientId == model.IngredientId).TotalPrice;
                double mass = (Convert.ToDouble(percentage.Substring(0, perc - 2))/100)*ingredient;

                var treat = new TreatmentRatio
                {
                    TreatmentRatioId = model.TreatmentRatioId,
                    IngredientId = model.IngredientId,
                    TreatmentPercentageId = model.TreatmentPercentageId,
                    TotalMass = mass,
                    TreatPrice = treatPriceTot * (Convert.ToDecimal(percentage.Substring(0, perc - 2)) / 100),
                    Tid = model.Tid
                                
                    
                };
                ratio.Insert(treat);
                var stock = _ingredients.GetAll().ToList().Find(x => x.IngredientId == model.IngredientId);
                if (stock != null)
                {

                    double massLeff = stock.TotalMass - mass;
                    double massRatio = massLeff / stock.IngredientMass;
                    int index = massRatio.ToString(CultureInfo.InvariantCulture).IndexOf('.');

                    int number = 0;
                    if (index > 0)
                    {
                        number = (Convert.ToInt16(massRatio.ToString(CultureInfo.InvariantCulture).Substring(0, index)) + 1);
                        stock.NumIngredients = number;
                    }
                    else
                    {
                        number = Convert.ToInt16(massRatio.ToString(CultureInfo.InvariantCulture));
                        stock.NumIngredients = number;
                    }
                    stock.TotalMass = Math.Round(massLeff,0);
                    _ingredients.Update(stock);

                }
            }
        }

        public void Delete(int id)
        {
            using (var treatment = new TreatmentRatioRepository())
            {
                TreatmentRatio treat = treatment.GetById(id);
                if (treat != null)
                {
                    var stock = _ingredients.GetAll().ToList().Find(x => x.IngredientId == treat.IngredientId);
                    if (stock != null)
                    {
                        double totalMass = (Math.Round(stock.TotalMass, 0) +
                                            Math.Round(Convert.ToDouble(treat.TotalMass), 0));

                        double qtyRatio = totalMass/stock.IngredientMass;
                        int index = qtyRatio.ToString(CultureInfo.InvariantCulture).IndexOf('.');
                        int number;
                        if (index > 0)
                        {
                            number =(Convert.ToInt16(qtyRatio.ToString(CultureInfo.InvariantCulture).Substring(0, index)) +1);
                            stock.NumIngredients = number;
                        }
                        else
                        {
                            number = Convert.ToInt16(qtyRatio.ToString(CultureInfo.InvariantCulture));
                            stock.NumIngredients = number;
                        }
                        stock.TotalMass = totalMass;
                        _ingredients.Update(stock);
                    }

                    treatment.Delete(treat);
                }
            }
        }

        public TreatmentRatioViewPar GetById(int id)
        {
            using (var treatment = new TreatmentRatioRepository())
            {
                TreatmentRatio treat = treatment.GetById(id);
                var treatView = new TreatmentRatioViewPar();
                if (treat != null)
                {
                    treatView.TreatmentRatioId = treat.TreatmentRatioId;
                    treatView.IngredientName = _ingredients.GetAll().ToList().Find(x => x.IngredientId== treat.IngredientId).IngredientName;
                    treatView.TreatmentPercentage = (_percentage.GetAll().ToList().Find(x => x.TreatmentPercentageId == treat.TreatmentPercentageId).Percentage);
                    treatView.TotalMass = treat.TotalMass;
                    treatView.TreatPrice = treat.TreatPrice;
                    treatView.TreatmentName = _treatment.GetAll().ToList().Find(x=>x.Tid==treat.Tid).Tname;
                }
                return treatView;
            }
        }

        public void Update(TreatmentRatioModelView model)
        {
            throw new NotImplementedException();
        }
    }
}
