using MediatR;

using System.ComponentModel.DataAnnotations;

namespace Blog_AppServices.API.Domain.Post
{
    public class AddNewCommentRequest : IRequest<AddNewCommentResponse>
    {
        [Required]
        public int UserId { get; set; }
        public int PostId { get; set; }
        
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
