using System;

namespace Library.Domain.DTO
{
    public class ApplicationUserDTO
    {
        public ApplicationUserDTO()
        {
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
