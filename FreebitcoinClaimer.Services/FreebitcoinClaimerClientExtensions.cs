using FreebitcoinClaimer.Services.Requests;
using FreebitcoinClaimer.Services.Types;

namespace FreebitcoinClaimer.Services
{
    public static partial class FreebitcoinClaimerClientExtensions
    {
        public static async Task<FreeRoll> FreeRollAsync(
            this IFreebitcoinClaimerClient claimerClient,
            string clientSeed,
            string csrfToken,
            string fingerprint,
            string fingerprint2,
            CancellationToken cancellationToken = default
        ) =>
            await claimerClient
                .MakeRequestAsync(
                    request: new FreeRollRequest(
                        clientSeed,
                        csrfToken,
                        fingerprint,
                        fingerprint2
                    ),
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);

        public static async Task<Login> LoginAsync(
            this IFreebitcoinClaimerClient claimerClient,
            string btcAddress,
            string password,
            string? tfaCode = default,
            CancellationToken cancellationToken = default
        ) => 
            await claimerClient
                .MakeRequestAsync(
                    request: new LoginRequest(
                        btcAddress,
                        password,
                        tfaCode
                    ),
                    cancellationToken: cancellationToken
                )
                .ConfigureAwait(false);
    }
}
