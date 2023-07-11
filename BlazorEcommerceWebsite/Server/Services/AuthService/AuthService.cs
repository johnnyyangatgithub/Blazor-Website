using System;
using System.Security.Cryptography;
using Azure.Core;
using static System.Net.WebRequestMethods;

namespace BlazorEcommerceWebsite.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        public AuthService (DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if(await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash( password, out byte[] passwordHash, out byte[] passwordSalt );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add( user );
            // Save the change to the database.
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            if(await _context.Users.AnyAsync(user => user.Email.ToLower()
                .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                // Create a generated key and will be used for the salt.
                passwordSalt = hmac.Key;
                // Will use the salt and the given password to create the passwordHash.
                passwordHash = hmac.ComputeHash( System.Text.Encoding.UTF8.GetBytes( password ) );
            }
        }
    }
}

