using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public class TermsAndConditions : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(200)]
        public string SectionTitle { get; set; }
        [Required]
        public string Content { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}