using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public class Speaker : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
