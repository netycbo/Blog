using Blog.DataAccess.Entities;
using Blog.DataAccess.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<List<User>>
    {
        public string Name { get; set; }
        public override Task<List<User>> Execute(BlogstorageContext context)
        {
            if (Name != null)
            {
                return context.Users
                    .Where(x => x.Name == Name)
                    .ToListAsync();
            }
            else
            {
                return context.Users
                    .ToListAsync();
            }
          
        }
    }
}
