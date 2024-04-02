using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Resume_Builder.Models;

public class ContactController : Controller
{
    private readonly string connectionString = "Server=DHWAJPC\\SQLEXPRESS;Database=resume_builder;Trusted_Connection=True;";

    public IActionResult Index()
    {
        var model = new ContactModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult SubmitMessage(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO ContactMessages (Name, Email, Message) VALUES (@Name, @Email, @Message)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Message", model.Message);
                    command.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Index"); // Redirect to a thank you page or the same page with a success message
        }
        return View("Index", model); // Return the form with validation errors
    }
}
