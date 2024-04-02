using System.ComponentModel.DataAnnotations;

public class FeedbackModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "App usage feedback is required")]
    public string AppUsage { get; set; }

    [Required(ErrorMessage = "App features feedback is required")]
    public string AppFeatures { get; set; }

    [Required(ErrorMessage = "App improvement feedback is required")]
    public string AppImprovement { get; set; }
}
