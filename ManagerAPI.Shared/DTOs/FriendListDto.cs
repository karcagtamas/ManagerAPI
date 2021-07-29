using System;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// Friend list DTO
    /// </summary>
    public class FriendListDto
    {
        /// <summary>
        /// Friend Id
        /// </summary>
        public string FriendId { get; set; }

        /// <summary>
        /// Friend's name
        /// </summary>
        public string Friend { get; set; }

        /// <summary>
        /// Friend's Full Name
        /// </summary>
        public string FriendFullName { get; set; }

        /// <summary>
        /// Friend Image title
        /// </summary>
        public string FriendImageTitle { get; set; }

        /// <summary>
        /// Friend Image
        /// </summary>
        public byte[] FriendImageData { get; set; }

        /// <summary>
        /// Connection date
        /// </summary>
        public DateTime ConnectionDate { get; set; }

        /// <summary>
        /// Generate image url
        /// </summary>
        /// <param name="defaultImage">Default image path</param>
        /// <returns>Generated image path</returns>
        public string ImageUrl(string defaultImage)
        {
            if (this.FriendImageData.Length == 0)
            {
                return defaultImage;
            }

            string base64 = Convert.ToBase64String(this.FriendImageData);
            return $"data:image/gif;base64,{base64}";

        }
    }
}