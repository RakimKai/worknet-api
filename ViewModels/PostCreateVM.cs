using System.ComponentModel.DataAnnotations.Schema;
using worknet_api.Models;

namespace worknet_api.ViewModels
{
    public class PostCreateVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public Industry Industry { get; set; }


    }
}
