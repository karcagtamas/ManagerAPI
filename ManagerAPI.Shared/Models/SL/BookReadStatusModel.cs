using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// Book read status model
    /// </summary>
    public class BookReadStatusModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required] public int Id { get; set; }

        /// <summary>
        /// Read
        /// </summary>
        [Required] public bool Read { get; set; }
    }
}