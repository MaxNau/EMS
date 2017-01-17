using PowerCoWebSite.Data.Repositories;
using PowerCoWebSite.Models;
using System.ComponentModel.DataAnnotations;

namespace PowerCoWebSite.ViewModels
{
    public class LoginViewModel
    {
        private IUsersRepository usersRepository;

        public LoginViewModel()
        {
            usersRepository = new UsersRepository();
        }

        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsUserExists(string name, string password)
        {
            return usersRepository.IsUserExists(name, password);
        }
    }
}