namespace Core.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(string customerName, int customerId, int cardNumber);
    }
}
