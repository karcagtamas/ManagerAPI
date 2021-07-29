using ManagerAPI.Shared.DTOs.EM;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.EM
{
    /// <summary>
    /// Sport event create or update model
    /// </summary>
    public class SportEventModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Injured player number
        /// </summary>
        public int? Injured { get; set; }

        /// <summary>
        /// Visitor number
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
        /// Player number
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
        /// Helper
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
        /// Judges
        /// </summary>
        public string MatchJudges { get; set; }

        /// <summary>
        /// Doctors
        /// </summary>
        public string Doctors { get; set; }

        /// <summary>
        /// Empty init
        /// </summary>
        public SportEventModel()
        {
        }

        /// <summary>
        /// Model from sport event data object
        /// </summary>
        /// <param name="sportEvent">Sport event data object</param>
        public SportEventModel(SportEventDto sportEvent)
        {
            this.Id = sportEvent.Id;
            this.Injured = sportEvent.Injured;
            this.Visitors = sportEvent.Visitors;
            this.VisitorLimit = sportEvent.VisitorLimit;
            this.VisitorCost = sportEvent.VisitorCost;
            this.Players = sportEvent.Players;
            this.PlayerLimit = sportEvent.PlayerLimit;
            this.PlayerCost = sportEvent.PlayerCost;
            this.PlayerDeposit = sportEvent.PlayerDeposit;
            this.Helpers = sportEvent.Helpers;
            this.HelperLimit = sportEvent.HelperLimit;
            this.FixTeamDeposit = sportEvent.FixTeamDeposit;
            this.FixTeamCost = sportEvent.FixTeamCost;
            this.TeamLimit = sportEvent.TeamLimit;
            this.MatchJudges = sportEvent.MatchJudges;
            this.Doctors = sportEvent.Doctors;
        }
    }
}