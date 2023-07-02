public static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            IApplicationBuilder applicationBuilder = app.UseDeveloperExceptionPage();
        }



    
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}