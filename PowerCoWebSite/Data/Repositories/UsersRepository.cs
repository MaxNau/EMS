using System.Linq;

namespace PowerCoWebSite.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public bool IsUserExists(string name, string password)
        {
            using (var context = new PowerCoEntity())
            {
                return context.Users.Any(u => u.Name == name && u.Password == password);
            }
        }
    }
}