using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Authentication.Dtos;
using WebApplication1.Authentication.Services.Interface;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Authentication.Services
{
    public class AuthenServices : IAuthenService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IInformationRepository _informationRepository;

        public AuthenServices(IUserRepository userRepository, IInformationRepository informationRepository)
        {
            _userRepository = userRepository;
            _informationRepository = informationRepository;
        }

        public async Task<LoginResponse> Login(Login login)
        {
            Users? user = (await _userRepository.FindUserByEmail(login.Email)).FirstOrDefault();
            if (user is null)
            {
                throw new Exception("User not found");
            }
            else if (!VerifyPassword(login.Password, user.salt, user.Password))
            {
                throw new Exception("Invalid password");
            }

            string token = CreateToken(user);
            LoginResponse response = new LoginResponse();

            response.email = user.Email;
            response.token = token;
            response.role = "User";


            return response;
        }

        public async Task<ResultReturn> Register(Register register)
        {
           try
            {
                Hashing pass = EncryptPassword(register.Password);

                Information information = new Information();
                Users users = new Users();
                users.Email = register.Email;
                users.Password = pass.HashPassword;
                users.salt = pass.Salt;
                users.Information = information;
                information.Name = register.Name;


                await _userRepository.CreateUser(users, information);

            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Can't create user");
            }

            ResultReturn result = new ResultReturn();
            result.Email = register.Email;
            result.Name = register.Name;

            return result;
        }

        private string CreateToken(Users users)
        {
            /*JwtSecurityTokenHandler token = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes("cxjOMewdFfeZFQm5iGAYxTjR23Z93rLbyZucty3");
            SecurityTokenDescriptor securityToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, users.Email),
                    new Claim(ClaimTypes.Role, "User")

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "http://localhost:5296",
                Audience = "http://localhost:5296"
            };
            return token.WriteToken(token.CreateToken(securityToken));*/

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("cxjOMewdFfeZFQm5iGAYxTjR23Z93rLbyZucty3"));
            SigningCredentials cre = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            Claim[] userCliam =
            {
                new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()),
                new Claim(ClaimTypes.Name, users.Email.ToString()),
                new Claim(ClaimTypes.Role, "User")

            };
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://localhost:5296",
                audience: "http://localhost:5296",
                claims: userCliam,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cre
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Hashing EncryptPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128/8);
            string encrypt = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256/8
                ));
            Hashing hashing = new Hashing()
            {
                HashPassword = encrypt,
                Salt = salt,
            };

            return hashing;
        }

        private bool VerifyPassword(string password, byte[] salt, string storePassword )
        {
            string encrypt = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));
            return encrypt == storePassword;

        }
    }
}
