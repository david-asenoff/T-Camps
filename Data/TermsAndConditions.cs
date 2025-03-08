using System.ComponentModel.DataAnnotations;

namespace T_Camps.Models
{
    public class TermsAndConditions
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}