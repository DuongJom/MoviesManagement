using Microsoft.AspNetCore.Mvc;
using MoviesManagement.Models;
using MoviesManagement.Services.Accounts;

namespace MoviesManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            var accounts = _accountService.GetAllAccounts();
            return View(accounts);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _accountService.SignUp(account);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _accountService.Login(account);
            if (!result)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
