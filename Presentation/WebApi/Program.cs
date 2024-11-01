
using Application.Interfaces;
using Application.Interfaces.BloodStockInterface;
using Application.Interfaces.DonationInterface;
using Application.Interfaces.RequestInterface;
using Application.Interfaces.UserInterface;
using Application.Servicess;
using AutoMapper;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.BloodStockRepository;
using Persistence.Repositories.DonationRepository;
using Persistence.Repositories.RequestRepository;
using Persistence.Repositories.UserRepository;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<KanBankasýContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IBloodStockRepository), typeof(BloodStockRepository));
            builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            builder.Services.AddScoped(typeof(IDonationRepsitory), typeof(DonationRepository));
            builder.Services.AddScoped(typeof(IRequestRepository), typeof(RequestRepository));

            builder.Services.AddSaveApplicationService(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.MapperProfiles.MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
