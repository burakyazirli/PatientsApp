using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Surname { get; set; }
        public Boolean IsFemale { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }

        [Required(ErrorMessage = "Branches is required!")] // ErrorMessage will be shown in the view
        public int? BranchesId { get; set; }

        public Branch Branches { get; set; } // navigational property

        public List<DoctorPatient> DoctorPatients { get; set; } = new List<DoctorPatient>(); // navigational property

    }
}
