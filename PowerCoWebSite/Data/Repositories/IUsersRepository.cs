using PowerCoWebSite.Models;

namespace PowerCoWebSite.Data.Repositories
{
    interface IUsersRepository
    {
        User GetUser(string name, string password);
    }
}
