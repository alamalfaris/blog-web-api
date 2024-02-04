using blog_web_api_shared.Entities;

namespace blog_web_api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}
