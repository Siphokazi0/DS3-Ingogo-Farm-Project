using System.Collections.Generic;
using Ingogo.Model.Employee_Management.Model_View;

namespace Ingogo.BusinessLogic.Employee_Management.Interface_Classes
{
    public interface IEmployeeBl
    {
        string AddEmployees(RegisterViewModel model);
        List<RegisterViewModel> GetAllEmployees();
        void DeleteEmployee(int id);
        RegisterViewModel GetEmployeeById(int id);
        void UpdateEmployee(RegisterViewModel model);
        void ChangePassword(string userId);

    }
}
