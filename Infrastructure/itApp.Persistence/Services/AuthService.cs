using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using grammerGame.Application.Abstractions.Services;
using grammerGame.Application.Abstractions.Token;
using grammerGame.Application.DTOs;
using grammerGame.Application.Exceptions;
using grammerGame.Domain.Entities.Identity;
using grammerGame.Application.Repositories;
using grammerGame.Domain.Entities;

namespace grammerGame.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly IConfiguration _configuration;
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IGameProgressWriteRepository _gameProgressWriteRepository;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly IUserService _userService;
        public AuthService(
            IConfiguration configuration,
            UserManager<Domain.Entities.Identity.AppUser> userManager,
            ITokenHandler tokenHandler,
            SignInManager<AppUser> signInManager,
            IUserService userService
,
            IGameProgressWriteRepository gameProgressWriteRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userService = userService;
            _gameProgressWriteRepository = gameProgressWriteRepository;
        }
        async Task<(Token, int)> CreateUserExternalAsync(AppUser user, GoogleJsonWebSignature.Payload payload, UserLoginInfo info, int accessTokenLifeTime,int refreshTokenLifeTimeSecond)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        FullName = payload.Name,
                        UserName = payload.Email,
                        GivenName = payload.GivenName,
                        FamilyName = payload.FamilyName,
                        Email = payload.Email,  
                        Photo = payload.Picture,
                        RefreshToken = "",// zaten bir sonraki if dongusu icerisinde refresh token update ediyoruz
                        RefreshTokenEndDate = DateTime.UtcNow,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    var userId = await _userManager.GetUserIdAsync(user);
                   if (identityResult != null && userId != null)
                    {
                       GameProgress gameProgress = new GameProgress() {     
                           AppUserId=int.Parse(userId),
                       };
                        await _gameProgressWriteRepository.AddAsync(gameProgress);
                   }
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info); //AspNetUserLogins
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, refreshTokenLifeTimeSecond);
                var usr =await _userManager.Users.Where(x => x.UserName == user.UserName).FirstOrDefaultAsync(); 
                return (token,usr.Id);
            }
            throw new Exception("custom error,Invalid external authentication.");
        }
        
        public async Task<(Token, int)> GoogleLoginAsync(string idToken, int accessTokenLifeTimeSecond,int refreshTokenLifeTimeSecond)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
            };
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
                var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
                Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                return await CreateUserExternalAsync(user, payload, info, accessTokenLifeTimeSecond, refreshTokenLifeTimeSecond);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 

         
        }

        public async Task<LoginResponseDTO> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTimeSecond, int refreshTokenLifeTimeSecond)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) //Authentication başarılı!
            {
                Token tokenn = _tokenHandler.CreateAccessToken(accessTokenLifeTimeSecond, user);
                await _userService.UpdateRefreshTokenAsync(tokenn.RefreshToken, user, tokenn.Expiration, refreshTokenLifeTimeSecond);
                return new (){ 
                    token = tokenn,
                    userid = user.Id,  
                    username=user.UserName
                };
            }
            throw new AuthenticationErrorException();
        }

        public Task PasswordResetAsnyc(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken, int second)// var olan refreh token kullnarak yeni bir token olusturur ve onunda üzerine koyarak yeni bir resfresh token olusturur.
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(second, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, second);
                return token;
            }
            else
                throw new NotFoundUserException();
        }

    }
}
