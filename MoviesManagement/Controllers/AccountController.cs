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

        public IActionResult ChangePassword(long? id, string? email = null)
        {
            Account? account;
            if(email == null)
            {
                account = _accountService.GetAccountById(id);
            }
            else
            {
                account = _accountService.GetAccountByEmail(email);
            }
            
            return View(account);
        }

        [HttpPut]
        public IActionResult ChangePassword(long? id, Account account)
        {
            if (id != account.Id || !account.Password.Equals(account.ConfirmPassword))
            {
                return View();
            }

            _accountService.ResetPassword(id, account.NewPassword);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult DeleteAccount(long? id)
        {
            if (id == null)
            {
                return View();
            }

            _accountService.DeleteAccount(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string? email)
        {
            var acc = _accountService.GetAccountByEmail(email);
            if(acc == null)
            {
                ModelState.AddModelError("Email", "Email doesn't exist.");
                return View();
            }

            return View(nameof(ChangePassword));
        }
    }
}
