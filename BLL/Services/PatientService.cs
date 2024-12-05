using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    
    public interface IPatientService 
    {
        public IQueryable<PatientModel> Query();
        public ServiceBase Create(Patient record);
        public ServiceBase Update(Patient record);
        public ServiceBase Delete(int id);
    }

    public class PatientService : ServiceBase, IPatientService
    {
        public PatientService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Patient record)
        {
            if (_db.Patients.Any(p => p.Name.ToLower() == record.Name.ToLower().Trim() && p.IsFemale == record.IsFemale &&
                p.BirthDate == record.BirthDate))
                return Error("Patinents with same name, birthdate and gender exists!");
            record.Name = record.Name?.Trim();
            _db.Patients.Add(record);
            _db.SaveChanges();
            return Success("Patinet created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Patients.Include(p => p.DoctorPatients).SingleOrDefault(p => p.Id == id);
            if (entity == null)
                return Error("Patients cant be found!");
            _db.DoctorPatients.RemoveRange(entity.DoctorPatients);
            _db.Patients.Remove(entity);
            _db.SaveChanges();// commit to the database
            return Success("Patient deleted successfully.");
        }

        public IQueryable<PatientModel> Query()
        {
            return _db.Patients.Include(p=> p.Branches).OrderByDescending(p => p.BirthDate).ThenByDescending(p => p.IsFemale).ThenBy(p => p.Name).
                Select(p => new PatientModel() { Record = p });
        }

        public ServiceBase Update(Patient record)
        {
            if (_db.Patients.Any(p=>p.Id != record.Id && p.Name.ToLower() == record.Name.ToLower().Trim() && p.IsFemale == record.IsFemale &&
               p.BirthDate == record.BirthDate))
                return Error("Patinents with same name, birthdate and gender exists!");
            record.Name = record.Name?.Trim();
            _db.Patients.Update(record);
            _db.SaveChanges();
            return Success("Patinet updated successfully.");
        }
    }
}
