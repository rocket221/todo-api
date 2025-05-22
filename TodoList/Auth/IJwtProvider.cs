using TodoList.Dtos;

namespace TodoList.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto user);
    }
}
