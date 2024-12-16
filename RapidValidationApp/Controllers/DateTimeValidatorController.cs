using Microsoft.AspNetCore.Mvc;
using Rapid.Validation;
using Rapid.Validation.Validators;

namespace RapidValidationApp.Controllers
{
    public class DateTimeValidatorController : Controller
    {
        private readonly DateTimeValidator _dateTimeValidator;

        public DateTimeValidatorController(DateTimeValidator dateTimeValidator)
        {
            _dateTimeValidator = dateTimeValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateDateTime(DateTime dateTime)
        {
            var validationResult = _dateTimeValidator.Validate(dateTime);
            ViewBag.Result = validationResult.IsValid ? "Valid date/time" : validationResult.ErrorMessage;
            return View("Index");
        }
    }
}