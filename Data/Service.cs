using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public class Service : BaseDeletableModel<int>
    {
        [Required]
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
