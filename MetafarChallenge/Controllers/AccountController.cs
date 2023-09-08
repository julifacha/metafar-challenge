using MetafarChallenge.Filters;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace MetafarChallenge.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Retrieves balance for a given account by Card Number
        /// </summary>
        /// <param name="cardNumber">The Card Number.</param>
        /// <returns>
        /// 200 (OK) if found
        /// 401 (Unauthorized) if cardNumber does not match the Bearer token's cardNumber claim
        /// 404 (Not Found) if card or account not found
        /// </returns>
        [AuthorizeCard]
        [HttpGet("{cardNumber}/balance")]
        public async Task<IActionResult> GetBalance([FromRoute] int cardNumber)
        {
            return Ok(await _accountService.GetBalance(cardNumber));
        }

        /// <summary>
        /// Retrieves operations for a given account by Card Number
        /// </summary>
        /// <param name="cardNumber">The Card Number.</param>
        /// <param name="page">The 0 based page number for pagination.</param>
        /// <param name="pageSize">The page size for pagination.</param>
        /// <returns>
        /// 200 (OK) if found
        /// 401 (Unauthorized) if cardNumber does not match the Bearer token's cardNumber claim
        /// 404 (Not Found) if card or account not found
        /// </returns>
        [AuthorizeCard]
        [HttpGet("{cardNumber}/operations")]
        public async Task<IActionResult> GetOperations([FromRoute] int cardNumber, [FromQuery] int page = 0, [FromQuery] int pageSize = 10)
        {
            return Ok(await _accountService.GetOperations(cardNumber, page, pageSize));
        }

        /// <summary>
        /// Retrieves operations for a given account by Card Number
        /// </summary>
        /// <param name="cardNumber">The Card Number.</param>
        /// <param name="command">Command including CardNumber and Amount.</param>
        /// <returns>
        /// 200 (OK) if found
        /// 400 (BadRequest) if insuficient balance
        /// 401 (Unauthorized) if cardNumber does not match the Bearer token's cardNumber claim
        /// 404 (Not Found) if card or account not found
        /// </returns>
        [AuthorizeCard]
        [HttpPost("{cardNumber}/withdraw/{amount}")]
        public async Task<IActionResult> WithdrawFromAccount([FromRoute] int cardNumber, [FromRoute] decimal amount)
        {
            return Ok(await _accountService.Withdraw(cardNumber, amount));
        }
    }
}
