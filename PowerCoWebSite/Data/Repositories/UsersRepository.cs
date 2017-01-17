using PowerCoWebSite.Models;
using System.Linq;

namespace PowerCoWebSite.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public User GetUser(string name, string password)
        {
            User user;
            using (var context = new PowerCoEntity())
            {
                return user = context.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            }
        }
    }
}