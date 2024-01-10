using Microsoft.AspNetCore.Mvc;
using MoviesManagement.Exceptions.Accounts;
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
            return View();
        }

        public void Create()
        {
            try
            {
                _accountService.SignUp(new Account()
                {
                    UserName = "admin",
                    Password = "admin123@"
                });
            }
            catch(AccountExistException ex) 
            {

            }
        }
    }
}
