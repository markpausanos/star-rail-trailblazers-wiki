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

        public async Task<UserCreationLoginDto?> Authenticate(UserCreationLoginDto userDto)
        {
            var user = await _userRepository.GetUserByName(userDto.Name!);
            if (user == null || user.Password != userDto.Password)
            {
                return null;
            }

            return _mapper.Map<UserCreationLoginDto>(user);
        }

        public async Task<string?> GenerateToken(UserCreationLoginDto userDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userType = (await _userRepository.GetUserByName(userDto.Name))!.UserType;
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
        public async Task<string?> CreateUser(UserCreationLoginDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            if (await _userRepository.GetUserByName(userDto.Name!) != null)
            {
                throw new InvalidOperationException($"User '{userDto.Name}' already exists.");
            }

            var newUser = _mapper.Map<User>(userDto);
            await _userRepository.CreateUser(newUser);

            return await GenerateToken(userDto);
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<bool> UpdateUserById(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new ArgumentNullException(id.ToString());
            }

            user.Password = userUpdateDto.Password;

            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUserById(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
