using System.ComponentModel.DataAnnotations.Schema;

namespace worknet_api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(nameof(Location))]
        public int PostLocationId { get; set; }
        public Location Location { get; set; }

        [ForeignKey(nameof(EmploymentType))]
        public int PostEmploymentTypeId { get; set; }
        public EmploymentType EmploymentType { get; set; }

        [ForeignKey(nameof(Industry))]
        public int PostIndustryId { get; set; }
        public Industry Industry { get; set; }
        public int? Views { get; set; } = 0;

    }
}
