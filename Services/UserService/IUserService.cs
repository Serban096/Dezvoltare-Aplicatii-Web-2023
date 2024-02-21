﻿using Proiect.Models;
using Proiect.Models.DTOs;
using Proiect.Models.DTOs.UserDTO;
using Proiect.Models.Enums;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetByUsername(string username);

        Task<User> GetById(Guid id);

        Task Delete(Guid id);

        Task UpdateUser(UserUpdateDTO user);

    }
}
