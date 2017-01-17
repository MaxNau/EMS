
using PowerCoWebSite.Models;

namespace PowerCoWebSite.Data.Repositories
{
    interface IUsersRepository
    {
        bool IsUserExists(string name, string password);
        bool IsUserNameExists(string name);
        void AddUser(User user);
    }
}
