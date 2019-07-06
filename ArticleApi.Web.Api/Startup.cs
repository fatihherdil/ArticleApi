using ArticleApi.Application.Repository;
using ArticleApi.Domain.Entities;
using ArticleApi.Infrastructure.Logging.Providers;
using ArticleApi.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO.Compression;

namespace ArticleApi.Web.Api
{
    public class Startup
    {
        private readonly string dbProvider;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            dbProvider = configuration["DatabaseProvider"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region ResponseCompression

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.Configure<BrotliCompressionProviderOptions>(o => o.Level = CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(o => o.Level = CompressionLevel.Optimal);

            #endregion

            switch (dbProvider)
            {
                case "MySql":
                    services.AddDbContext<ArticleApiDbContext>(options =>
                    {
                        options.UseMySql(Configuration.GetConnectionString("mySqlServer"));
                    });
                    break;
                case "SqlServer":
                    services.AddDbContext<ArticleApiDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("sqlServer"));
                    });
                    break;
                default:
                    throw new MissingMemberException("Unknown DB Provider.");
            }

            services.AddScoped<RepositoryBase<Article>>();
            services.AddScoped<RepositoryBase<Author>>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new FileLogProvider());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
