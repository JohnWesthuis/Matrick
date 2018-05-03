using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Matricks.Models;
using Microsoft.EntityFrameworkCore;

namespace Matricks.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<User> Login(string userName, string password)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

      return (user == null || !PasswordHashVerified(password, user.PasswordHash, user.PasswordSalt)) ? null : user;
    }

    private bool PasswordHashVerified(string password, byte[] passwordHash, byte[] passwordSalt)
    {
     
      var hash = new HMACSHA512(passwordSalt);

      var hashedPassword = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

      for (int i = 0; i < hashedPassword.Length; i++)
      {
        if (!(hashedPassword[i] == passwordHash[i]))
          return false;
      }
      return true;
    }


    public bool isDuplicate(String userName)
    {
      var user = _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
      if (!(user == null))
        return true;
      else
        return false;
    }

    public async Task<User> Register(string userName, string password)
    {
        // Hash the password using SHA512 with random key (salt)
        var hash = new HMACSHA512();
        var computedHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        var newUser = new User { UserName = userName };
        newUser.PasswordHash = computedHash;
        newUser.PasswordSalt = hash.Key;
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
          return newUser;
    }

    private User StatusCode(int v)
    {
      throw new NotImplementedException();
    }
  }
}
