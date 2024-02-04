using blog_web_api_shared.Entities;

namespace blog_web_api.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
