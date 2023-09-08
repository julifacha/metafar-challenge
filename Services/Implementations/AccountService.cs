using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using Services.Dto;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Card> _cardRepository;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Operation> _operationsRepository;

        public AccountService(IRepository<Card> cardRepository, IRepository<Account> accountRepository, IRepository<Operation> operationsRepository)
        {
            _cardRepository = cardRepository;
            _accountRepository = accountRepository;
            _operationsRepository = operationsRepository;
        }
        public async Task<AccountBalanceDto> GetBalance(int cardNumber)
        {
            Account account = await GetAccountByCardNumber(cardNumber);
            return account.ToAccountBalanceDto();
        }

        public async Task<IEnumerable<OperationDto>> GetOperations(int cardNumber, int page, int pageSize)
        {
            Account account = await GetAccountByCardNumber(cardNumber);

            var operations = await _operationsRepository.Find(o => o.AccountId == account.Id)
                .OrderByDescending(o => o.Date)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return operations.Select(o => o.ToDto());
        }

        public async Task<OperationDto> Withdraw(int cardNumber, decimal amount)
        {
            Account account = await GetAccountByCardNumber(cardNumber);

            Operation withdrawalOperation = account.Withdraw(amount); 

            _accountRepository.Update(account);

            await _accountRepository.SaveChangesAsync();

            return withdrawalOperation.ToDto();
        }
        
        private async Task<Account> GetAccountByCardNumber(int cardNumber)
        {
            Card ? card = await _cardRepository.FindOneAsync(c => c.Number == cardNumber, 
                i => i.Include(c => c.Customer)
                     .Include(c => c.Account));

            if (card == null)
                throw new NotFoundException(nameof(Card));

            if (card.Account == null)
                throw new NotFoundException(nameof(Account));

            return card.Account;
        }
    }
}
