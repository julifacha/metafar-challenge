using Services.Dto;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountBalanceDto> GetBalance(int cardNumber);
        Task<OperationDto> Withdraw(int cardNumber, decimal amount);
        Task<IEnumerable<OperationDto>> GetOperations(int cardNumber, int page, int pageSize);
    }
}
