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
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        // GET: api/values
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        public void Delete(int id)
        {
        }
    }
}
