namespace Services.Dto
{
    public record AccountBalanceDto(
        string CustomerName, 
        int AccountNumber, 
        decimal CurrentBalance, 
        DateTime LastWithdrawalDate
    );
}
