using System.ComponentModel.DataAnnotations;

namespace Blog.DataAccess.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }

    }
}
