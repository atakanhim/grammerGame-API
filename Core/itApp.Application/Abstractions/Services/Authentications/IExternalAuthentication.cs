using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<(DTOs.Token,int)> GoogleLoginAsync(string idToken, int accessTokenLifeTimeSecond, int refreshTokenLifeTimeSecond);
    }
}
