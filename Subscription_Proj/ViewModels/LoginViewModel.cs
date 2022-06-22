using System.ComponentModel.DataAnnotations;

namespace Subscription_Proj.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter the username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
