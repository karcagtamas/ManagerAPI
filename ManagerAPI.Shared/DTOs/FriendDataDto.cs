using System;
using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// Friend data DTO
    /// </summary>
    public class FriendDataDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Full Name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Registraton date
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// T-shirt size
        /// </summary>
        public string TShirtSize { get; set; }

        /// <summary>
        /// Allergy
        /// </summary>
        public string Allergy { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        public List<string> Roles { get; set; }
    }
}