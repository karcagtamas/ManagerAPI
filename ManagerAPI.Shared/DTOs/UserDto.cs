using System;
using System.Collections.Generic;

namespace ManagerAPI.Shared.DTOs
{
    /// <summary>
    /// User DTO
    /// </summary>
    public class UserDto
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
        /// Registration Date
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// Last Login
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Secondary E-mail
        /// </summary>
        public string SecondaryEmail { get; set; }

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
        /// Profile Image Name
        /// </summary>
        public string ProfileImageTitle { get; set; }

        /// <summary>
        /// Profile Image
        /// </summary>
        public byte[] ProfileImageData { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public int? GenderId { get; set; }

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