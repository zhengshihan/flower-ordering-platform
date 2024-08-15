using FlowerWebsite.Common;
using FlowerWebsite.Service;
using FlowerWebsite.Service.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SqlSugar;
using System.Text;
using ZhaoxiFlower.Model;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// ������÷���
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


/*// ��ȡ�����ַ���
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ע�� SqlSugarClient
builder.Services.AddScoped<SqlSugarClient>(provider =>
    new SqlSugarClient(new ConnectionConfig()
    {
        ConnectionString = connectionString,
        DbType = DbType.SqlServer,
        IsAutoCloseConnection = true,
    }));*/



builder.Services.AddDbContext<EFDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));










builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
builder.Services.AddTransient<IFlowerService, FlowerService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICustomJwtService, CustomJWTService>();


#region jwtУ�� 
{
    //�ڶ��������Ӽ�Ȩ�߼�
    JWTTokenOptions tokenOptions = new JWTTokenOptions();
    builder.Configuration.Bind("JWTTokenOptions", tokenOptions);
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Scheme
     .AddJwtBearer(options =>  //���������õļ�Ȩ���߼�
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             //JWT��һЩĬ�ϵ����ԣ����Ǹ���Ȩʱ�Ϳ���ɸѡ��
             ValidateIssuer = true,//�Ƿ���֤Issuer
             ValidateAudience = true,//�Ƿ���֤Audience
             ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
             ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
             ValidAudience = tokenOptions.Audience,//
             ValidIssuer = tokenOptions.Issuer,//Issuer���������ǰ��ǩ��jwt������һ��
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))//�õ�SecurityKey 
         };
     });
}
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    
    app.UseSwaggerUI();
}
builder.Services.AddCors();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
#region ��Ȩ��Ȩ
app.UseAuthentication();
app.UseAuthorization();
#endregion

app.MapControllers();

app.Run();
