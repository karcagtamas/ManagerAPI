using ManagerAPI.Shared.DTOs.EM;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.EM
{
    /// <summary>
    /// Gt event create or update model
    /// </summary>
    public class GtEventModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// T-shirt color
        /// </summary>
        public string TShirtColor { get; set; }

        /// <summary>
        /// Greeny number
        /// </summary>
        public int? Greeny { get; set; }

        /// <summary>
        /// Greeny cost
        /// </summary>
        public decimal? GreenyCost { get; set; }

        /// <summary>
        /// Empty init
        /// </summary>
        public GtEventModel()
        {
        }

        /// <summary>
        /// Model from event data object
        /// </summary>
        /// <param name="gtEvent">Gt event data object</param>
        public GtEventModel(GtEventDto gtEvent)
        {
            this.Id = gtEvent.Id;
            this.TShirtColor = gtEvent.TShirtColor;
            this.Greeny = gtEvent.Greeny;
            this.GreenyCost = gtEvent.GreenyCost;
        }
    }
}