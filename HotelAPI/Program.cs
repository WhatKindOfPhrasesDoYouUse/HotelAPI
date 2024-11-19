using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Регистрация ApplicationDbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Замените на вашу строку подключения

        // Регистрация сервисов
        builder.Services.AddScoped<ICardService, CardService>();
        builder.Services.AddScoped<IUserAccountService, UserAccountService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IUserRoleService, UserRoleService>();
        builder.Services.AddScoped<IHotelTypeService, HotelTypeService>();
        builder.Services.AddScoped<IHotelService, HotelService>();
        builder.Services.AddScoped<IRoomService, RoomService>();
        builder.Services.AddScoped<IBookingService, BookingService>();
        builder.Services.AddScoped<IPaymentRoomService, PaymentRoomService>();
        builder.Services.AddScoped<IHotelReviewService, HotelReviewService>();
        builder.Services.AddScoped<IServiceHandler, ServiceHandler>();
        //builder.Services.AddScoped<IRequestService, RequestHandlerService>();

        // Другие сервисы
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
