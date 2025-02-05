namespace CentralAdminApp.API.Middleware
{
    public class AccessControlMiddleware
    {
        private readonly RequestDelegate _next;

        private static readonly List<string> _excludedRoutes = new()
        {
            "/swagger/index.html",
            "/swagger/v1/swagger.json"
        };

        public AccessControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_excludedRoutes.Contains(context.Request.Path.Value, StringComparer.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            var session = context.Session;
            var userProfile = session.GetString("UserProfile"); // Perfil armazenado na sessão
            var requestedPath = context.Request.Path.Value;
            var requestedMethod = context.Request.Method;
            /*
            if (string.IsNullOrEmpty(userProfile))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Usuário não autenticado.");
                return;
            }

            if (!await UserHasAccess(userProfile, requestedPath, requestedMethod))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Acesso negado.");
                return;
            }            
            */
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { message = "Usuário não tem permissão de acesso." });
            return;            

           //await _next(context);
        }
        /*
        private async Task<bool> UserHasAccess(string profile, string apiPath, string method)
        {
            using var scope = new ServiceCollection()
                .AddDbContext<SeuDbContext>()
                .BuildServiceProvider()
                .CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<SeuDbContext>();

            var hasAccess = await dbContext.Permissoes
                .Include(p => p.Api)
                .Include(p => p.Perfil)
                .AnyAsync(p => p.Perfil.Nome == profile
                               && p.Api.Rota == apiPath
                               && p.Api.MetodoHttp == method);

            return hasAccess;
        }
        */
    }

}