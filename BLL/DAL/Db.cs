using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Branch> Branches{ get; set; }
        public DbSet<Doctor> Doctors{ get; set; }
        public DbSet<DoctorPatient> DoctorPatients{ get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public Db(DbContextOptions options) : base(options)
        {

        }

    }
}
 