using BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
    }
}
