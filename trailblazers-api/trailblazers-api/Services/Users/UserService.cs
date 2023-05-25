using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using trailblazers_api.Dtos.Users;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Users;
using trailblazers_api.Utils;

namespace trailblazers_api.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;
        public UserService (IUserRepository userRepository, IMapper mapper, JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtSettings = jwtSettings;
        }

        public async Task<bool> Authenticate(UserCreationLoginDto userDto)
        {
            var user = await _userRepository.GetUserByName(userDto.Name!);
            if (user == null || user.Password != userDto.Password)
            {
                return false;
            }

            return true;
        }

        public async Task<string?> GenerateToken(UserCreationLoginDto userDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userType = (await _userRepository.GetUserByName(userDto.Name!))!.UserType;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userDto.Name!.ToString()),
                new Claim(ClaimTypes.Role, userType.ToString()!)
            };

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserAccessDto?> GetCurrentUser(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                var userName = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Name)?.Value;

                return await GetUserByName(userName!);
            }

            return null;
        }
        public async Task<string?> CreateUser(UserCreationLoginDto newUser)
        {
            var userToCreate = _mapper.Map<User>(newUser);

            if (await GetUserByName(userToCreate.Name!) != null)
            {
                return null;
            }

            var newlyCreatedUser = await _userRepository.GetUserById(await _userRepository.CreateUser(userToCreate));
            return await GenerateToken(_mapper.Map<UserCreationLoginDto>(newlyCreatedUser));
        }
        public async Task<UserAccessDto?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            return user == null ? null : _mapper.Map<UserAccessDto>(user);
        }

        public async Task<UserAccessDto?> GetUserByName(string name)
        {
            var user = await _userRepository.GetUserByName(name);

            if (user == null)
            {
                return null;
            }

            var accessUser = _mapper.Map<UserAccessDto>(user);
            accessUser.Role = user.UserType == 'A' ? "Admin" : "User";
            return accessUser;
        }

        public async Task<bool> UpdateUserByName(UserUpdateDto updatedUser)
        {
            var userToUpdate = _mapper.Map<User>(updatedUser);

            return await _userRepository.UpdateUser(userToUpdate);
        }

        public async Task<bool> DeleteUser(string name)
        {
            return await _userRepository.DeleteUser(name);
        }
    }
}
