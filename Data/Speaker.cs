using System.ComponentModel.DataAnnotations;

namespace T_Camps.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
