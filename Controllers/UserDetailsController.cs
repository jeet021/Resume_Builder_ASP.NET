using Microsoft.AspNetCore.Mvc;
using Resume_Builder.Models;

namespace Resume_Builder.Controllers
{
    public class UserDetailsController : Controller
    {
        // GET: UserDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                UserDetails model = new UserDetails(); // Create an instance of UserDetails
                bool success = model.Insert(userDetails); // Call the Insert method to insert data
                if (success)
                {
                    // Redirect to a success page or some other action
                    return NotFound();
                }
                else
                {
                    // Handle insertion failure
                    return View(userDetails); // Return back to the create view with the entered data
                }
            }
            return View(userDetails); // If model state is not valid, return back to the create view with the entered data
        }

        // Action method to display success message
        public IActionResult Success()
        {
            return View();
        }
        // GET: UserDetails/Create
        public IActionResult CreateAbout()
        {
            return View();
        }

        // POST: UserDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAbout(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                UserDetails model = new UserDetails(); // Create an instance of UserDetails
                bool success = model.Insert(userDetails); // Call the Insert method to insert data
                if (success)
                {
                    // Redirect to a success page or some other action
                    return NotFound();
                }
                else
                {
                    // Handle insertion failure
                    return View(userDetails); // Return back to the create view with the entered data
                }
            }
            return View(userDetails); // If model state is not valid, return back to the create view with the entered data
        }

        // Action method to display success message
        public IActionResult SuccessAbout()
        {
            return View();
        }

    }
}
