using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Resume_Builder.Models;
public class FeedbackController : Controller
{
    private string connectionString = "Server=DHWAJPC\\SQLEXPRESS;Database=resume_builder;Trusted_Connection=True;";

    public IActionResult Index()
    {
        var model = new FeedbackModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult SubmitFeedback(FeedbackModel model)
    {
        if (ModelState.IsValid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Feedback (Name, Phone, AppUsage, AppFeatures, AppImprovement) VALUES (@Name, @Phone, @AppUsage, @AppFeatures, @AppImprovement)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Phone", model.Phone);
                    command.Parameters.AddWithValue("@AppUsage", model.AppUsage);
                    command.Parameters.AddWithValue("@AppFeatures", model.AppFeatures);
                    command.Parameters.AddWithValue("@AppImprovement", model.AppImprovement);
                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index"); // Redirect to a thank you page or the same page with a success message
        }
        return View("Index", model); // Return the form with validation errors
    }
}
