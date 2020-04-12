using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using WebTour.DAL.Data;
using WebTour.DAL.Entities;

namespace WebTour.Initialization
{
    public class DataInitializer : ApplicationInitializerBase
    {
        public IConfiguration Configuration { get; }

        public DataInitializer(IServiceProvider serviceProvider, IConfiguration configuration)
            : base(serviceProvider)
        {
            Configuration = configuration;
        }

        protected override async Task InitializeAsync(DataContext context)
        {
            var categoryNames = Enum
                .GetNames(typeof(Category.Types));

            var existingCategories = context
                .Categories
                .Select(x => x.Name)
                .ToArray();

            if (categoryNames.Length != existingCategories.Length)
            {
                var newRoles = categoryNames
                    .Where(category => existingCategories.All(x => x != category))
                    .Select(name => new Category(name)
                    {
                        Name = name
                    })
                    .ToList();

                await context.AddRangeAsync(newRoles);
            }
        }
    }
}
