using Chines_auction_project.BLL;
using Chines_auction_project.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//ConectionSring="Data Source=srv1\pupils;Initial Catalog=Order2024;Integrated Security=True;Trust Server Certificate=True;"
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//home
//DESKTOP - 6IB58BT
//builder.Services.AddDbContext<AuctionContex>(c => c.UseSqlServer("Data Source=DESKTOP-6IB58BT;Initial Catalog=Chines auction_project_325461697;Integrated Security=True;Trust Server Certificate=True;"));//home:)
//school
builder.Services.AddDbContext<AuctionContex>(c => c.UseSqlServer("Data Source=srv2\\pupils;Initial Catalog=Chines auction_project_325461697;Integrated Security=True;Trust Server Certificate=True;"));//school
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonorDal, DonorDal>();
builder.Services.AddScoped<IPresentDal, PresentDal>();
builder.Services.AddScoped<IPresentService, PresentService>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPurchaseDal, PurchaseDal>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000")); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
