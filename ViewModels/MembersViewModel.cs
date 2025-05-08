using System.ComponentModel.DataAnnotations;
using T_Camps.Data;

namespace T_Camps.ViewModels
{
    public class MembersViewModel : Member
    {
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
    }
}