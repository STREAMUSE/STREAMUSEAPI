using Microsoft.AspNetCore.Mvc.Filters;
using STREAMUSEAPI.Consts;

namespace STREAMUSEAPI.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            context.Result = Error.SERVER_ERROR;
            await Task.CompletedTask;
        }
    }
}
