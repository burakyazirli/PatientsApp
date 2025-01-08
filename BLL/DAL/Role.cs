using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Role
    {
        public int Id { get; set; }

        [Required, StringLength(5)] //admin , user
        public string Name { get; set; }    

        public List<User> Users { get; set; } = new List<User>();
    }
}