using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.UserDirectory.Dto;

namespace WebApi.UserDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registerVeteran")]
        public async Task<IActionResult> AddClient([FromBody]AddUserDto userDto)
        {
            await _userService.AddClient(userDto);
            return Ok();
        }

        //[Authorize(Policy = "admin")]
        [HttpPost("registerVeteranCenter")]
        public async Task<IActionResult> AddAdmin([FromBody]AddUserDto userDto)
        {
            await _userService.AddAdmin(userDto);
            return Ok();
        }

        [HttpPost("registerEnterpreneur")]
        public async Task<IActionResult> AddEnterpreneur([FromBody] AddUserDto userDto)
        {
            await _userService.AddEnterpreneur(userDto);
            return Ok();
        }


        [HttpPut("activateAccount")]
        public async Task<IActionResult> ConfirmAccount([FromBody] ActivateUser activationData )
        {
            await _userService.ActivateAccount(activationData.Email, activationData.ActivateKey);
            return Ok();
        }

        [HttpPut("activateVeteranCard/{id}")]
        public async Task<IActionResult> ConfirmAccount(Guid id)
        {
            await _userService.ActivateCard(id);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var token = await _userService.Login(userLogin);
            return Ok(new
            {
                token = token
            });
        }

        [HttpPost("addFriend")]
        public async Task<IActionResult> AddFriend([FromBody] IdDto d)
        {
            await _userService.AddFriend(d);
            return Ok();
        }

        [HttpGet("allClients")]
        public async Task<IActionResult> AllClients()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("getFriends/{idVeteran}")]
        public async Task<IActionResult> AllClients(Guid idVeteran)
        {
            var friends = await _userService.GetFriends(idVeteran);
            return Ok(friends);
        }

        [HttpGet("GetAllVeterans")]
        public async Task<IActionResult> AllVeterans()
        {
            var veterans = await _userService.GetVeterans();
            return Ok(veterans);
        }
        [HttpGet("GetInactiveVeterans")]
        public async Task<IActionResult> AllVeteransInActtve()
        {
            var veterans = await _userService.GetInactiveVeterans();
            return Ok(veterans);
        }
        [HttpGet("GetVeteranById/{id}")]
        public async Task<IActionResult> GetVeteran(Guid id)
        {
            var veteran = await _userService.GetVeteran(id);
            return Ok(veteran);
        }
        [HttpGet("GetEnterpreneursByBusinessId/{id}")]
        public async Task<IActionResult> GetEnterpreneurs(Guid id)
        {
            var enterpreneurs = await _userService.GetEnterpreneurs(id);
            return Ok(enterpreneurs);
        }
    }
}