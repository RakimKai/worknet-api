using System.ComponentModel.DataAnnotations.Schema;

namespace worknet_api.Models
{
    public class Review
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Employee))]
        public int ReviewEmployeeId { get; set; } 
        public Employee Employee { get; set; }

        [ForeignKey(nameof(Company))]
        public int ReviewCompanyId { get; set; }
        public Company Company { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
