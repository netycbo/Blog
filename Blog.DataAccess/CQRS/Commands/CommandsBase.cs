using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.CQRS.Commands
{
    public abstract class CommandsBase<TParameter, TResult>
    {
        public TParameter Parameter { get; set; }
        public abstract Task<TResult> Execute(BlogstorageContext context);
    }
}
