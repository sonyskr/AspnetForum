using System.ComponentModel.DataAnnotations;


namespace AspnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// User Number
        /// </summary>
        [Key] //Pirmary Key
        public int UserNo { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [Required] // Not Null setting
        public string UserName { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        [Required] // Not Null setting
        public string UserId { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [Required] // Not Null setting
        public string UserPassword { get; set; }
    }
}
