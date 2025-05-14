using System;
using System.ComponentModel.DataAnnotations;

namespace T_Camps.Data
{
    public class ContactFormSubmission : BaseDeletableModel<int>
    {
        [Required(ErrorMessage = "Моля, въведете вашето име.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Моля, въведете имейл адрес.")]
        [EmailAddress(ErrorMessage = "Моля, въведете валиден имейл адрес.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля, въведете телефонен номер.")]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "Моля, изберете тема на запитването.")]
        //public string Topic { get; set; }

        [Required(ErrorMessage = "Моля, въведете съобщение.")]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
