namespace ManagerAPI.Shared.DTOs.EM
{
    /// <summary>
    /// Gt event DTO
    /// </summary>
    public class GtEventDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TShirt Color
        /// </summary>
        public string TShirtColor { get; set; }

        /// <summary>
        /// Greeny
        /// </summary>
        public int? Greeny { get; set; }

        /// <summary>
        /// Greeny Cost
        /// </summary>
        public decimal? GreenyCost { get; set; }
    }
}