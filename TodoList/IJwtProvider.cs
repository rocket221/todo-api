using TodoList.ViewModels;

namespace TodoList
{
    public interface IJwtProvider
    {
        string GenerateToken(UserViewModel user);
    }
}
