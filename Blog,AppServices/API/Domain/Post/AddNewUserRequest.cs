using MediatR;

using System.ComponentModel.DataAnnotations;


namespace Blog_AppServices.API.Domain.Post
{
    public class AddNewUserRequest :IRequest<AddNewUserResponse>
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

    }
}
