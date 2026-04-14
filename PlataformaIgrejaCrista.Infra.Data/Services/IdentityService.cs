using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlataformaIgrejaCrista.Application.DTOs;
using PlataformaIgrejaCrista.Application.Interfaces;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Domain.Exceptions;
using PlataformaIgrejaCrista.Domain.Interfaces;
using System.Security.Cryptography;


namespace PlataformaIgrejaCrista.Infra.Data.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IHashingService _hashingService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepository,
        IHashingService hashingService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _refreshTokenRepository = refreshTokenRepository;
        _hashingService = hashingService;
    }

    public async Task<IReadOnlyCollection<UserDTO>> GetAllUserAsync()
    {
        return await _userManager.Users
         .Select(u => new UserDTO(
             u.Id,
             u.UserName!,
             u.Email!
         ))
         .ToListAsync();
    }

    public async Task<(string accessToken, string refreshToken)> RegisterAsync(string username, string password, string email)
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new IdentityOperationException(
                string.Join("; ", result.Errors.Select(e => e.Description)));

        return await GenerateTokensAsync(user);
    }

    public async Task<(string accessToken, string refreshToken)> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new UserNotFoundException();

        var result = await _signInManager
            .CheckPasswordSignInAsync(user, password, false);

        if (!result.Succeeded)
            throw new UserNotFoundException();

        return await GenerateTokensAsync(user);
    }

    private async Task<(string accessToken, string refreshToken)> GenerateTokensAsync(ApplicationUser user)
    {
        var accessToken = _tokenService.GenerateToken(user);

        var rawRefreshToken = Convert.ToBase64String(
            RandomNumberGenerator.GetBytes(64));

        var refreshTokenEntity = RefreshToken.Create(
            user.Id,
            rawRefreshToken,
            _hashingService,
            DateTime.Now.AddDays(7));

        await _refreshTokenRepository.AddAsync(refreshTokenEntity);
        await _refreshTokenRepository.SaveChangesAsync();

        return (accessToken, rawRefreshToken);
    }
}
