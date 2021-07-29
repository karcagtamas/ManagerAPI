namespace ManagerAPI.Shared.DTOs.EM
{
    /// <summary>
    /// Event DTO
    /// </summary>
    public class EventDto
    {
        /// <summary>
        /// Master
        /// </summary>
        public MasterEventDto MasterEvent { get; set; }

        /// <summary>
        /// Sport
        /// </summary>
        public SportEventDto SportEvent { get; set; }

        /// <summary>
        /// GT
        /// </summary>
        public GtEventDto GtEvent { get; set; }
    }
}