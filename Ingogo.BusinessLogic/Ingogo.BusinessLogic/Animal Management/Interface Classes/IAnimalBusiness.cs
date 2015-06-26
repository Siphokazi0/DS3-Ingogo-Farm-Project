using System.Collections.Generic;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.BusinessLogic.Animal_Management.Interface_Classes
{
    public interface IAnimalBusiness
    {
        List<Animalpar> GetAllAnimals();
        void InsertAnimals(AnimalView model);
        void DeleteAnimals(Animalpar model);
        void UpdateAnimals(Animalpar animalView);
        void AnimalDetails(AnimalView animalView);
        Animalpar GetAnimalById(int id);
    }
}
