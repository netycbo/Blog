
namespace Blog_AppServices.API.DTO
{
    public class CommentsDto
    {
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int PostId { get; set; }
        public string FormattedDate { get; set; }
    }
}
