using Microsoft.AspNetCore.Mvc;
using Rapid.Validation;
using Rapid.Validation.Validators;

namespace RapidValidationApp.Controllers
{
    public class UrlValidatorController : Controller
    {
        private readonly UrlValidator _urlValidator;

        public UrlValidatorController(UrlValidator urlValidator)
        {
            _urlValidator = urlValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateUrl(string url)
        {
            var validationResult = _urlValidator.Validate(url);
            ViewBag.Result = validationResult.IsValid ? "Valid URL" : validationResult.ErrorMessage;
            return View("Index");
        }
    }
}