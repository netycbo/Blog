using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.DataAccess.Entities;
using Blog.DataAccess;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IEnumerable<User> GetAllUser() => _userRepository.GetAll();
        
    }
}
