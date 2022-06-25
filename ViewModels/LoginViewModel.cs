using System.ComponentModel.DataAnnotations;

namespace WebkinzManagement.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
