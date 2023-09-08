namespace Core.Exceptions
{
    public sealed class InvalidAmountException : Exception
    {
        public InvalidAmountException() 
            : base("Input amount is invalid.") 
        { }
    }
}
