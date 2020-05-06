using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetNote.MVC6.Models
{
    public class Note
    {
        /// <summary>
        /// Note Number
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// Note Title
        /// </summary>
        [Required]
        public string NoteTitle { get; set; }

        /// <summary>
        /// Note Contents
        /// </summary>
        [Required]
        public string NoteContents { get; set; }

        /// <summary>
        /// User Number
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }
}
