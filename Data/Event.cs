using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace T_Camps.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Speaker> Speakers { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
