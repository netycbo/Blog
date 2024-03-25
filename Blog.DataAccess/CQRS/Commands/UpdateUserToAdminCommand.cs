using Blog.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DataAccess.CQRS.Commands
{
    public class UpdateUserToAdminCommand : CommandsBase<User, User>
    {
        public async override Task<User> Execute(BlogstorageContext context)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);

            if (user != null && user.IsAdmin == false)
            {
                user.IsAdmin = true;

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user;
            }
            return null;
        }
    }
}
