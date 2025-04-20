using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public class Client: BaseDeletableModel<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string Description { get; set; }
    }
}
