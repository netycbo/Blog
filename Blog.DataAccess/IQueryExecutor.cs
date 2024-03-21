using System.Threading.Tasks;
using Blog.DataAccess.CQRS.Queries;

namespace Blog.DataAccess
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
