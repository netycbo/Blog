using Blog.DataAccess.Entities;

namespace Blog.DataAccess.CQRS.Commands
{
    public class AddNewCommentCommand : CommandsBase<Comments, Comments>
    {
        public override async Task<Comments> Execute(BlogstorageContext context)
        {
            await context.Comments.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
