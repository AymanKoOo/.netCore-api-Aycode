using System;
using System.Text;
using AymanKoSolve.Hubs;
using AymanKoSolve.Models;
using AymanKoSolve.repo.Admin;
using AymanKoSolve.repo.Chat;
using AymanKoSolve.repo.email;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace AymanKoSolve
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
            services.AddTransient<IAdminRepo,AdminRepo>();
            services.AddTransient<IChatRepo, ChatRepo>();
            services.AddTransient<IEmail, email>();
          
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            
            //call identity add password options
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
                
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})

            //.AddCookie(options =>
            // {
            //     options.Cookie.HttpOnly = true;
            //     options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            //     options.LogoutPath = "/Account/Logout";
            //     options.SlidingExpiration = true;
            // });

            services.AddCors();

            services.AddSignalR();
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_SECRET"].ToString());
            //JWT///

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => { 

              x.RequireHttpsMetadata = false;
              x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            }).AddGoogle(x=>
            {
                IConfigurationSection googleAuthNSection =
               Configuration.GetSection("Authentication:Google");

                x.ClientId = "1086014411471-m3ve9rhi6ks07u3hs1ek6lcbcllc3apf.apps.googleusercontent.com";
                x.ClientSecret = "3WKZLaUdliVfe5AiwGcbLUYr";
            } );
        }

      
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

             app.UseRouting();
             app.UseHttpsRedirection();
             app.UseAuthentication();
             app.UseCookiePolicy();

            app.UseAuthorization();
             app.UseCors(x => x.WithOrigins(Configuration["ApplicationSettings:ClientUrl"].ToString()).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapHub<ChatHub>("/chatsocket");     // path will look like this https://localhost:44379/chatsocket 

                 endpoints.MapControllers();
             });
        }
    }
}
