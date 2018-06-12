using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using StudBaza.Application.Interfaces;
using StudBaza.Application.Services;
using StudBaza.Core.Interfaces.Repositories;
using StudBaza.Data.Repositories;

namespace StudBaza.Application
{
    public static class StartupExtensions
    {
        public static void AddApplication(this ContainerBuilder builder)
        {
            //builder.RegisterAssemblyModules(typeof(ServiceModule).Assembly);

            builder.RegisterType<PostService>().As<IPostService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CommentService>().As<ICommentService>();

            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            //builder.RegisterType<TravisDataProvider>().As<ICiDataProvider>();
            //builder.RegisterType<CiDataProviderFactory>().As<ICiDataProviderFactory>();
        }

        public static void AddAppHangfire(this IServiceCollection services)
        {
            //Hangfire
            var inMemory = GlobalConfiguration.Configuration.UseMemoryStorage(new MemoryStorageOptions()
            {
                JobExpirationCheckInterval = TimeSpan.FromMinutes(15)
            });
            services.AddHangfire(c =>
            {
                c.UseStorage(inMemory);
            });
        }
    }
}
