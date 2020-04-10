﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
