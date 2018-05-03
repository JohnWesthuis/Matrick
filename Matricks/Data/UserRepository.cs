using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricks.Models;

namespace Matricks.Data
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
      _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
      throw new NotImplementedException();
    }

    public void Delete<T>(T entity) where T : class
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUser(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
      throw new NotImplementedException();
    }

    public Task<bool> SaveAll()
    {
      int numberOfChanges;

      numberOfChanges = _context.SaveChanges();

      if (numberOfChanges > 0)
        return Task.FromResult(true);
      else
        return Task.FromResult(false);
    }
  }
}
