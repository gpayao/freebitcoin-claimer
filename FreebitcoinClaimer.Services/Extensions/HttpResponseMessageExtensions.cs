using FreebitcoinClaimer.Services.Exceptions;

namespace FreebitcoinClaimer.Services.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        internal static async Task<T> DeserializeContentAsync<T>(
            this HttpResponseMessage httpResponse,
            Func<T, bool> guard)
        {
            Stream? contentStream = null;

            if (httpResponse.Content is null)
            {
                throw new RequestException(
                    message: "Response doesn't contain any content",
                    httpStatusCode: httpResponse.StatusCode
                );
            }

            try
            {
                T? deserializedObject;

                // Check content type
                var contentType = httpResponse.Content.Headers.ContentType?.MediaType;

                if (string.Equals(contentType, "application/json", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        // Deserialize JSON response
                        contentStream = await httpResponse.Content
                            .ReadAsStreamAsync()
                            .ConfigureAwait(continueOnCapturedContext: false);

                        deserializedObject = contentStream
                            .DeserializeJsonFromStream<T>();
                    }
                    catch (Exception exception)
                    {
                        throw CreateRequestException(
                            httpResponse: httpResponse,
                            message: "Required properties not found in response",
                            exception: exception
                        );
                    }
                }
                else
                {
                    try
                    {
                        // Handle other response format
                        contentStream = await httpResponse.Content
                            .ReadAsStreamAsync()
                            .ConfigureAwait(continueOnCapturedContext: false);

                        deserializedObject = contentStream
                            .DeserializeCustomFormatFromStream<T>();
                    }
                    catch (Exception exception)
                    {
                        throw CreateRequestException(
                            httpResponse: httpResponse,
                            message: exception.Message,
                            exception: exception
                        );
                    }

                }

                if (deserializedObject is null)
                {
                    throw CreateRequestException(
                        httpResponse: httpResponse,
                        message: "Required properties not found in response"
                    );
                }

                if (guard(deserializedObject))
                {
                    throw CreateRequestException(
                        httpResponse: httpResponse,
                        message: "Required properties not found in response"
                    );
                }

                return deserializedObject;
            }
            finally
            {
#if NET6_0_OR_GREATER
                if (contentStream is not null)
                {
                    await contentStream.DisposeAsync().ConfigureAwait(false);
                }
#else
                contentStream?.Dispose();
#endif
            }
        }

        static RequestException CreateRequestException(
            HttpResponseMessage httpResponse,
            string message,
            Exception? exception = default
        ) =>
            exception is null
        ? new(
            message: message,
            httpStatusCode: httpResponse.StatusCode
        )
        : new(
            message: message,
            httpStatusCode: httpResponse.StatusCode,
            innerException: exception
        );
    }
}