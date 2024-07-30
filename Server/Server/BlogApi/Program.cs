using BlogApi.Helper;
using BlogApi.Middlewares;
using BlogApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IDbcontext, JsonHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseGlobalExecptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();    //👈 Enable HSTS middleware
}

app.UseHttpsRedirection();
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
