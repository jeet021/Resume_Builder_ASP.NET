using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Resume_Builder.Models;
public class RegisterController : Controller
{
    private string connectionString = "Server=DHWAJPC\\SQLEXPRESS;Database=resume_builder;Trusted_Connection=True;";

    public IActionResult Index()
    {
        var model = new RegisterModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            // Insert registration data into the database
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", model.Password);
                    command.ExecuteNonQuery();
                }
            }
            // Redirect to a success page or login page
            ViewBag.message = "Success";
            return RedirectToAction("Index", "Login");
        }
        // If model state is not valid, return the view with validation errors
        ViewBag.message = "Failed To Login";
        return View("Index", model);
    }
}
