using EFC_Partial_Entity.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("SQLiteConnection");
builder.Services.AddDbContext<DataContextFull>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<DataContextPartial>(options => options.UseSqlite(connectionString));

var app = builder.Build();
app.MapGet("/db/full", (DataContextFull db) => "Hello World!");
app.MapGet("/db/partial", (DataContextPartial db) => "Hello World!");

app.Run();
