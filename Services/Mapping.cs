using Models;
using Services.Dto;

namespace Services
{
    public static class Mapping
    {
        public static OperationDto ToDto(this Operation operation)
        {
            return new OperationDto(operation.Id, operation.AccountId, operation.Amount, operation.Date, operation.OperationType, operation.Balance);
        }
        public static AccountBalanceDto ToAccountBalanceDto(this Account account)
        {
            return new AccountBalanceDto(account.Card.Customer.Name, account.Number, account.Balance, account.LastWithdrawalDate);
        }
    }
}
