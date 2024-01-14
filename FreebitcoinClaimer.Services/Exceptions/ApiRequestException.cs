namespace FreebitcoinClaimer.Services.Exceptions
{
    public class ApiRequestException : RequestException
    {
        /// <summary>
        /// Gets the time remaining for the next free roll.
        /// </summary>
        public virtual int TimeRemaining { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApiRequestException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="timeRemaining">The time remaining for the next free roll.</param>
        public ApiRequestException(string message, int timeRemaining)
            : base(message) =>
            TimeRemaining = timeRemaining;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic)
        /// if no inner exception is specified.
        /// </param>
        public ApiRequestException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequestException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="timeRemaining">The time remaining for the next free roll.</param>
        /// <param name="innerException">The inner exception.</param>
        public ApiRequestException(string message, int timeRemaining, Exception innerException)
            : base(message, innerException) =>
            TimeRemaining = timeRemaining;
    }
}
