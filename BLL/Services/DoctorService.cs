using Azure.Identity;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorService : ServiceBase, IService<Doctor, DoctorModel>
    {
        public DoctorService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Doctor record)
        {
            throw new NotImplementedException();
        }

        public ServiceBase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DoctorModel> Query()
        {
            return _db.Doctors.OrderBy(d => d.Name).ThenBy(d => d.Surname).Select(d => new DoctorModel() { Record = d });
        }

        public ServiceBase Update(Doctor record)
        {
            throw new NotImplementedException();
        }
    }
}
