using CurrencyService.Buisness.Service;
using CurrencyService.Buisness.Service.Implementations;
using CurrencyService.DataAccess;
using Microsoft.EntityFrameworkCore;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddDbContext<DataBase>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Data Source=Accounts.db")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("https://localhost:3000");
        });
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(myAllowSpecificOrigins);
app.UseHttpsRedirection();
app.MapControllers();

app.Run();