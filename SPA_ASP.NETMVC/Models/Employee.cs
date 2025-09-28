using System.ComponentModel.DataAnnotations;

namespace SPA_ASP.NETMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
    }
}
