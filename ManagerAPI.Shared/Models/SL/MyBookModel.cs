using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models.SL
{
    /// <summary>
    /// My book update model
    /// </summary>
    public class MyBookModel
    {
        /// <summary>
        /// Id List
        /// </summary>
        [Required] public List<int> Ids { get; set; }
    }
}