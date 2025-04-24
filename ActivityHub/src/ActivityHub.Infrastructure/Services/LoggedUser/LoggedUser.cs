using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Security.Tokens;
using ActivityHub.Domain.Services.LoggedUser;
using ActivityHub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ActivityHub.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly ActivityHubDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(ActivityHubDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task<User> Get()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext
            .Users
            .AsNoTracking()
            .FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
    }
}

