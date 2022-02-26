namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Entity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        bool Equals(object? obj);

        /// <summary>
        /// To string
        /// </summary>
        string? ToString();
    }
}
