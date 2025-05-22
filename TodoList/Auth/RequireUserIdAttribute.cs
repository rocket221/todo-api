using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TodoList.Controllers;

namespace TodoList.Auth
{
    public class RequireUserIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as BaseController;
            if (controller?.UserId == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
