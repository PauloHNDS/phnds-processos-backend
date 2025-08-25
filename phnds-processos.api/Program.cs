using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using phnds_processos.api.Auth;
using phnds_processos.data.ef.DbContext;
using phnds_processos.data.ef.Repositories;
using phnds_processos.data.ef.Services;
using phnds_processos.domain.Advogado;
using phnds_processos.domain.Andamento;
using phnds_processos.domain.Base;
using phnds_processos.domain.Mapper;
using phnds_processos.domain.Parte;
using phnds_processos.domain.Processo;
using phnds_processos.domain.Usuario;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<BaseMapper>());
builder.Services.AddAutoMapper(builder =>
{
    builder.AddProfile<AdvogadoMapper>();
    builder.AddProfile<AndamentoMapper>();
    builder.AddProfile<ParteMapper>();
    builder.AddProfile<ProcessoMapper>();
    builder.AddProfile<UsuarioMapper>();
});

builder.Services.AddScoped<IAdvogadoRepository, AdvogadoRepository>();
builder.Services.AddScoped<IAdvogadoService, AdvogadoService>();

builder.Services.AddScoped<IAndamentoRepository, AndamentoRepository>();
builder.Services.AddScoped<IAndamentoService, AndamentoService>();

builder.Services.AddScoped<IParteRepository, ParteRepository>();
builder.Services.AddScoped<IParteService, ParteService>();

builder.Services.AddScoped<IProcessoRepository,ProcessoRepository>();
builder.Services.AddScoped<IProcessoService, ProcessoService>();

builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("phnds-processos.data.ef") 
    )
);

var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

if (jwtSettings == null)
{
    throw new InvalidOperationException("JWT settings are not configured properly.");
}

builder.Services.AddSingleton(jwtSettings);
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularDevPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyMethod()                    
              .AllowAnyHeader()                    
              .AllowCredentials();                 
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usa CORS antes do MapControllers
app.UseCors("AngularDevPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
