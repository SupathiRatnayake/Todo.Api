﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserDto user)
        {
            var result = await userService.AddUserAsync(user);
            return Ok(result); 
        }

        [HttpPost("getuser")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmailAsync([FromBody] EmailRequestDto emailDto)
        {
            var result = await userService.GetUserByEmailAsync(emailDto);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result); 
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersasync()
        {
            var result = await userService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid userId)
        {
            var result = await userService.GetUserByIdAsync(userId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserasyncUp([FromRoute] Guid userId, [FromBody] UserDto user)
        {
            if (userId != user.Id)  // checking if the id in the url is the same id in the object
            {
                return BadRequest();
            }
            var result = await userService.UpdateUserAsync(user);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid userId)
        {
            var result = await userService.DeleteUserAsync(userId);
            return Ok(result);
        }

        
    }
}
