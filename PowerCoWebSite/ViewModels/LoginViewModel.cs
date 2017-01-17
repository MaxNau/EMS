
using System.ComponentModel.DataAnnotations;

namespace PowerCoWebSite.ViewModels
{
    public class LoginViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}