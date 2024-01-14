namespace FreebitcoinClaimer.Services.Exceptions
{
    public class ApiResponse
    {
        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the time remaining for the next free roll.
        /// </summary>
        public int TimeRemaining { get; private set; }

        /// <summary>
        /// Initializes an instance of <see cref="ApiResponse"/>
        /// </summary>
        /// <param name="description">Error message</param>
        public ApiResponse(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Initializes an instance of <see cref="ApiResponse"/>
        /// </summary>
        /// <param name="description">Error message</param>
        /// <param name="timeRemaining">Time remaining for the next free roll</param>
        public ApiResponse(
            string description, 
            int timeRemaining)
        {
            Description = description;
            TimeRemaining = timeRemaining;
        }
    }
}
