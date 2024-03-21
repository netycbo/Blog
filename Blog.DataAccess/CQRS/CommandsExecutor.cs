﻿using Blog.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.CQRS
{
    public class CommandsExecutor : ICommandsExecutor
    {
        private readonly BlogstorageContext _context;
        public CommandsExecutor(BlogstorageContext context)
        {
            _context = context;
        }
        public Task<TResult> Execute<TParameter, TResult>(CommandsBase<TParameter, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}
