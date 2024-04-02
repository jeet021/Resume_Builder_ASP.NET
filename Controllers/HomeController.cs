using Microsoft.AspNetCore.Mvc;
using Resume_Builder.Models;
using System.Diagnostics;
using Rotativa.AspNetCore;
namespace Resume_Builder.Controllers
{
    public class HomeController : Controller
    {
        UserDetails objmodel = new UserDetails();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Popup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Popup(UserDetails userDetails)
        {
                objmodel = new UserDetails();
                // Create an instance of UserDetails
                bool success = objmodel.Insert(userDetails); // Call the Insert method to insert data
                if (success)
                {
                    // Redirect to a success page or some other action
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    // Handle insertion failure
                    return View(userDetails); // Return back to the create view with the entered data
                }
      
             // If model state is not valid, return back to the create view with the entered data
        }

        public IActionResult AboutPopup()
        {
            return View();
        }
        public IActionResult ExperiencePopup()
        {
            return View();
        }
        public IActionResult EducationPopup()
        {
            return View();
        }
        public IActionResult SkillsPopup()
        {
            return View();
        }
        public IActionResult Preview()
        {
            List<UserDetails> userDetailsList = UserDetails.Select();
           // List<UserDetails> aboutList = UserDetails.SelectAbout();

            // Assuming you have only one About entry for simplicity
           // UserDetails aboutDetails = aboutList.Count > 0 ? aboutList[0] : new UserDetails();

       //     ViewData["About"] = aboutDetails.About;

            return View(userDetailsList);
        }
       
    }
}
