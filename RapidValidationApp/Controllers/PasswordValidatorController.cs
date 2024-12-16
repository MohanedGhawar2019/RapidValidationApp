using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rapid.Validation;
using Rapid.Validation.Validators;

namespace RapidValidationApp.Controllers
{
    public class PasswordValidatorController : Controller
    {
        private readonly PasswordValidator _passwordValidator;

        public PasswordValidatorController(PasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidatePassword(string password)
        {
            var validationResult = _passwordValidator.Validate(password);
            ViewBag.Result = validationResult.IsValid ? "Valid password" : validationResult.ErrorMessage;
            return View("Index");
        }
    }
}