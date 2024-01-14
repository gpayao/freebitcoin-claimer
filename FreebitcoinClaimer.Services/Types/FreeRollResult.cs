namespace FreebitcoinClaimer.Services.Types
{
    public class FreeRoll
    { 
        public FreeRoll()
        { }

        public FreeRoll(
            int rollNumber,
            double balance,
            double winnings,
            long lastPlay,
            double balanceUSD,
            string? nextServerHash,
            long nextNonce,
            string? previousServerSeed,
            string? previousServerSeedHash,
            string? previousClientSeed,
            long previousNonce,
            int rewardPoints,
            int lottertTicketsWon,
            int rewardPointsWon)
        {
            RollNumber = rollNumber;
            Balance = balance;
            Winnings = winnings;
            LastPlay = lastPlay;
            BalanceUSD = balanceUSD;
            NextServerHash = nextServerHash;
            NextNonce = nextNonce;
            PreviousServerSeed = previousServerSeed;
            PreviousServerSeedHash = previousServerSeedHash;
            PreviousClientSeed = previousClientSeed;
            PreviousNonce = previousNonce;
            RewardPoints = rewardPoints;
            LottertTicketsWon = lottertTicketsWon;
            RewardPointsWon = rewardPointsWon;
        }

        public int RollNumber { get; set; }

        public double Balance { get; set; }

        public double Winnings { get; set; }

        public long LastPlay { get; set; }

        public double BalanceUSD { get; set; }

        public string? NextServerHash { get; set; }

        public long NextNonce { get; set; }

        public string? PreviousServerSeed { get; set; }

        public string? PreviousServerSeedHash { get; set; }

        public string? PreviousClientSeed { get; set; }

        public long PreviousNonce { get; set; }

        public int RewardPoints { get; set; }

        public int LottertTicketsWon { get; set; }

        public int RewardPointsWon { get; set; }

        public string? VerificationLink
        {
            get
            {
                return $"https://s3.amazonaws.com/roll-verifier/verify.html?server_seed={PreviousServerSeed}&client_seed={PreviousClientSeed}&server_seed_hash={PreviousServerSeedHash}&nonce={PreviousNonce}";
            }
        }
    }
}
