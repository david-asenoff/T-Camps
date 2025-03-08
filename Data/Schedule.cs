using System;
using System.ComponentModel.DataAnnotations;

namespace T_Camps.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
