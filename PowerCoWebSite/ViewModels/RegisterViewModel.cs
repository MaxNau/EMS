
using PowerCoWebSite.Data.Repositories;
using PowerCoWebSite.Models;

namespace PowerCoWebSite.ViewModels
{
    public class RegisterViewModel
    {
        private IUsersRepository usersRepository;

        public RegisterViewModel()
        {
            usersRepository = new UsersRepository();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private bool IsUserNameExists()
        {
            return usersRepository.IsUserNameExists(Name);
        }

        public bool RegisterUser()
        {
            if (IsUserNameExists())
            {
                return false;
            }
            else
            {
                User user = new User();
                user.Name = Name;
                user.Email = Email;
                user.Password = Password;
                user.Roles.Add(new Role { Id = 2, Name = "User" });
                usersRepository.AddUser(user);

                return true;
            }
        }
    }
}