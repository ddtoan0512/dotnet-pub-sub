using BaseEvent;
using BaseEvent.Event;
using BaseEvent.EventHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//declare event



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
services.AddScoped<SampleEventHandler>();

EventHandlerEngine.Subscribe<SampleEvent, SampleEventHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
