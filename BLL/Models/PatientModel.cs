using BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PatientModel // dto: data transfer object
    {
        public Patient Record{ get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;
        [DisplayName("Female")] //title: DisplayNameFor HTML helper
        public string IsFemale => Record.IsFemale ? "Yes" : "No";

        [DisplayName("Birth Date")]
        public string BirthDate => !Record.BirthDate.HasValue ? string.Empty : Record.BirthDate.Value.ToString("MM/dd/yyyy");

        public string Height => Record.Height.HasValue ? Record.Height.Value.ToString("N2") : "0";
        public string Weight => (Record.Weight ?? 0).ToString("N1");

        public string Branches => Record.Branches?.Name;

        //Way1
        //[DisplayName("Doctors")]
       // public List<Doctor> DoctorList => Record.DoctorPatients?.Select(Dp => Dp.Doctor).ToList();
        
        //Way2
        public string Doctors => string.Join("<br>",Record.DoctorPatients?.Select(dp => dp.Doctor?.Name + " " + dp.Doctor?.Surname));
        [DisplayName("Doctors")]
        public List<int> DoctorIds 
        {  
            get => Record.DoctorPatients?.Select(dp => dp.DoctorId).ToList(); 
            set => Record.DoctorPatients = value.Select(v => new DoctorPatient() { DoctorId = v}).ToList(); 
        }


    }
}
