namespace FreebitcoinClaimer.Services.Types
{
    public class TooManyAttemptsException : Exception
    {
        public TooManyAttemptsException(string? message) : base(message)
        {
        }
    }
}
