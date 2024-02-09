namespace worknet_api.ViewModels
{
    public class SearchVM
    {
        public string? JobTitle {  get; set; }
        public string? Company { get; set; }
        public string? Industry { get; set;}
        public string? Location { get; set;}
        public string? EmploymentType { get; set; }
        public bool Popular { get; set; } = false;
        public int PerPage { get; set; }
        public int Page { get; set; }


    }
}
