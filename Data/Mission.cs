using System.ComponentModel.DataAnnotations;

namespace T_Camps.Models
{
    public class Mission
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
