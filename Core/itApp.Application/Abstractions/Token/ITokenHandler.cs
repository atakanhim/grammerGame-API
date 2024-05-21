using grammerGame.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace grammerGame.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int accessTokenLifeTimeSecond, AppUser appUser);
        string CreateRefreshToken();
    }
}
