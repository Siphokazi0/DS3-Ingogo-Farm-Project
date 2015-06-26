using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.Model.Animal_Management.Model_View;

namespace Ingogo.BusinessLogic.Animal_Management.Interface_Classes
{
    public interface IDeadBL
    {
        Animalpar GetDeadById(int id);
        List<Animalpar> GetAllDeadAnimals();
        void InsertDeadAnimals(Animalpar model);
        void UpdateDeadAnimals(Animalpar model);
        void DeleteDeadAnimals(int id);
        
       
    }
}
