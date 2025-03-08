using System.ComponentModel.DataAnnotations;

namespace T_Camps.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
