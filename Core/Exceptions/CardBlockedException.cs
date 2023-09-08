namespace Core.Exceptions
{
    public sealed class CardBlockedException : Exception
    {
        public CardBlockedException()
            : base("The card is blocked.")
        {
        }
    }
}
