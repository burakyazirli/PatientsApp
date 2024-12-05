using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Branch
    {
        public int Id {  get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }  = new List<Patient>();
    }
}
