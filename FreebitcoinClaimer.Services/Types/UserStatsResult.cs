using Newtonsoft.Json;

namespace FreebitcoinClaimer.Services.Types
{
    public class UserStatsResult
    {
        [JsonProperty("ftd_bonus_end")]
        public int FtdBonusEnd { get; set; }

        [JsonProperty("lottery_tickets")]
        public string? LotteryTickets { get; set; }

        [JsonProperty("user_extras")]
        public UserExtras? UserExtras { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("total_lambo_lottery_tickets")]
        public int TotalLamboLotteryTickets { get; set; }

        [JsonProperty("user")]
        public User? User { get; set; }

        [JsonProperty("bonus_mult")]
        public int BonusMult { get; set; }

        [JsonProperty("ftd_bonus_waiting_end")]
        public int FtdBonusWaitingEnd { get; set; }

        [JsonProperty("ftd_bonus_waiting")]
        public int FtdBonusWaiting { get; set; }

        [JsonProperty("lambo_contest_round")]
        public int LamboContestRound { get; set; }

        [JsonProperty("lambo_lottery_tickets")]
        public string? LamboLotteryTickets { get; set; }

        [JsonProperty("rp_wof_mx_tix")]
        public int RpWofMxTix { get; set; }

        [JsonProperty("flash_offer_volume")]
        public int FlashOfferVolume { get; set; }

        [JsonProperty("lottery_round")]
        public string? LotteryRound { get; set; }

        [JsonProperty("lottery_ticket_price")]
        public int LotteryTicketPrice { get; set; }

        [JsonProperty("flash_offer_end")]
        public int FlashOfferEnd { get; set; }
    }

    public class User
    {
        [JsonProperty("paid_winnings")]
        public string? PaidWinnings { get; set; }

        [JsonProperty("free_winnings")]
        public int FreeWinnings { get; set; }

        [JsonProperty("balance")]
        public string? Balance { get; set; }
    }

    public class UserExtras
    {
        [JsonProperty("reward_points")]
        public string? RewardPoints { get; set; }

        [JsonProperty("lottery_spent")]
        public string? LotterySpent { get; set; }

        [JsonProperty("multiply_commissions_earned")]
        public string? MultiplyCommissionsEarned { get; set; }

        [JsonProperty("jackpot_spent")]
        public string? JackpotSpent { get; set; }
    }
}
