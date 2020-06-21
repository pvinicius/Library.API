using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/v1/application-users")]
    [Authorize("Administrator")]
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserController(IApplicationUserService applicationUserService, SignInManager<ApplicationUser> signInManager)
        {
            _applicationUserService = applicationUserService;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public Task<Response<ApplicationUser>> Login([FromBody] ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = new ApplicationUser(applicationUserDTO.Id, applicationUserDTO.UserName, applicationUserDTO.Email, applicationUserDTO.PasswordHash);
            return _applicationUserService.Login(applicationUser);
        }

        [HttpGet]
        [Route("login-facebook")]
        [AllowAnonymous]
        public IActionResult LoginFacebook()
        {
            //TODO
            string returnUrl = null;
            string provider = "Facebook";

            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<Response<ApplicationUser>> Get(int id)
        {
            return _applicationUserService.Get(id);
        }

        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        public Task<Response<ApplicationUser>> Post([FromBody] ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = new ApplicationUser(applicationUserDTO.Id, applicationUserDTO.UserName, applicationUserDTO.Email, applicationUserDTO.PasswordHash);
            return _applicationUserService.Add(applicationUser);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Task<List<Response<ApplicationUser>>> Put(Guid id, [FromBody] ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = new ApplicationUser(id, applicationUserDTO.UserName, applicationUserDTO.Email, applicationUserDTO.PasswordHash);
            return _applicationUserService.Update(applicationUser);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Task<Response<ApplicationUser>> Delete(int id)
        {
            return _applicationUserService.Remove(id);
        }
    }
}
