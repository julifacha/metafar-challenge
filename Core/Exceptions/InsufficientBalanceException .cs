namespace Core.Exceptions
{
    public sealed class InsufficientBalanceException : Exception
    {
        public const int ErrorCode = 100;
        public InsufficientBalanceException() 
            : base("Insuficient balance for the operation")
        {
        }
    }
}
