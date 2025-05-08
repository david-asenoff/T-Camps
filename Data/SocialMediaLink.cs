namespace T_Camps.Data
{
    public class SocialMediaLink : BaseDeletableModel<int>
    {
        public string Platform { get; set; } // e.g., "Instagram", "Facebook"
        public string? Url { get; set; } // e.g., "https://instagram.com/company"

        // Linking to Company
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
