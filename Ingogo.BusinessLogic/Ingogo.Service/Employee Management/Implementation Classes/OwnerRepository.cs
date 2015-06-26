//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Ingogo.Data.Context;
//using Ingogo.Data.Employee_Management.Models;
//using Ingogo.Data.Repository;

//namespace Ingogo.Service.Employee_Management.Implementation_Classes
//{
//    public class OwnerRepository : IDisposable
//    //{
//    //    private ApplicationDbContext _datacontext;
//    //    private readonly IRepository<Owner> _ownerRepository;

//    //    public OwnerRepository()
//    //    {
//    //        _datacontext = new ApplicationDbContext();
//    //        _ownerRepository = new RepositoryService<Owner>(_datacontext);
            
//    //    }
//    //    //

//    //    public Owner GetById(int id)
//    //    {
//    //        return _ownerRepository.GetById(id);
//    //    }

//    //    public List<Owner> GetAll()
//    //    {
//    //        return _ownerRepository.GetAll().ToList();
//    //    }

//    //    public void Insert(Owner model)
//    //    {
//    //        _ownerRepository.Insert(model);
//    //    }

//    //    public void Update(Owner model)
//    //    {
//    //        _ownerRepository.Update(model);
//    //    }

//    //    public void Delete(Owner model)
//    //    {
//    //        _ownerRepository.Delete(model);
//    //    }

//    //    public IEnumerable<Owner> Find(Func<Owner, bool> predicate)
//    //    {
//    //       return _ownerRepository.Find(predicate).ToList();
//    //    }

//    //    public void Dispose()
//    //    {
//    //        _datacontext.Dispose();
//    //        _datacontext = null;
//    //    }

//    }
//}
