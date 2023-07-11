﻿using System;
namespace BlazorEcommerceWebsite.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register ( UserRegister request );
    }
}
