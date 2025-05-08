using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public partial class Company : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        [Required]
        public string Moto { get; set; }
        [Required]
        public string WelcomeMessage { get; set; }
        [Required]
        public string About { get; set; }
        public List<Mission> Missions { get; set; }
        public List<Service> Services { get; set; }
        public List<Member> Members { get; set; }
        public List<TermsAndConditions> TermsAndConditions { get; set; }
        [Required]
        public string JoinInformation { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<SocialMediaLink> SocialMediaLinks { get; set; }
        public List<Event> Events { get; set; }
    }
}
