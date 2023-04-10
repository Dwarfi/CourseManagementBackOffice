﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace CourseManagementApi.Services;

public class AuthService : IAuthService
{
    private readonly CourseMgmtContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _context = new CourseMgmtContext();
        _configuration = configuration;
    }

    public RegistrationStatus Register(UserDto request)
    {
        if (_context.AppUsers.Any(s => s.Email == request.Email)) return RegistrationStatus.Exists;

        _context.AppUsers.Add(new User
        {
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = HashPassword(request.Password),
            Role = (int)request.Role
        });
        _context.SaveChanges();

        return RegistrationStatus.Success;
    }

    public string Login(UserDto request)
    {
        var authStatus = Authorize(request);

        switch (authStatus)
        {
            case LoginStatus.Success:
            {
                var user = _context.AppUsers.SingleOrDefault(s => s.Email.Equals(request.Email));
                return CreateJwtToken(user!);
            }
            default:
                return string.Empty;
        }
    }

    private LoginStatus Authorize(UserDto request)
    {
        var user = _context.AppUsers.SingleOrDefault(s => s.Email.Equals(request.Email));

        if (user is null) return LoginStatus.InvalidUsername;

        return ValidatePassword(request.Password, user.PasswordHash)
            ? LoginStatus.Success
            : LoginStatus.InvalidPassword;
    }

    private static string GetRandomSalt() => BCrypt.Net.BCrypt.GenerateSalt(13);

    private static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());

    private static bool ValidatePassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);

    private string CreateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, ((UserRole)user.Role).DisplayName()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:TokenKey").Value!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}