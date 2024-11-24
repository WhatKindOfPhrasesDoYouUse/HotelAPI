using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
        builder.Services.AddScoped<IServService, HotelAPI.Services.ServService>();
        builder.Services.AddScoped<IComfortService, ComfortService>();
        builder.Services.AddScoped<IRequestServService, RequestServService>();
        builder.Services.AddScoped<IRequestServReviewService, RequestServReviewService>();
        builder.Services.AddScoped<ITravelService, TravelService>();
        builder.Services.AddScoped<IPaymentTravelService, PaymentTravelService>();
        builder.Services.AddScoped<ITravelReviewService, TravelReviewService>();
        builder.Services.AddScoped<IRoomComfortService, RoomComfortService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
