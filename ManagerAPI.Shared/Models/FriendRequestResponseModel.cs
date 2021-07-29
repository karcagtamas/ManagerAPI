using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models
{
    /// <summary>
    /// Friend request response model
    /// </summary>
    public class FriendRequestResponseModel
    {
        /// <summary>
        /// Request
        /// </summary>
        [Required] public int RequestId { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        [Required] public bool Response { get; set; }
    }
}