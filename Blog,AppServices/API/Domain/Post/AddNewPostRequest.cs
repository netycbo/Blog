
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Blog_AppServices.API.Domain.Post
{
    public class AddNewPostRequest : IRequest<AddNewPostResponse>
    {
        [Required]
        
        public int UserId { get; set; }
        [Required]
        public int AdminId { get; set; }
        
        [MaxLength(20)]
        public string Topic { get; set; }
        public string Content { get; set; }
    }
}
