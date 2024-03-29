﻿using MediatR;
using Blog.DataAccess.CQRS.Queries;
using Blog.DataAccess.Entities;
using Blog.DataAccess;
using Blog_AppServices.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Blog_AppServices.API.Domain.Get;
namespace Blog_AppServices.API.Handlers.GetHandlers
{
    public class GetUserHandler : IRequestHandler<GetUsersRequest, GetUserResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        public GetUserHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        public async Task<GetUserResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Name = request.Name
            };

            var users = await _queryExecutor.Execute(query);
            var mappedUser = _mapper.Map<List<UserDto>>(users);
            var response = new GetUserResponse()
            {
                Data = mappedUser
            };
            return response;
        }
    }
}



