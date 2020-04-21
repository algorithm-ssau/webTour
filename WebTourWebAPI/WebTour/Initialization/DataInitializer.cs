using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using WebTour.DAL.Data;
using WebTour.DAL.Entities;

namespace WebTour.Initialization
{
    public partial class DataInitializer : ApplicationInitializerBase
    {
        public IConfiguration Configuration { get; }

        public DataInitializer(IServiceProvider serviceProvider, IConfiguration configuration)
            : base(serviceProvider)
        {
            Configuration = configuration;
        }

        protected override async Task InitializeAsync(DataContext context)
        {
            await InitCategories(context);
            await InitSights(context);
            await InitImages(context);
        }

        private async Task InitCategories(DataContext context)
        {
            var categoryNames = Enum
                .GetNames(typeof(Category.Types));

            var existingCategories = context
                .Categories
                .Select(x => x.Name)
                .ToArray();

            if (categoryNames.Length != existingCategories.Length)
            {
                var newCategories = categoryNames
                    .Where(category => existingCategories.All(x => x != category))
                    .Select(name => new Category(name)
                    {
                        Name = name
                    })
                    .ToList();

                await context.AddRangeAsync(newCategories);
                await context.SaveChangesAsync();
            }
        }

        // todo: foreach(categories)
        private async Task InitSights(DataContext context)
        {
            var existingSights = context
                .Sights
                .ToArray();

            if (_museumSights.Length != existingSights.Length)
            {
                var newSights = _museumSights
                    .Where(sight => existingSights.All(x => x != sight))
                    .ToList();

                await context.AddRangeAsync(newSights);
                await context.SaveChangesAsync();
            }
        }

        private async Task InitImages(DataContext context)
        {
            var existingImages = context
                .Images
                .ToArray();

            if (_images.Length != existingImages.Length)
            {
                var newImages = _images
                    .Where(image => existingImages.All(x => x != image))
                    .ToList();

                await context.AddRangeAsync(newImages);
                await context.SaveChangesAsync();
            }
        }

    }

    public partial class DataInitializer
    {
        private const string _apiBaseImageURLstring = "https://localhost:44356/images/";

        public Sight[] _museumSights = new Sight[]
        {
            new Sight(1, "Эрмитаж", "музей изобразительного и декоративно-прикладного искусства, " +
                "расположенный в городе Санкт-Петербург. Второй по величине художественный музей в мире[1][2]. " +
                "Главный музейный комплекс включает в себя шесть связанных между собой зданий — Зимний дворец, " +
                "Запасной дом Зимнего дворца, Малый Эрмитаж, Большой (Старый) Эрмитаж, Новый Эрмитаж и Эрмитажный театр. " +
                "В них открыты для посещения 365 залов. Также в распоряжении музея находятся Главный штаб, " +
                "Музей Императорского фарфорового завода, реставрационно-хранительский центр «Старая Деревня» " +
                "и Меншиковский дворец.", Convert.ToDateTime("07.12.1764"), "Россия, Санкт-Петербург, Дворцовая набережная, дом 34",
                _apiBaseImageURLstring + "museums/3.jpg")
        };

        public Image[] _images = new Image[]
        {
            new Image(1, _apiBaseImageURLstring + "museums/3.jpg"),
        };
    }
}
