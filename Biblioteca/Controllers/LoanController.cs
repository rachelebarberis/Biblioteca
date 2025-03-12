using Biblioteca.Services;
using Biblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanServices _loanServices;

        public LoanController(LoanServices loanServices)
        {
            _loanServices = loanServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id:guid}")]
        public IActionResult Add(Guid id)
        {
            var add = new AddLoanViewModel() {BookId=id};
            
            return View(add);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLoanViewModel addLoanViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error while saving entity to database";
                return RedirectToAction("Index");
            }
            var result = await _loanServices.AddLoanAsync(addLoanViewModel);
            if (!result)
            {
                TempData["Error"] = "Error while saving entity to database";
            }
            return RedirectToAction("Index");
        }

    }
}



