using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter User Password")]
        public string UserPassword { get; set; }
    }
}
