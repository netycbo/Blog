using Blog.DataAccess.Entities;

namespace Blog.DataAccess.CQRS.Commands
{
    public class AddNewUserCommand : CommandsBase<User, User>
    {
        public override async Task<User> Execute(BlogstorageContext context)
        {
           await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
