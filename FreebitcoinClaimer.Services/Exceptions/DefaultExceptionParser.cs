namespace FreebitcoinClaimer.Services.Exceptions
{
    public class DefaultExceptionParser : IExceptionParser
    {
        public ApiRequestException Parse(ApiResponse apiResponse)
        {
            if (apiResponse is null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return new(
                message: apiResponse.Description,
                timeRemaining: apiResponse.TimeRemaining
            );
        }
    }
}
