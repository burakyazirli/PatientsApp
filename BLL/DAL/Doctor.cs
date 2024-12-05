using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BranchId { get; set; }
        public List<DoctorPatient> DoctorPatients{ get; set; } = new List<DoctorPatient>();
    }
}
