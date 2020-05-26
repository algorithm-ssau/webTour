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

        private async Task InitSights(DataContext context)
        {
            var existingMuseums = context
                .Sights
                .Where(s => s.Category.Name == Category.Types.Музей.ToString())
                .ToArray();

            var existingChurches = context
                .Sights
                .Where(s => s.Category.Name == Category.Types.Храм.ToString())
                .ToArray();

            var existingTheatres = context
                .Sights
                .Where(s => s.Category.Name == Category.Types.Театр.ToString())
                .ToArray();

            if (_museumSights.Length != existingMuseums.Length)
            {
                var newSights = _museumSights
                    .Where(sight => existingMuseums.All(x => x != sight))
                    .ToList();

                await context.AddRangeAsync(newSights);
                await context.SaveChangesAsync();
            }

            if (_churchSights.Length != existingChurches.Length)
            {
                var newSights = _churchSights
                    .Where(sight => existingChurches.All(x => x != sight))
                    .ToList();

                await context.AddRangeAsync(newSights);
                await context.SaveChangesAsync();
            }

            if (_theatreSights.Length != existingTheatres.Length)
            {
                var newSights = _theatreSights
                    .Where(sight => existingTheatres.All(x => x != sight))
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

        public static Sight[] _museumSights = new Sight[]
        {
            new Sight(1,
                "Эрмитаж",
                "музей изобразительного и декоративно-прикладного искусства, " +
                "расположенный в городе Санкт-Петербург. Второй по величине художественный музей в мире. " +
                "Главный музейный комплекс включает в себя шесть связанных между собой зданий — Зимний дворец, " +
                "Запасной дом Зимнего дворца, Малый Эрмитаж, Большой (Старый) Эрмитаж, Новый Эрмитаж и Эрмитажный театр. " +
                "В них открыты для посещения 365 залов. Также в распоряжении музея находятся Главный штаб, " +
                "Музей Императорского фарфорового завода, реставрационно-хранительский центр «Старая Деревня» " +
                "и Меншиковский дворец.",
                Convert.ToDateTime("07.12.1764"),
                "Россия, Санкт-Петербург, Дворцовая набережная, дом 34",
                _apiBaseImageURLstring + "museums/3.jpg"),

            new Sight(1,
                "Русский музей",
                "Государственный Русский музе́й (по 1917 год «Русский Музе́й Импера́тора Александра III») — крупнейшее собрание " +
                "российского искусства в мире. Находится в центральной части Санкт-Петербурга. Современный Русский музей " +
                "представляет собой сложный музейный комплекс. Основная экспозиционная часть музея занимает пять зданий: Михайловский " +
                "дворец (главное здание музея) с выставочным корпусом Бенуа, Михайловский (Инженерный) замок, Мраморный дворец, " +
                "Строгановский дворец и Летний дворец Петра I. В состав музея входят также Михайловский сад, Летний сад, сад Михайловского " +
                "(Инженерного) замка и Домик Петра I на Петровской набережной и ряд других зданий. Директор музея — Владимир Александрович " +
                "Гусев. На 1 января 2015 года собрание Русского музея составило 410 945 единиц хранения. В это число входят произведения " +
                "живописи, графики, скульптуры, нумизматики, декоративно-прикладного и народного искусства, а также архивные материалы.",
                Convert.ToDateTime("19.03.1898"),
                "Россия, Санкт-Петербург, Инженерная ул., 4",
                _apiBaseImageURLstring + "museums/r1"
                )
        };

        public static Sight[] _churchSights = new Sight[]
        {
            new Sight
            (
                2,
                "Собор Василия Блаженного",
                "Собо́р Покрова́ Пресвято́й Богоро́дицы, что на Рву (Покро́вский собо́р, Покрова́ на Рву, " +
                "разговорное — собо́р (храм) Васи́лия Блаже́нного) — православный храм на Красной площади в " +
                "Москве, памятник русской архитектуры. Строительство собора велось с 1555 по 1561 год. " +
                "Собор объединяет одиннадцать церквей (приделов), часть из которых освящена в честь святых, " +
                "дни памяти которых пришлись на решающие бои за Казань. Центральная церковь сооружена в честь " +
                "Покрова Богородицы, вокруг которой группируются отдельные церкви в честь: Святой Троицы, Входа " +
                "Господня в Иерусалим, Николы Великорецкого, Трёх Патриархов: Александра, Иоанна и Павла Нового, " +
                "Григория Армянского, Киприана и Иустины, Александра Свирского и Варлаама Хутынского, размещённые " +
                "на одном основании-подклете, а также придел в честь Василия Блаженного, по имени которого храм " +
                "получил второе, более известное название, и церковь Иоанна Блаженного, вновь открытая после " +
                "длительного запустения в ноябре 2018 года",
                Convert.ToDateTime("12.07.1561"),
                "109012, г. Москва, Красная пл., д. 2",
                _apiBaseImageURLstring + "churches/v1"
            ),
            new Sight
            (
                2,
                "Собор Парижской Богоматери",
                "Собо́р Пари́жской Богома́тери, также парижский собор Нотр-Да́м или Нотр-Да́м-де-Пари́ (фр. Notre-Dame de Paris) " +
                "— католический храм в центре Парижа, один из символов французской столицы. Кафедральный собор архиепархии " +
                "Парижа. Расположен в восточной части острова Сите, в 4-м городском округе, на месте первой христианской " +
                "церкви Парижа — базилики Святого Стефана, построенной, в свою очередь, на фундаменте галло-римского храма " +
                "Юпитера. Готический собор возводился по инициативе парижского епископа Мориса де Сюлли в период 1163—1345 " +
                "годов. Алтарная часть освящена в 1182 году; западный фасад и башни закончены во второй четверти XIII века. " +
                "С 1235 года вносились большие изменения: обустроены часовни между контрфорсами нефа; увеличен размер " +
                "трансепта (архитекторы Жан де Шель с 1250 и Пьер де Монтрёй вплоть до 1267); добавлены часовни хора и " +
                "большие аркбутаны деамбулатория. В XIX веке под руководством Виолле-ле-Дюка отреставрирована повреждённая " +
                "в Революцию скульптурная часть, восстановлены витражные розы нефа и возведён новый шпиль вместо утраченного.",
                Convert.ToDateTime("01.01.1160"),
                "6 Parvis Notre-Dame , Place Jean-Paul II, Париж, 75004, Франция",
                _apiBaseImageURLstring + "churches/p1"
            )
        };

        public static Sight[] _theatreSights = new Sight[]
        {
            new Sight
            (
                3,
                "Большой театр",
                "Госуда́рственный академи́ческий Большо́й теа́тр Росси́и, или просто Большой театр — один из крупнейших в " +
                "России и один из самых значительных в мире театров оперы и балета. Комплекс зданий театра расположен " +
                "в центре Москвы, на Театральной площади. Большой театр, его музей, здание исторической сцены — объект " +
                "культурного наследия народов России федерального значения. Изначально театр был частным, но с 1794 " +
                "стал казённым, составляющим вместе с Малым единую московскую труппу императорских театров. Время от " +
                "времени статус московской труппы менялся: она то переходила в подчинение московскому генерал-губернатору, " +
                "то вновь — под петербургскую дирекцию. Так продолжалось до революции 1917 года, когда все имущество было " +
                "национализировано и произошло полное разделение Малого и Большого театров.",
                Convert.ToDateTime("18.01.1825"),
                "Россия, Москва, Театральная пл., д. 1",
                _apiBaseImageURLstring + "theatres/b1"
            ),
            new Sight
            (
                3,
                "Мариинский театр",
                "Государственный академический Мариинский театр (в 1935—1992 годах — Ленинградский ордена Ленина и ордена Октябрьской " +
                "Революции академический театр оперы и балета имени С. М. Кирова, часто сокращённо — Кировский театр) — театр оперы и " +
                "балета в Санкт-Петербурге, один из ведущих музыкальных театров России и мира. Труппа, основанная ещё в XVIII веке, до " +
                "революции функционировала под руководством дирекции Императорских театров. В 1784—1886 годах для балетных и оперных " +
                "спектаклей использовалось преимущественно здание Большого театра (в 1896 году перестроено архитектором В. В. Николя " +
                "для размещения Санкт-Петербургской консерватории), в 1859—1860 году там же, на Театральной площади, архитектором А. К. " +
                "Кавосом было выстроено нынешнее здание театра, названное в честь императрицы Марии Александровны.",
                Convert.ToDateTime("02.10.1860"),
                "Россия, Санкт-Петербург, пл. Театральная, д. 1",
                _apiBaseImageURLstring + "theatres/m1"
            )
        };

        public Image[] _images = new Image[]
        {
            new Image
            {
                Sight = _museumSights.Where(m => m.Name == "Эрмитаж").FirstOrDefault(),
                Path = _apiBaseImageURLstring + "museums/e1.jpg",
            },
            
            new Image
            {
                Sight = _museumSights.Where(m => m.Name == "Русский музей").FirstOrDefault(),
                Path = _apiBaseImageURLstring + "museums/r1.jpg",
            },

            new Image
            {
                Sight = _churchSights.Where(m => m.Name == "Собор Василия Блаженного").FirstOrDefault(),
                Path = _apiBaseImageURLstring + "churches/v1.jpg",
            }
        };
    }
}
