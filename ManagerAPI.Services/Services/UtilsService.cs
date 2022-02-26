using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ManagerAPI.Services.Services;

/// <inheritdoc />
public class UtilsService : IUtilsService
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly DatabaseContext _context;

    /// <summary>
    /// Utils Service constructor
    /// </summary>
    /// <param name="contextAccessor">Context Accessor</param>
    /// <param name="context">Context</param>
    public UtilsService(IHttpContextAccessor contextAccessor, DatabaseContext context)
    {
        this._contextAccessor = contextAccessor;
        this._context = context;
    }

    /// <inheritdoc />
    public User GetCurrentUser()
    {
        string userId = this.GetCurrentUserId();
        var user = this._context.AppUsers.Find(userId);
        if (user == null)
        {
            throw new Exception("Invalid user Id");
        }

        return user;
    }

    /// <inheritdoc />
    public string GetCurrentUserId()
    {
        string userId = this._contextAccessor.HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
        return userId;
    }

    /// <inheritdoc />
    public string InjectString(string baseText, params string[] args)
    {
        string res = baseText;

        for (int i = 0; i < args.Length; i++)
        {
            // Get placeholder from the current interaction
            string placeholder = "{i}".Replace('i', i.ToString()[0]);

            // Placeholder does not exist in the base text
            if (!res.Contains(placeholder))
            {
                throw new ArgumentException($"Placer holder is missing with number: {i}");
            }

            // Inject params instead of placeholder
            res = res.Replace(placeholder, $"{args[i]}");
        }

        return res;
    }

    /// <inheritdoc />
    public string UserDisplay(User user)
    {
        return $"{user.UserName} ({user.Id})";
    }

    /// <inheritdoc />
    public string ErrorsToString(IEnumerable<IdentityError> errors)
    {
        var list = errors.ToList();
        return list.FirstOrDefault()?.Description;
    }
}
