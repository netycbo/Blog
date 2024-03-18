using System.ComponentModel.DataAnnotations;

namespace Blog.DataAccess.Entities
{
    public class Administrator : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        public List<User> Users { get; set; }
    }
}
