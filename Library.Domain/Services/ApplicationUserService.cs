using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Response<ApplicationUser>> Add(ApplicationUser applicationUser)
        {
            var identityResult = await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);

            if (identityResult.Succeeded)
                return new Response<ApplicationUser>
                {
                    Success = true,
                    Message = "Usuário criado com sucesso!",
                    Data = applicationUser.UserName
                };

            return new Response<ApplicationUser>
            {
                Success = false,
                Message = "Erro ao criar o usuário",
                Data = identityResult.Errors
            };
        }

        public async Task<List<Response<ApplicationUser>>> Update(ApplicationUser applicationUser)
        {
            List<Response<ApplicationUser>> responseList = new List<Response<ApplicationUser>>();
            var user = await _userManager.FindByIdAsync(applicationUser.Id.ToString());

            if (user.UserName != applicationUser.UserName)
            {
                user.UserName = applicationUser.UserName;
                var setUserNameResult = await UpdateUserName(user);
                responseList.Add(setUserNameResult);
            }

            if (user.Email != applicationUser.Email)
            {
                user.Email = applicationUser.Email;
                var setEmailResult = await UpdateEmail(user);
                responseList.Add(setEmailResult);
            }

            return responseList;
        }

        public Response<ApplicationUser> Remove(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ApplicationUser>> Login(ApplicationUser user)
        {
            var signInResult = await _signInManager.CanSignInAsync(user);
            return new Response<ApplicationUser>
            {
                Success = true,
                Message = "",
                Data = signInResult
            };
        }

        public Response<ApplicationUser> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Response<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #region private methods
        private async Task<Response<ApplicationUser>> UpdateUserName(ApplicationUser user)
        {
            var setUserNameResult = await _userManager.SetUserNameAsync(user, user.UserName);

            if (setUserNameResult.Succeeded)
                return new Response<ApplicationUser>
                {
                    Success = true,
                    Message = "Nome atualizado com sucesso!",
                    Data = user.UserName
                };

            return new Response<ApplicationUser>
            {
                Success = false,
                Message = "Erro ao atualizar nome do usuário.",
                Data = setUserNameResult.Errors
            };
        }

        private async Task<Response<ApplicationUser>> UpdateEmail(ApplicationUser user)
        {
            var setEmailResult = await _userManager.SetEmailAsync(user, user.Email);

            if (setEmailResult.Succeeded)
                return new Response<ApplicationUser>
                {
                    Success = true,
                    Message = "Email atualizado com sucesso!",
                    Data = user.Email
                };

            return new Response<ApplicationUser>
            {
                Success = false,
                Message = "Erro ao atualizar email do usuário.",
                Data = setEmailResult.Errors
            };
        }
        #endregion
    }
}
