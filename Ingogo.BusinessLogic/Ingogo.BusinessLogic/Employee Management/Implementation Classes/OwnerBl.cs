//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Ingogo.BusinessLogic.Employee_Management.Interface_Classes;
//using Ingogo.Data.Context;
//using Ingogo.Data.Employee_Management.Models;
//using Ingogo.Model.Employee_Management.Model_View;
//using Ingogo.Service.Employee_Management.Implementation_Classes;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

//namespace Ingogo.BusinessLogic.Employee_Management.Implementation_Classes
//{
//    public class OwnerBl : IOwnerBl
//    {
//        private readonly ApplicationDbContext _db = new ApplicationDbContext();

//        public OwnerBl()
//            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())),
//            new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext())),
//            new OwnerRepository())
//        {
//            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager)
//            {
//                AllowOnlyAlphanumericUserNames = false
//            };
//        }

//        public OwnerBl(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, OwnerRepository ownerRepository)
//        {
//            UserManager = userManager;
//            RoleManager = roleManager;
//        }
//        public UserManager<ApplicationUser> UserManager { get; private set; }
//        public RoleManager<IdentityRole> RoleManager { get; private set; }


      

//        public List<OwnerViewModel> GetAllOwner()
//        {
//            using (var employee = new OwnerRepository())
//            {
//                return employee.GetAll().Select(x => new OwnerViewModel
//                {
//                    UserProfileId = x.UserProfileId,
//                    FirstName = x.FirstName,
//                    LastName = x.LastName,
//                    Gender = x.Gender,
//                    Email = x.Email,
//                    IsFirstTimeLogin = x.IsFirstTimeLogin,

//                }).ToList();
//            }
//        }
     
//        public OwnerViewModel GetOwnerById(int id)
//        {
//            using (var ownerRep = new OwnerRepository())
//            {
//                Owner owner = ownerRep.GetById(id);
//                var ownerView = new OwnerViewModel();
//                if (owner != null)
//                {
//                    ownerView.UserProfileId = owner.UserProfileId;
//                    ownerView.Gender = owner.Gender;
//                    ownerView.FirstName = owner.FirstName;
//                    ownerView.LastName = owner.LastName;
//                    ownerView.Email = owner.Email;
//                    ownerView.IsFirstTimeLogin = owner.IsFirstTimeLogin;
//                }
//                return ownerView;
//            }
//        }
     
//        public void UpdateOwner(OwnerViewModel model, string userId)
//        {
//            using (var ownerRep = new OwnerRepository())
//            {
//                var users = _db.Users.ToList().Find(x => x.Id == userId);
//                Owner owner = ownerRep.GetById(users.UserProfile.UserProfileId);
//                if (owner != null)
//                {
//                    owner.Gender = model.Gender;
//                    owner.Email = users.Email;
//                    owner.FirstName = model.FirstName;
//                    owner.LastName = model.LastName;
//                    owner.IsFirstTimeLogin = false;

//                    ownerRep.Update(owner);
//                }
//            }
//        }

//        public int GetId(string userId)
//        {
//            return  _db.Users.ToList().Find(x => x.Id == userId).UserProfile.UserProfileId;
//        }

        
//    }
//}
