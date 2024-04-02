using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authentication;

public class LoginController : Controller
{
    private string connectionString = "Server=DHWAJPC\\SQLEXPRESS;Database=resume_builder;Trusted_Connection=True;";

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Authenticate(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", model.Password);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        // Set success message and redirect to home page
                        HttpContext.Session.SetString("Email1",model.Email);
                        ViewBag.message = "Success";
                        return RedirectToAction("Index", "Home"); // Redirect to home page or dashboard
                    }
                    else
                    {
                        ViewBag.message = "Failed To Login";
                        return View("Index", model); // Return login page with error message
                    }
                }
            }
        }
        return View("Index", model); // Return login page with validation errors
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }
}
