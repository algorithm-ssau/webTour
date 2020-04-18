using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.AsyncInitialization;
using Microsoft.Extensions.DependencyInjection;
using WebTour.DAL.Data;

namespace WebTour.Initialization
{
    public abstract class ApplicationInitializerBase : IAsyncInitializer
    {
        private readonly IServiceProvider _serviceProvider;

        protected ApplicationInitializerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task InitializeAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<DataContext>())
                {
                    await InitializeAsync(context);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected abstract Task InitializeAsync(DataContext context);
    }
}
