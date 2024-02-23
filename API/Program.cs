using Application.Interfaces;
using Application.Mapper;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Memory cache
builder.Services.AddMemoryCache();

// Register Services
builder.Services.AddScoped(typeof(IFetchDataService), typeof(FetchDataService));
builder.Services.AddScoped(typeof(IEventService), typeof(EventService));

//register AutoMapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfig());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

// aws
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

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
