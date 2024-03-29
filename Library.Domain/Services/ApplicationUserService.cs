﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Library.Domain.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace Library.Domain.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppSettings _appSettings;

        public ApplicationUserService(UserManager<ApplicationUser> userManager,
                                      SignInManager<ApplicationUser> signInManager,
                                      IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        public async Task<Response<ApplicationUser>> Login(ApplicationUser applicationUser)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(applicationUser.UserName, applicationUser.PasswordHash, false, true);
            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(applicationUser.Email);
                var userRole = await _userManager.GetRolesAsync(user);
                var token = GenerateJwt(userRole.FirstOrDefault());

                return new Response<ApplicationUser>(success: true, message: "Logado com sucesso!", data: token);
            }
            return new Response<ApplicationUser>(success: false, message: "Erro ao logar.", data: signInResult);
        }

        public async Task<Response<ApplicationUser>> LoginFacebook(ApplicationUser applicationUser)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return new Response<ApplicationUser>
                {
                    Success = false,
                    Message = "",
                    Data = info
                };
            }

            var result = await _userManager.AddLoginAsync(applicationUser, info);
            if (result.Succeeded)
            {
                foreach (var token in info.AuthenticationTokens)
                {
                    await _userManager.SetAuthenticationTokenAsync(applicationUser, info.LoginProvider, token.Name, token.Value);
                }

                await _signInManager.SignInAsync(applicationUser, isPersistent: true);
                return new Response<ApplicationUser>
                {
                    Success = true,
                    Message = "",
                    Data = applicationUser
                };
            }

            return new Response<ApplicationUser>
            {
                Success = false,
                Message = "",
                Data = result.Errors
            };
        }

        public async Task<Response<ApplicationUser>> Add(ApplicationUser applicationUser)
        {
            var identityResult = await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);

            if (identityResult.Succeeded)
                return new Response<ApplicationUser>(success: true, message: "Usuário criado com sucesso!", data: applicationUser.UserName);

            return new Response<ApplicationUser>(success: true, message: "Erro ao criar o usuário.", data: identityResult.Errors);
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

        public async Task<Response<ApplicationUser>> Get(int id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id.ToString());
            return new Response<ApplicationUser>(success: true, message: "Ok", data: applicationUser);
        }

        public async Task<Response<ApplicationUser>> Remove(int id)
        {
            var response = Get(id);

            if (response.Result.Success)
            {
                var applicationUser = (ApplicationUser)response.Result.Data;
                var applicationUserResult = await _userManager.DeleteAsync(applicationUser);

                if (applicationUserResult.Succeeded)
                    return new Response<ApplicationUser>(success: true, message: "Usuário excluído com sucesso!", data: applicationUser);

                return new Response<ApplicationUser>(success: false, message: "Erro ao excluir o usuário.", data: applicationUser);
            }

            return new Response<ApplicationUser>(success: false, message: "Usuário não encontrado.", data: id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #region private methods
        private string GenerateJwt(string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, role)
                }),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidOn,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHour),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var createToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createToken);
        }

        private async Task<Response<ApplicationUser>> UpdateUserName(ApplicationUser user)
        {
            var setUserNameResult = await _userManager.SetUserNameAsync(user, user.UserName);

            if (setUserNameResult.Succeeded)
                return new Response<ApplicationUser>(success: true, message: "Nome atualizado com sucesso!", data: user.UserName);

            return new Response<ApplicationUser>(success: false, message: "Erro ao atuaizar nome do usuário.", data: setUserNameResult.Errors);
        }

        private async Task<Response<ApplicationUser>> UpdateEmail(ApplicationUser user)
        {
            var setEmailResult = await _userManager.SetEmailAsync(user, user.Email);

            if (setEmailResult.Succeeded)
                return new Response<ApplicationUser>(success: true, message: "Email atualizado com sucesso!", data: user.Email);

            return new Response<ApplicationUser>(success: false, message: "Erro ao atualizar email do usuário", data: setEmailResult.Errors);
        }
        #endregion
    }
}
