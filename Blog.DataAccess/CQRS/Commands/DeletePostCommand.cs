using Blog.DataAccess.Entities;


namespace Blog.DataAccess.CQRS.Commands
{
    public class DeletePostCommand : CommandsBase<NewPost, NewPost>
    {
        public async override Task<NewPost> Execute(BlogstorageContext context)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == this.Parameter.Id);
            if (post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();

                return post;
            }
            return null;
        }
    }
}
