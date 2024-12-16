using Microsoft.AspNetCore.Mvc;
using Rapid.Validation;
using Rapid.Validation.Validators;

namespace RapidValidationApp.Controllers
{
    public class PhoneNumberValidatorController : Controller
    {
        private readonly PhoneNumberValidator _phoneNumberValidator;

        public PhoneNumberValidatorController(PhoneNumberValidator phoneNumberValidator)
        {
            _phoneNumberValidator = phoneNumberValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidatePhoneNumber(string phoneNumber)
        {
            var validationResult = _phoneNumberValidator.Validate(phoneNumber);
            ViewBag.Result = validationResult.IsValid ? "Valid phone number" : validationResult.ErrorMessage;
            return View("Index");
        }
    }
}