
namespace PowerCoWebSite.Data.Repositories
{
    interface IUsersRepository
    {
        bool IsUserExists(string name, string password);
    }
}
