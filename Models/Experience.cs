namespace Resume_Builder.Models
{
    public class Experience
    {
        public int UserID { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartMonthYear { get; set; }
        public DateTime EndMonthYear { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
