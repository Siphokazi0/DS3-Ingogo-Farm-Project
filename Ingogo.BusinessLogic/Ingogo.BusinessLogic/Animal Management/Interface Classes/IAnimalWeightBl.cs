using System.Collections.Generic;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.BusinessLogic.Animal_Management.Interface_Classes
{
    public interface IAnimalWeightBl
    {

        List<AnimalWeightViewPar> GetAllAnimalWeight();
        void AddAnimalWeight(AnimalWeightView model);
        void DeleteAnimalWeight(int id);
        AnimalWeightViewPar GetByIdAnimalWeight(int id);
        void UpdateAnimalWeight(AnimalWeightViewPar model);

    }
}
