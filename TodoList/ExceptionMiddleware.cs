using System.Net;

namespace TodoList
{
    public class ExceptionMiddleware
    {
		private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType= "application/json";

                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "Internal Server Error"
                }.ToString());
			}
        }
    }
}
