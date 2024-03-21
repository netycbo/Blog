using Blog.DataAccess.CQRS.Queries;

namespace Blog.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private BlogstorageContext _context;
        public QueryExecutor(BlogstorageContext context)
        { 
            _context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}
