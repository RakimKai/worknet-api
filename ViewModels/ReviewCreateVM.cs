using System.ComponentModel.DataAnnotations.Schema;
using worknet_api.Models;

namespace worknet_api.ViewModels
{
    public class ReviewCreateVM
    {
        public int CompanyId{ get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
