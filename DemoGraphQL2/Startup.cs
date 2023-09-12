using DemoGraphQL2.Data;
using DemoGraphQL2.GraphQLDataAccess;
using DemoGraphQL2.Repository;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL2
{
    public class Startup
    {
        private readonly string AllowedOrigin = "allowedOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.  
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SampleAppDbContext")));

            services.AddGraphQLServer().AddQueryType<Query>();
            services.AddGraphQLServer().AddMutationType<Mutation>();
            services.AddGraphQLServer().AddSubscriptionType<Subscription>();
            services.AddGraphQLServer().AddInMemorySubscriptions();

            services.AddScoped<EmployeeRepository, EmployeeRepository>();
            services.AddScoped<DepartmentRepository, DepartmentRepository>();

            services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(AllowedOrigin);
            app.UseWebSockets();
            app.UseRouting().UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
