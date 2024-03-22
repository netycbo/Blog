using Blog.DataAccess.Entities;

namespace Blog.DataAccess.CQRS.Commands
{
    public class AddNewPostCommand : CommandsBase<NewPost, NewPost>
    {
        public override async Task<NewPost> Execute(BlogstorageContext context)
        {
            await context.Posts.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
