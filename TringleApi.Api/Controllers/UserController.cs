using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Context;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.User;
using TringleApi.Api.Services.User;
using TringleApi.Api.WebApiResponse;

namespace TringleApi.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> PostUser(UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(request);
                var insertResult = await _userRepository.Add(user);
                if (insertResult != null)
                {
                    return Ok(new WebApiResponse<UserResponse>(true, "Succes", _mapper.Map<User, UserResponse>(user)));
                }
            }
            return BadRequest(new WebApiResponse<UserResponse>(false, ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString()));
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetUsers()
        {
            var users = _mapper.Map<List<UserResponse>>(await _userRepository.GetAll(x=>x.Accounts));
            if (users.Count>0)
            {
                return Ok(new WebApiResponse<List<UserResponse>>(true, "Success", users));
            }
            return BadRequest(new WebApiResponse<List<UserResponse>>(false, "Error"));
        }
    }
}
