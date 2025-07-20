using Business.Abstaracts;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Concrete;
using Repositories.Contexts;

var builder = WebApplication.CreateBuilder(args);

// DbContext ve Connection String tanımlaması
builder.Services.AddDbContext<BaseDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        });
});

// Repository'lerin Dependency Injection kaydı
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBootcampRepository, BootcampRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IBlacklistRepository, BlacklistRepository>();

// API Controller'ları için gerekli servis
builder.Services.AddControllers();

// Swagger servisleri
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP istek pipeline'ı yapılandırması
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.UseAuthorization();

// Controller endpoint'lerinin aktifleştirilmesi
app.MapControllers();

app.Run();