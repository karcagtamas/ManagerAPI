﻿using KarcagS.Common.Tools.HttpInterceptor;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Configurations;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ManagerAPI.Services.Services;

/// <inheritdoc />
public class TokenService : ITokenService
{
    private readonly JWTConfiguration jwtConfigurations;
    private readonly IUserService userService;
    private readonly UserManager<User> userManager;

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="jwtOptions">JWT options</param>
    /// <param name="userService">User Service</param>
    /// <param name="userManager">User Manager</param>
    public TokenService(IOptions<JWTConfiguration> jwtOptions, IUserService userService,
        UserManager<User> userManager)
    {
        jwtConfigurations = jwtOptions.Value;
        this.userService = userService;
        this.userManager = userManager;
    }

    /// <inheritdoc />
    public string BuildAccessToken(UserTokenDTO user, IList<string> roles)
    {
        var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id)
            };

        var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
        claims.AddRange(roleClaims);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfigurations.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new JwtSecurityToken(jwtConfigurations.Issuer, jwtConfigurations.Issuer, claims,
            expires: DateTime.Now.AddMinutes(jwtConfigurations.ExpirationInMinutes),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    /// <inheritdoc />
    public RefreshToken BuildRefreshToken(string clientId)
    {
        var randomNumber = new byte[32];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(randomNumber);
        return new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            Expires = DateTime.Now.AddDays(3),
            Created = DateTime.Now,
            ClientId = clientId
        };
    }

    /// <inheritdoc />
    public async Task<TokenDTO> Refresh(string refreshToken, string clientId)
    {
        if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(refreshToken))
        {
            throw new ServerException("Input model is invalid");
        }

        var user = userService.GetByRefreshToken(refreshToken, clientId);

        if (user is null)
        {
            throw new ServerException("The refresh token is invalid");
        }

        if (!user.IsActive)
        {
            throw new ServerException("User is disabled");
        }

        var oldRefreshToken = user.RefreshTokens.Single(t => t.Token == refreshToken && t.ClientId == clientId);

        if (!oldRefreshToken.IsActive)
        {
            throw new ServerException("The refresh token is expired");
        }

        oldRefreshToken.Revoked = DateTime.Now;

        var newRefreshToken = BuildRefreshToken(clientId);
        user.RefreshTokens.Add(newRefreshToken);
        userService.Update(user);
        userService.Persist();

        var accessToken = BuildAccessToken(userService.GetMapped<UserTokenDTO>(user.Id),
            await userManager.GetRolesAsync(userManager.Users.First(u => u.Id == user.Id)));

        return new TokenDTO
        { AccessToken = accessToken, RefreshToken = newRefreshToken.Token, ClientId = clientId };
    }
}
