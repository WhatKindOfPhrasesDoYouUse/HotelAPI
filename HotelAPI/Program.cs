using HotelAPI.Contracts;
using HotelAPI.Data;
using HotelAPI.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ����������� ApplicationDbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // �������� �� ���� ������ �����������

        // ����������� ������� CardService
        builder.Services.AddScoped<ICardService, CardService>();

        // ������ �������
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
