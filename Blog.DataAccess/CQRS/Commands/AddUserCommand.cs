using Blog.DataAccess.Entities;

namespace Blog.DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandsBase<User, User>
    {
        public override async Task<User> Execute(BlogstorageContext context)
        {
           await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
