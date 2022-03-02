using KarcagS.Shared.Attributes;
using ManagerAPI.Shared.DTOs;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Shared.Models;

/// <summary>
/// User Update DTO
/// Model for user Update
/// </summary>
public class UserModel
{
    /// <summary>
    /// Id
    /// </summary>
    [Required(ErrorMessage = "Id field is required")]
    public string Id { get; set; }

    /// <summary>
    /// Full Name
    /// </summary>
    [MaxLength(100, ErrorMessage = "Maximum length is 100")]
    public string? FullName { get; set; }

    /// <summary>
    /// E-mail Address
    /// </summary>

    [Required(ErrorMessage = "E-mail is required")]
    [EmailAddress(ErrorMessage = "Must be valid E-mail")]
    public string Email { get; set; }

    /// <summary>
    /// Secondary e-mail
    /// </summary>

    [NullableEmailAddress(ErrorMessage = "Must be valid E-mail")]
    public string? SecondaryEmail { get; set; }

    /// <summary>
    /// Phone Number
    /// </summary>

    [NullablePhone(ErrorMessage = "Must be valid Phone Number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// T-Shirt size
    /// </summary>

    [MaxLength(6, ErrorMessage = "Maximum length is 6")]
    public string? TShirtSize { get; set; }

    /// <summary>
    /// Allergy
    /// </summary>

    public string? Allergy { get; set; }

    /// <summary>
    /// Group
    /// </summary>

    [MaxLength(40, ErrorMessage = "Maximum length is 40")]
    public string? Group { get; set; }

    /// <summary>
    /// Birthy Day
    /// </summary>

    public DateTime? BirthDay { get; set; }

    /// <summary>
    /// Country
    /// </summary>

    [MaxLength(120, ErrorMessage = "Maximum length is 120")]
    public string? Country { get; set; }

    /// <summary>
    /// Gender
    /// </summary>

    public int? GenderId { get; set; }

    /// <summary>
    /// City
    /// </summary>

    [MaxLength(120, ErrorMessage = "Maximum length is 120")]
    public string? City { get; set; }

    /// <summary>
    /// Empty init
    /// </summary>
    public UserModel() : this(null)
    {
        Id = string.Empty;
        Email = string.Empty;
    }

    /// <summary>
    /// Model from user data object
    /// </summary>
    /// <param name="user">User</param>
    public UserModel(UserDto? user)
    {
        this.Id = user?.Id ?? string.Empty;
        this.FullName = user?.FullName;
        this.Email = user?.Email ?? string.Empty;
        this.SecondaryEmail = user?.SecondaryEmail;
        this.PhoneNumber = user?.PhoneNumber;
        this.TShirtSize = user?.TShirtSize;
        this.Allergy = user?.Allergy;
        this.Group = user?.Group;
        this.BirthDay = user?.BirthDay;
        this.Country = user?.Country;
        this.GenderId = user?.GenderId;
        this.City = user?.City;
    }
}
