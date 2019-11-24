using Library.Domain.DTO;
using Microsoft.AspNetCore.Identity;
using System;

namespace Library.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {

        }

        public ApplicationUser(ApplicationUserDTO applicationUserDTO)
        {
            Id = applicationUserDTO.Id;
            UserName = applicationUserDTO.UserName;
            Email = applicationUserDTO.Email;
            PasswordHash = applicationUserDTO.PasswordHash;
        }
    }
}
