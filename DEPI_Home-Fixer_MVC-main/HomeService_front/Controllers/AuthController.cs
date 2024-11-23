using ApiServiceLayer.Services.APIServices;
using HomeService_front.Models.Auth;
using HomeService_front.Models.Person;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HomeService_front.Models.Specialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeService_front.Controllers
{
    public class AuthController : BaseController
    {
        public AuthController(IAPIService apiService, IConfiguration configuration) : base(apiService, configuration)
        {
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVm model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var person = await _apiService.PostAsync<PersonVM>("Auth/LogIn", model);

                    if (person != null)
                    {
                        // Create claims
                        var claims = new List<Claim>
                 {
                    new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()), 
                       new Claim(ClaimTypes.Email, person.Email),
                  };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        // Sign in the user
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                        if (person.Role == "Technician")
                            return RedirectToAction("Index", "Request");
                        else if (person.Role == "User")
                            return RedirectToAction("Index", "Client");
                        else
                            return RedirectToAction("Index", "Admin");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = "The password or email are incorrect";
                return View(model);
            }
            return View(model);


        }


        public IActionResult RegisterUser()
        {

            return View(new RegisterUserVM());
        }
        [HttpPost]

        public async Task<IActionResult> RegisterUser(RegisterUserVM registerUserVM)
        {
            if (ModelState.IsValid)
            {
                var errors = new List<string>();

                errors = await _apiService.PostAsync<List<string>>("Auth/RegisterUser", registerUserVM);

                if (errors == null || errors.Count == 0)
                    return RedirectToAction("LogIn");
                else
                    ViewBag.Errors = errors;

            }

            return View(registerUserVM);
        }

        public async Task<IActionResult> RegisterTechnician()
        {
            var Specializations = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");

            ViewBag.Specializations = new SelectList(Specializations, "SpecializationID", "SpecializationName");

            return View(new RegisterTechnicianVM());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTechnician(RegisterTechnicianVM registerTechnicianVM)
        {
            if (ModelState.IsValid)
            {
                var errors = new List<string>();

                errors = await _apiService.PostAsync<List<string>>("Auth/RegisterTechnician", registerTechnicianVM);

                if (errors == null || errors.Count == 0)
                    return RedirectToAction("LogIn");
                else
                    ViewBag.Errors = errors;
            }

            var Specializations = await _apiService.GetAsync<List<SpecializationVM>>("Specialization");

            ViewBag.Specializations = new SelectList(Specializations, "SpecializationID", "SpecializationName");

            return View(registerTechnicianVM);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("LogIn", "Auth");
        }

    }
}
