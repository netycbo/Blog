using Blog.DataAccess.Entities;
using Blog.DataAccess.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<List<User>>
    {
        public int Id { get; set; }
        public override Task<List<User>> Execute(BlogstorageContext context)
        {
            return  context.Users.ToListAsync();
               
        }
    }
}
