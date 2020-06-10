using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemPro.Api.Responses;
using SystemPro.Core.DTOs;
using SystemPro.Core.Entities;
using SystemPro.Core.Interfaces;

namespace SystemPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            var response = new ApiResponse<IEnumerable<UserDto>>(usersDtos);
            return Ok(usersDtos);
        }


        /// <summary>
        /// get user for id and password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("{id}/{password}")]
        public async Task<IActionResult> GetUser(int id, string password)
        {
            var user = await _userService.GetUser(id, password);
            if (user != null)
                return Ok(user);
            else
                return BadRequest();
        }


        /// <summary>
        /// get user for id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            var userDto = _mapper.Map<UserDto>(user);
            //var response = new ApiResponse<UserDto>(userDto);
            return Ok(userDto);
        }

        /// <summary>
        /// set new user userDto
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PosttUser(UserDto userDto) 
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.InsertUser(user);
            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }


        /// <summary>
        /// update user userDto for id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.UserId = id;
            var result = await _userService.UpdateUser(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        /// <summary>
        /// delete user for id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}