using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public class Event : BaseDeletableModel<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string LocationMapEmbedUrl { get; set; } // For Google Maps iframe

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string DescriptionShort { get; set; } // For card previews

        [Required]
        public string DescriptionFull { get; set; } // For event details page

        public string MainImageUrl { get; set; } // Hero image

        public List<string> GalleryImageUrls { get; set; } = new(); // Optional gallery (can be a serialized string if needed)

        // Social-specific overrides (can fallback to Company if null)
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? X { get; set; }
        public string? LinkedIn { get; set; }
        public string? YouTube { get; set; }

        public List<Schedule> Schedules { get; set; }
        public List<Speaker> Speakers { get; set; }

        // Linking to Company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
