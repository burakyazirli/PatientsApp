using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IBranchService
    {
        public IQueryable<BranchModel> Query();
        public ServiceBase Create(Branch record);
        public ServiceBase Update(Branch record);
        public ServiceBase Delete(int id);


    }
    public class BranchService : ServiceBase, IBranchService
    {
        public BranchService(Db db) : base(db)
        {
        }
        public IQueryable<BranchModel> Query()
        {
            return _db.Branches.OrderBy(b=>b.Name).Select(b=> new BranchModel() { Record = b }); 
        }
        public ServiceBase Create(Branch record)
        {
            if (_db.Branches.Any(b => b.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Branches with same name exists!");
            record.Name = record.Name?.Trim();
            _db.Branches.Add(record);   
            _db.SaveChanges();// commit to the database
            return Success("Branches created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Branches.Include(b=>b.Patients).SingleOrDefault(b => b.Id == id);
            if (entity == null)
                return Error("Branches cant be found!");
            if (entity.Patients.Any()) //count>0
                return Error("Branch has relational patients");
            _db.Branches.Remove(entity);
            _db.SaveChanges();// commit to the database
            return Success("Branches deleted successfully.");
        }


        public ServiceBase Update(Branch record)
        {
            if (_db.Branches.Any(b => b.Id != record.Id && b.Name.ToUpper()== record.Name.ToUpper().Trim()))
                return Error("Branches with same name exists!");
            //way1
            // var entity = _db.Branches.Find(record.Id);
            //way2
            var entity = _db.Branches.SingleOrDefault(b=>b.Id == record.Id);
            if (entity == null)
                return Error("Branches cant be found!");
            entity.Name = record.Name?.Trim();
            _db.Branches.Update(entity);
            _db.SaveChanges(); // commit to the database
            return Success("Branches updated successfully.");

        }
    }
}
