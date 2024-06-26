﻿using grammerGame.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<LoginResponseDTO> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTimeSecond, int refreshTokenLifeTimeSecond);
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken,int refreshTokenLifeTimeSecond);
    }
}
