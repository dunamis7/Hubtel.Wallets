using System.Threading.Tasks;
using Hubtel.Wallets.Api.Models;
using Hubtel.Wallets.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hubtel.Wallets.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController :ControllerBase
    {
        private readonly IRepositoryService _repositoryService;

        public UserController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _repositoryService.CreateUser(user);
            return Ok($"User {user.Name} created");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repositoryService.GetUsers();
            return Ok(users);
        }
        
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repositoryService.GetUser(id);
            if (user == null)
                return NotFound();
            
            return Ok(user);
        }
        
        

    }
}