using System.Linq;
using PowerCoWebSite.Models;

namespace PowerCoWebSite.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public void AddUser(User user)
        {
            using (var context = new PowerCoEntity())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsUserExists(string name, string password)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Users.Any(u => u.Name == name && u.Password == password);
            }
        }

        public bool IsUserNameExists(string name)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Users.Any(u => u.Name == name);
            }
        }
    }
}