﻿using Application.DTOs.Users;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddres);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
