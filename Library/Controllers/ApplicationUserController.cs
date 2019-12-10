using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/v1/application-users")]
    [Authorize("Bearer")]
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<Response<ApplicationUser>> Get(int id)
        {
            return _applicationUserService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Task<Response<ApplicationUser>> Post([FromBody]ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = new ApplicationUser(applicationUserDTO);
            return _applicationUserService.Add(applicationUser);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public Task<Response<ApplicationUser>> Login([FromBody] ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = new ApplicationUser(applicationUserDTO);
            return _applicationUserService.Login(applicationUser);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Task<List<Response<ApplicationUser>>> Put(int id, [FromBody]ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = new ApplicationUser(applicationUserDTO);
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
