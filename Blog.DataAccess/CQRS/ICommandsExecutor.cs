using Blog.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.CQRS
{
    public interface ICommandsExecutor
    {
        Task<TResult> Execute<TParameter, TResult>(CommandsBase<TParameter, TResult> command);
    }
}
