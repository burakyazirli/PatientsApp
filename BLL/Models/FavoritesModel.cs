using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class FavoritesModel
    {
        public int PatientId { get; set; }
        public int UserId { get; set; }
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }
    }
}
