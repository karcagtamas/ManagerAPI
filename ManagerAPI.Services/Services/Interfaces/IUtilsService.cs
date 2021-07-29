using ManagerAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// Utils Service
    /// </summary>
    public interface IUtilsService
    {
        /// <summary>
        /// Get current user from the HTTP Context
        /// </summary>
        /// <returns>Current user</returns>
        User GetCurrentUser();

        /// <summary>
        /// Get current user's Id from the HTTP Context
        /// </summary>
        /// <returns>Current user's Id</returns>
        string GetCurrentUserId();

        /// <summary>
        /// User display text.
        /// Format: [User Name] ([User Id])
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Display text</returns>
        string UserDisplay(User user);

        /// <summary>
        /// Inject params into string.
        /// </summary>
        /// <param name="baseText">Base text with number placeholders.</param>
        /// <param name="args">Injectable params.</param>
        /// <returns>Base text with injected params.</returns>
        string InjectString(string baseText, params string[] args);

        /// <summary>
        /// Identity errors to string.
        /// </summary>
        /// <param name="errors">Error list</param>
        /// <returns>First error's description</returns>
        string ErrorsToString(IEnumerable<IdentityError> errors);
    }
}