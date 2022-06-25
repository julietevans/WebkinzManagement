using System.ComponentModel.DataAnnotations;

namespace WebkinzManagement.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter first name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
