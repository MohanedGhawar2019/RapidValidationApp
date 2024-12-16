using Microsoft.AspNetCore.Mvc;
using Rapid.Validation;
using Rapid.Validation.Validators;

namespace RapidValidationApp.Controllers
{
    public class CreditCardValidatorController : Controller
    {
        private readonly CreditCardValidator _creditCardValidator;

        public CreditCardValidatorController(CreditCardValidator creditCardValidator)
        {
            _creditCardValidator = creditCardValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateCreditCard(string creditCard)
        {
            var validationResult = _creditCardValidator.Validate(creditCard);
            ViewBag.Result = validationResult.IsValid ? "Valid credit card" : validationResult.ErrorMessage;
            return View("Index");
        }
    }
}