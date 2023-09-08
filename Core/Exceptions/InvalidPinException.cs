namespace Core.Exceptions
{
    public sealed class InvalidPinException : Exception
    {
        public InvalidPinException()
            : base("The pin is invalid.")
        {
        }
    }
}
