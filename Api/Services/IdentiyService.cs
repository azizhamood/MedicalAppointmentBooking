
using Api.Model;
using Application.DTO;
using Core.Model;
using Core.Exceptions;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

using Api.Healpers;
using Share.DTO;
using Share.Model;

//using static Google.Protobuf.Collections.MapField<TKey, TValue>;

namespace Api.Services
{
    public class IdentiyService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlDbContex _mySqlDbContex;
        public IdentiyService(IConfiguration configuration, MySqlDbContex mySqlDbContex)
        {
            _configuration = configuration;
            _mySqlDbContex = mySqlDbContex;
          
        }

        public async Task<UserDto> RegisterAsync(UserRegisterDto model, string Role)
        {
            if (await _mySqlDbContex.user.FirstOrDefaultAsync(u => u.Email == model.Email) is not null)
                throw new MABException(MABErrorCodes.USER_ALREADY_EXISTS_CODE);

            if (string.IsNullOrEmpty(model.Password))
                throw new MABException(MABErrorCodes.USER_PASSWORD_IS_NULL_CODE);

            IdentityHelper.GetPasswordHashAndSalt(model.Password, out string hash, out string salt);

            var user = new UserModel
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = Role,
               // AddDate=DateTime.Now,
                PhoneNumber=model.PhoneNumber

            };

            _mySqlDbContex.Add(user);
            int result = _mySqlDbContex.SaveChanges();
            if (result <= 0)
            {
                // throw new MAPException(MAPErrorCodes.DB_UNABLE_TO_INSERT_RECORD_CODE);
                throw new Exception();
            }

            return new UserDto() { Id = user.Id, Email = user.Email };
        }

        public async Task<JwtTokenModel> Login(UserLoginDto userLoginDto)
        {
            UserModel user = string.IsNullOrEmpty(userLoginDto.EmailAddress) ?
                              null
                              : await _mySqlDbContex.user.FirstOrDefaultAsync(u => u.Email == userLoginDto.EmailAddress);
            if (user is null || !IdentityHelper.ValidatePassword(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {

                throw new MABException(MABErrorCodes.INVALID_USERNAME_OR_PASSWORD_CODE);
            }
            

            var jwtSecurityToken = GenerateToken(user);

            return jwtSecurityToken;
        }

        public JwtTokenModel GenerateToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var cerdentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
				
				new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            DateTime currentDate = DateTime.Now;
            var expiresInSeconds = _configuration.GetValue<int>("Jwt:ExpiresIn");
            DateTime expiresIn = currentDate.AddSeconds(expiresInSeconds);
            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiresIn,
                signingCredentials: cerdentials);

            JwtTokenModel tokenModel = new JwtTokenModel()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                TokenType = "Bearer",
                ExpiresIn = expiresInSeconds
            };
            return tokenModel;
        }

        public bool IsAuthenticated(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUser(int userId)
        {
            UserModel user = await _mySqlDbContex.user.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new MABException (MABErrorCodes.SYS_UNKNOWN_ERROR_CODE);

            }
            return user;
        }

        public async Task<string> GetSalt(int UserId)
        {
            var salt = await _mySqlDbContex.user.AsNoTracking().Where(x => x.Id == UserId).FirstOrDefaultAsync();
            return salt.PasswordSalt;

        }

        public async Task<string> GetHash(int UserId)
        {
            var hash = await _mySqlDbContex.user.AsNoTracking().Where(x => x.Id == UserId).FirstOrDefaultAsync();
            return hash.PasswordHash;

        }
       
       
    }
}
