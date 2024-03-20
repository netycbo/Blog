using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Blog.DataAccess.Entities
{
    public class NewPost : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AdminId { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [MaxLength(20)]
        public string Topic { get; set; }
        public string Content { get; set; }
        public List<User> Users { get; set; }
    }
}
