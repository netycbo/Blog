using System.ComponentModel.DataAnnotations;
namespace Blog.DataAccess.Entities
{
    public class Comments : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        public int PostId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        public List<User> Users { get; set; }
        public List<NewPost> Posts { get; set; }

    }
}
