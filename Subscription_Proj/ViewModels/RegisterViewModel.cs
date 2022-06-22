using System.ComponentModel.DataAnnotations;

namespace Subscription_Proj.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required(ErrorMessage = "Enter the first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the last name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
