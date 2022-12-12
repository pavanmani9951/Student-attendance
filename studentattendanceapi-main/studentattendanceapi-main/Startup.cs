using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Data;
using StudentAttendanceSystem.Services.StudentServices;
using StudentAttendanceSystem.Services.AttendanceServices;
using StudentAttendanceSystem.Services.LeaveServices;
using StudentAttendanceSystem.Services.AdminServices;
using StudentAttendanceSystem.Services.AccountServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
namespace StudentAttendanceSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentAttendanceSystem", Version = "v1" });
            });
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ILeaveService, LeaveService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAccountService, AccountService>();
           // services.AddDbContext<StudentAttendanceSystemContext>(options =>
             //      options.UseSqlServer(Configuration.GetConnectionString("attendancecontext")));
            services.AddDbContext<StudentAttendanceSystemContext>(options =>
                   options.UseSqlServer(@"Data Source= (localdb)\ProjectModels; Initial Catalog = StudentAttendanceSystemContext; Integrated Security = True"));
            //services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });
            services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//,StudentAttendanceSystemContext dbContext)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentAttendanceSystem v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            //dbContext.Database.EnsureCreated();
            // app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
