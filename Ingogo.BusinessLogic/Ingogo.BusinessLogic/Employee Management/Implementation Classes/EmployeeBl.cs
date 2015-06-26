using System;
using System.Collections.Generic;
using System.Linq;
using Ingogo.BusinessLogic.Employee_Management.Interface_Classes;
using Ingogo.Data.Context;
using Ingogo.Data.Employee_Management.Models;
using Ingogo.Model.Employee_Management.Model_View;
using Ingogo.Service.Employee_Management.Implementation_Classes;
using Ingogo.Service.Employee_Management.Interface_Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ingogo.BusinessLogic.Employee_Management.Implementation_Classes
{
    public class EmployeeBl : IEmployeeBl
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        Email _email = new Email();

        public EmployeeBl()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())),
            new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())),
            new EmployeeRepository())
        {
            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public EmployeeBl(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IEmployeeRepository employeeService)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }

        public string AddEmployees(RegisterViewModel model)
        {
            string feedback = "There Is Already An Employee With The Same Information";

            //Generate password
            string password = "123456";//"SPBFI" + Guid.NewGuid().ToString().Substring(0, 8);

            //Generate Gender
            var gender = Convert.ToInt16(model.IdentityNumber.Substring(6, 1)) < 5 ? "Female" : "Male";


            //create user 
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                UserProfile = new Employees
                {
                    UserProfileId = model.UserProfileId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = gender,
                    ContactNumber = model.ContactNumber,
                    Email = model.Email,
                    PhysicalAddress = model.PhysicalAddress,
                    IdentityNumber = model.IdentityNumber,
                    IsFirstTimeLogin = true,
                    Position = model.Position
                }
            };

            //create user in the aspnet table
            var result = UserManager.Create(user, password);

            if (result.Succeeded)
            {
                feedback = model.Email.Trim() + "~" + user.Id + "Hello! " + model.FirstName.Substring(0, 1) + ". " + model.LastName
                           + "<br/>The following are your log in credentials.<br/>"
                           + "UserName: " + model.Email
                           + "<br/>Password: " + password
                           +
                           "<br/><br>Please note that you are required to change password on your first time log in"
                           + "<br/>-----Email by SPBFI-System-----";

                //create role
                if (!RoleManager.RoleExists(model.Position))
                {
                    RoleManager.Create(new IdentityRole { Name = model.Position });
                }
                //assign user to role
                UserManager.AddToRole(user.Id, model.Position);
            }
            return feedback;
        }

        public List<RegisterViewModel> GetAllEmployees()
        {
            using (var employee = new EmployeeRepository())
            {
                return employee.GetAll().Select(x => new RegisterViewModel
                {
                    UserProfileId = x.UserProfileId,
                    FirstName = x.FirstName.Substring(0, 1) + " " + x.LastName,
                    IdentityNumber = x.IdentityNumber,
                    Gender = x.Gender,
                    Email = x.Email,
                    PhysicalAddress = x.PhysicalAddress,
                    ContactNumber = x.ContactNumber,
                    Position = x.Position,
                    IsFirstTimeLogin = x.IsFirstTimeLogin

                }).ToList();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var employeeRep = new EmployeeRepository())
            {
                Employees emp = employeeRep.GetById(id);
                var user = _db.Users.Find(id);
                if (user.Id != null)
                {
                    _db.Users.Remove(user);
                    employeeRep.Delete(emp);
                }

            }
        }

        public RegisterViewModel GetEmployeeById(int id)
        {
            using (var employeeRep = new EmployeeRepository())
            {
                Employees emp = employeeRep.GetById(id);
                var empView = new RegisterViewModel();
                if (emp != null)
                {
                    empView.UserProfileId = emp.UserProfileId;
                    empView.Position = emp.Position;
                    empView.ContactNumber = emp.ContactNumber;
                    empView.Email = emp.Email;
                    empView.FirstName = emp.FirstName;
                    empView.Gender = emp.Gender;
                    empView.IdentityNumber = emp.IdentityNumber;
                    empView.LastName = emp.LastName;
                    empView.PhysicalAddress = emp.PhysicalAddress;
                    empView.IsFirstTimeLogin = emp.IsFirstTimeLogin;
                }
                return empView;
            }
        }

        public void UpdateEmployee(RegisterViewModel model)
        {
            using (var employee = new EmployeeRepository())
            {
                Employees emp = employee.GetById(model.UserProfileId);
                if (emp != null)
                {
                    emp.ContactNumber = model.ContactNumber;
                    emp.FirstName = model.FirstName;
                    emp.LastName = model.LastName;
                    emp.PhysicalAddress = model.PhysicalAddress;
                    emp.Position = model.Position;
                    emp.Email = model.Email;
                    emp.Gender = model.Gender;
                    emp.IdentityNumber = model.IdentityNumber;
                    emp.IsFirstTimeLogin = model.IsFirstTimeLogin;

                    employee.Update(emp);
                }
            }
        }

        public void ChangePassword(string userId)
        {
            ApplicationUser appUser = _db.Users.Find(userId);
            appUser.UserProfile.IsFirstTimeLogin = false;
            _db.SaveChanges();
        }

        public RegisterViewModel GetEmployeeNames(string userId)
        {
            using (var employee = new EmployeeRepository())
            {
                ApplicationUser appUser = _db.Users.Find(userId);
                var emp = employee.GetById(appUser.UserProfile.UserProfileId);
                var empView = new RegisterViewModel();
                if (emp != null)
                {
                    empView.FirstName = emp.FirstName;
                    empView.LastName = emp.LastName;
                    empView.Position = emp.Position;
                }
                return empView;

            }
        }

        public List<DashboardView> CurrentUserDetails(string userId)
        {
            List<ApplicationUser> emp = _db.Users.ToList().Where(x => x.Id == userId).ToList();
            return emp.Select(x => new DashboardView
            {
                UserProfileId = x.UserProfile.UserProfileId,
                Email = x.Email,
                FirstName = x.UserProfile.FirstName,
                LastName = x.UserProfile.LastName
            }).ToList();
            //
        }
    }
}

