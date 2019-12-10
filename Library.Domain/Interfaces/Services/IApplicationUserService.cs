﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.DTO;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.Services
{
    public interface IApplicationUserService
    {
        Task<Response<ApplicationUser>> Add(ApplicationUser entity);

        Task<List<Response<ApplicationUser>>> Update(ApplicationUser entity);

        Task<Response<ApplicationUser>> Remove(int id);

        Task<Response<ApplicationUser>> Login(ApplicationUser user);

        Task<Response<ApplicationUser>> Get(int id);

        Response<ApplicationUser> GetAll();

        void Dispose();
    }
}
