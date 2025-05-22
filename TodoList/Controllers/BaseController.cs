using Microsoft.AspNetCore.Mvc;
using TodoList.Auth;

namespace TodoList.Controllers
{
    public class BaseController : ControllerBase
    {
        public int? UserId => User.GetUserId();
    }
}
