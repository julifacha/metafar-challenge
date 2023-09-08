namespace Core.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string name)
            : base($"Entity \"{name}\".")
        {
        }
    }
}
