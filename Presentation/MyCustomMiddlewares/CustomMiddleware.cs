namespace Presentation.MyCustomMiddlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomMiddleware> logger;

        public CustomMiddleware(RequestDelegate Next , ILogger<CustomMiddleware> logger)
        {
            this.next = Next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
           
            // Pre-processing logic
            //await context.Response.WriteAsync("Before Middleware\n");

            // Call the next middleware in the pipeline
            
            logger.LogInformation("Before Middleware");
            await next(context);

            // Post-processing logic
            // await context.Response.WriteAsync("After Middleware\n");
        }
    }
}
