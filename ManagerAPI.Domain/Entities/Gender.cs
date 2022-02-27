using KarcagS.Common.Tools.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// Gender
    /// </summary>
    public class Gender : IEntity<int>
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Connected users
        /// </summary>
        public virtual ICollection<User> Users { get; set; } = default!;
    }
}