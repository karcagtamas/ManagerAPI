namespace ManagerAPI.Shared.DTOs.EM
{
    /// <summary>
    /// Sport event DTO
    /// </summary>
    public class SportEventDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Injured
        /// </summary>
        public int? Injured { get; set; }

        /// <summary>
        /// Visitors
        /// </summary>
        public int? Visitors { get; set; }

        /// <summary>
        /// Visitor Limit
        /// </summary>
        public int? VisitorLimit { get; set; }

        /// <summary>
        /// Visitor Cost
        /// </summary>
        public decimal? VisitorCost { get; set; }

        /// <summary>
        /// Players
        /// </summary>
        public int? Players { get; set; }

        /// <summary>
        /// Player Limit
        /// </summary>
        public int? PlayerLimit { get; set; }

        /// <summary>
        /// Player Cost
        /// </summary>
        public decimal? PlayerCost { get; set; }

        /// <summary>
        /// Player Deposit
        /// </summary>
        public decimal? PlayerDeposit { get; set; }

        /// <summary>
        /// Helpers
        /// </summary>
        public int? Helpers { get; set; }

        /// <summary>
        /// Helper Limit
        /// </summary>
        public int? HelperLimit { get; set; }

        /// <summary>
        /// Fix Team Deposit
        /// </summary>
        public decimal? FixTeamDeposit { get; set; }

        /// <summary>
        /// Fix Team Cost
        /// </summary>
        public decimal? FixTeamCost { get; set; }

        /// <summary>
        /// Team Limit
        /// </summary>
        public int? TeamLimit { get; set; }

        /// <summary>
        /// Match Judges
        /// </summary>
        public string MatchJudges { get; set; }

        /// <summary>
        /// Doctors
        /// </summary>
        public string Doctors { get; set; }
    }
}