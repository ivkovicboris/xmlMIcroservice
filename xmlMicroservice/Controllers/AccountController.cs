using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using xmlMicroservice.BLL.Contracts;
using xmlMicroservice.BLL.Models;
using xmlMicroservice.DAL.Entites;
using xmlMicroservice.Models;

namespace xmlMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserContract _userContract;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<User> signInManager,
                                   UserManager<User> userManager,
                                   IUserContract userContract,
                                   IMapper mapper,
                                   IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userContract = userContract;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<bool> Register([FromBody] RegisterModel model)
        {

            var result = await _userContract.RegisterUser(_mapper.Map<RegisterModel, RegisterPOCO>(model));
            if (result)
            {
                return true;
            }
            return false;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<object> Login([FromBody] LoginModel model)
        {
            return await _userContract.LoginUser(_mapper.Map<LoginModel, LoginPOCO>(model));
        }
    }
}
