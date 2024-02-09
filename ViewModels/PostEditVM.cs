using System.ComponentModel.DataAnnotations.Schema;
using worknet_api.Models;

namespace worknet_api.ViewModels
{
    public class PostEditVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
    }
}
