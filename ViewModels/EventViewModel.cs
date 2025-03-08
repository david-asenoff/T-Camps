using System.ComponentModel.DataAnnotations;
using T_Camps.Models;

namespace T_Camps.ViewModels
{
    public class EventViewModel
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}