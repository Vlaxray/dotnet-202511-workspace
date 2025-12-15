using Microsoft.EntityFrameworkCore;
using new_project_final.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend",
        policy =>
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod());
});

// 🔹 QUESTA È LA CONNECTION STRING
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=/data/meals.db")
);



builder.Services.AddCors(o =>
{
    o.AddPolicy("frontend",
        p => p.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:3000"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


app.UseCors("frontend");

app.MapControllers();

// 🔹 binding per Docker
app.Urls.Add("http://0.0.0.0:8080");
app.UseCors("frontend");

app.Run();
