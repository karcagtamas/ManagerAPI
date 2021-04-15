using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// My movie update model
    /// </summary>
    public class MyMovieModel
    {
        /// <summary>
        /// Id List
        /// </summary>
        [Required] public List<int> Ids { get; set; }
    }
}