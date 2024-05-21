using grammerGame.Application.DTOs.User;
using grammerGame.Domain.Entities.Identity;



namespace grammerGame.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string usurId);
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task<ListUser> GetUser(string userName);

        Task UpdateRefreshTokenAsync(string? refreshToken, AppUser user, DateTime? accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
        Task<List<ListUser>> GetAllUsersAsync(int page, int size);
        int TotalUsersCount { get; } 
        Task AssignRoleToUserAsnyc(string userId, string[] roles);
        Task<string[]> GetRolesToUserAsync(string userIdOrName);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
