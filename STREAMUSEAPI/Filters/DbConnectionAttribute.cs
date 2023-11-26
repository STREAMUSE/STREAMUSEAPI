using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using STREAMUSEAPI.Consts;
using STREAMUSEAPI.Models;

namespace STREAMUSEAPI.Filters
{
    public class DbConnectionFilter : IAsyncAuthorizationFilter
    {
        private readonly STREAMUSEDbContext dbContext;

        public DbConnectionFilter(STREAMUSEDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!await dbContext.Database.CanConnectAsync())
            {
                Log.Error($"{Error.DB_CONNECTION_FAILED.Value}");
                context.Result = Error.DB_CONNECTION_FAILED;
            }
        }
    }
}
