//using WebAPI;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();





//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();






//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services); // calling ConfigureServices method

//startup.Configure(app, builder.Environment); // calling Configure method


using WebAPI;
 
using WebAPI.WebSocketGetway.ClientWebSocket;
using WebAPI.WebSocketGetway.Model;
using WebAPI.WebSocketGetway.Services;

public class Program
{
    public static void Main(string[] args)
    {
        
        // DummyClass d = new DummyClass();
        // d.s();

        
        
        WebSocketClient client = WebSocketClient.Instance;
        CreateHostBuilder(args).Build().Run();
        
 
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}