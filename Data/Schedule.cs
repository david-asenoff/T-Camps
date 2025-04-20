using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public class Schedule : BaseDeletableModel<int>
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
