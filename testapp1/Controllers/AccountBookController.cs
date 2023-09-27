using Microsoft.AspNetCore.Mvc;
using testapp1.ExceptionHandler;
using testapp1.Models;
using testapp1.Services;

namespace testapp1.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountBookController:ControllerBase
    {
        private readonly AccountBookService _accountBookService;

        public AccountBookController(AccountBookService accountBookService)
        {
            _accountBookService= accountBookService;
        }

        [HttpPost("account")]
        public IActionResult CreateAccount(string name, AccountType accountType)
        {
            try
            {
                _accountBookService.CreateAccount(name, accountType);
                return StatusCode(201);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allAccounts = _accountBookService.GetAccounts();
                return Ok(allAccounts);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost("transaction")]
        public IActionResult CreateTransaction([FromBody] TransactionData transactionData) 
        {
            try
            {
                _accountBookService.CreateTransaction(transactionData);
                return StatusCode(201);
            }
            catch (CustomException ex)
            {
              return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
    
        }

    }
}
