using Microsoft.AspNetCore.Mvc;
using Rapid.Validation.Validators;

namespace RapidValidationApp.Controllers
{
    public class EmailValidatorController : Controller
    {
        private readonly EmailValidator _emailValidator;

        public EmailValidatorController(EmailValidator emailValidator)
        {
            _emailValidator = emailValidator;
        }   

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateEmail(string email)
        {
            var validationResult = _emailValidator.Validate(email);
            ViewBag.Result = validationResult.IsValid ? "Valid email" : validationResult.ErrorMessage;
            return View("Index");
        }
    }
}