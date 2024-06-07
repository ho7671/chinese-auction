using AutoMapper;
using Chines_auction_project.BLL;
using Chines_auction_project.Modells;
using Chines_auction_project.Modells.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Chines_auction_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }
        [HttpGet("GetAllUsers")]
       public async Task<ActionResult<User>> GetAllusers()
        {
            var users=await userService.GetAllusers();
            return users == null ? NotFound() : Ok(users);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto user)
        {
            var u = mapper.Map<User>(user);
            return Created($"http://localhost:3000/user/{u.Id}", await userService.Register(u));
        }
        [HttpPost("Login")]

        //public async Task<ActionResult<User>> Login(UserDto user)
        //{
        //    var u = mapper.Map<User>(user);
        //    return Created($"http://localhost:3000/user/{u.Id}", await userService.Login(u));
        //}

        [HttpDelete("RemoveUser/{id}")]
        public async Task<ActionResult<User>> RemoveUser(int id)
        {
            return id == null ? NotFound() : Ok(await userService.RemoveUser(id));

        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<ActionResult<User>> UpdateUser(UserDto user, int id)
        {
            var u = mapper.Map<User>(user);
            return u == null ? NotFound() : Ok(await userService.UpdateUser(u, id));
        }

    }
    
}
