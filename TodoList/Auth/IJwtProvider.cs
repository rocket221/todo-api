using TodoList.ViewModels;

namespace TodoList.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(UserViewModel user);
    }
}
