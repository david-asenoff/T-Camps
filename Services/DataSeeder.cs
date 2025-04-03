using T_Camps.Data;
using T_Camps.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using T_Camps.ViewModels;

public class DataSeeder
{
    private readonly ApplicationDbContext _context;

    public DataSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedClientsAsync()
    {
        if (!_context.Clients.Any())
        {
            var faker = new Faker<ClientViewModel>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Description, f => f.Lorem.Sentence());

            var clients = faker.Generate(100);

            _context.Clients.AddRange(clients);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedCompaniesAsync()
    {
        if (!_context.Companies.Any())
        {
            var company = new Company
            {
                Name = "T-CAMPS",
                Moto = "Wake up!",
                WelcomeMessage = "Добре дошли в T-CAMPS – мястото, където мечтите на младите се превръщат в реалност!",
                About = "Ние сме неправителствена организация, която създава вдъхновяващи събития за младежи, за да им предоставим възможност да изразят себе си, развият своите таланти и създадат трайни приятелства. Вярваме, че всяко преживяване в T-CAMPS е не само забавно и полезно, но и трансформиращо, оставяйки незабравими спомени и вдъхновение за бъдещи успехи.",
                JoinInformation = @"
                    <h2>Член на сдружението:</h2>
                    <p>Членството в T-CAMPS е формален процес, който изисква:</p>
                    <ul>
                        <li>Подаване на писмено заявление до Управителния съвет</li>
                        <li>Одобрение от Управителния съвет</li>
                        <li>Възможно е да се изисква плащане на символичен членски внос</li>
                    </ul>
                    <h3>Права на членовете:</h3>
                    <ul>
                        <li>Да участват в управлението на сдружението (гласуване, избор на управителни органи)</li>
                        <li>Да бъдат информирани за дейността на организацията</li>
                        <li>Да ползват ресурсите на сдружението за постигане на неговите цели</li>
                        <li>Да предлагат инициативи и проекти</li>
                    </ul>
                    <h3>Задължения на членовете:</h3>
                    <ul>
                        <li>Да спазват устава и решенията на сдружението</li>
                        <li>Да съдействат за постигане на целите</li>
                        <li>Да плащат членски внос (ако има такъв)</li>
                        <li>Да участват активно в събрания и дейности</li>
                    </ul>
                    <p>Членовете имат дългосрочен ангажимент към организацията и могат да бъдат част от процеса на вземане на решения.</p>

                    <h2>Доброволец в сдружението:</h2>
                    <p>Доброволчеството е неформална форма на участие, която не изисква членство.</p>
                    <ul>
                        <li>Обикновено чрез попълване на форма за участие в конкретна инициатива или проект</li>
                        <li>Не се изисква дългосрочен ангажимент</li>
                    </ul>
                    <h3>Права на доброволците:</h3>
                    <ul>
                        <li>Да участват в събития и инициативи на организацията</li>
                        <li>Да получават сертификати и препоръки за доброволчески труд</li>
                        <li>Да допринасят с идеи и участие в конкретни дейности</li>
                    </ul>
                    <h3>Задължения на доброволците:</h3>
                    <ul>
                        <li>Да следват указанията на организаторите на събитията</li>
                        <li>Да спазват етичните норми и принципите на сдружението</li>
                        <li>Да съдействат за постигане на целите в рамките на конкретното събитие</li>
                    </ul>
                    <p>Доброволците нямат право на участие в управлението, но могат да решат в бъдеще да станат членове, ако искат по-силна връзка с организацията.</p>

                    <h2>Обобщение:</h2>
                    <table class='table'>
                        <thead>
                            <tr>
                                <th>Характеристика</th>
                                <th>Член</th>
                                <th>Доброволец</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Участие в управлението</td>
                                <td>Да</td>
                                <td>Не</td>
                            </tr>
                            <tr>
                                <td>Процес на приемане</td>
                                <td>Формален (заявление, одобрение)</td>
                                <td>Неформален (регистрация за събитие)</td>
                            </tr>
                            <tr>
                                <td>Финансов ангажимент</td>
                                <td>Възможен (членски внос)</td>
                                <td>Не се изисква</td>
                            </tr>
                            <tr>
                                <td>Продължителност</td>
                                <td>Дългосрочно</td>
                                <td>Краткосрочно (за конкретни събития)</td>
                            </tr>
                            <tr>
                                <td>Задължения</td>
                                <td>Да</td>
                                <td>Само по време на участие</td>
                            </tr>
                            <tr>
                                <td>Ползи</td>
                                <td>Достъп до ресурси, участие в решения</td>
                                <td>Участие в събития, сертификати</td>
                            </tr>
                        </tbody>
                    </table>

                    <p>Ако искаш да бъдеш по-ангажиран и да участваш в развитието на сдружението, членството е правилният избор. Ако предпочиташ да подпомагаш каузата само при определени инициативи, доброволчеството е по-подходящо за теб.</p>
                ",
                PhoneNumber = "089 5312 434",
                Email = "info@t-camps.org",
                Instagram = "https://www.instagram.com/t-camps",
                Facebook = "https://www.facebook.com/t-camps",
                X = "https://www.x.com/t-camps",
                LinkedIn = "https://www.linkedin.com/company/t-camps",
                YouTube = "https://www.youtube.com/t-camps",
                Missions = new List<Mission>
                {
                    new Mission { Description = "Да създадем среда, в която всеки млад човек да се чувства свободен и уверен да открива нови възможности." },
                    new Mission { Description = "Да насърчаваме доброволчеството и активното участие в обществения живот." },
                    new Mission { Description = "Да стимулираме личностното и социалното развитие чрез културни и спортни инициативи." }
                },
                Services = new List<Service>
                {
                    new Service { Description = "Организиране на иновативни събития и лагери за младежи" },
                    new Service { Description = "Възможности за участие в доброволчески проекти" },
                    new Service { Description = "Образователни семинари и уъркшопи" },
                    new Service { Description = "Платформа за нови приятелства и личностно развитие" }
                },
                Members = new List<Member>
                {
                    new Member { Name = "Тони Огнянов",
                        Role = "Председател на Управителния съвет",
                        Email = "tonkisa1379@gmail.com",
                    About = "Актоьор, фитнес гуру, предприемач, психолог, инфлуенсър",
                    Picture = "\\assets\\images\\team\\member_1.jpg"},
                    new Member { Name = "Кристиян Левтеров",
                        Role = "Член",
                        Email = "tonkisa1379@gmail.com",
                    About = "Икономист, маркетолог и програмист",
                    Picture = "\\assets\\images\\team\\member_2.jpg"},
                    new Member {
                        Name = "Матея Христов",
                        Role = "Член",
                        Email = "tonkisa1379@gmail.com",
                    About = "Дизайнер, финансист и диетолог",
                    Picture = "\\assets\\images\\team\\member_3.jpg"},

                },
                TermsAndConditions = new TermsAndConditions
                {
                    Content = "These are the terms and conditions for T-CAMPS."
                }
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedMissionsAsync()
    {
        if (!_context.Missions.Any())
        {
            var missions = new List<Mission>
            {
                new Mission { Description = "Да създадем среда, в която всеки млад човек да се чувства свободен и уверен да открива нови възможности.", CompanyId = 1 },
                new Mission { Description = "Да насърчаваме доброволчеството и активното участие в обществения живот.", CompanyId = 1 },
                new Mission { Description = "Да стимулираме личностното и социалното развитие чрез културни и спортни инициативи.", CompanyId = 1 }
            };

            _context.Missions.AddRange(missions);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedServicesAsync()
    {
        if (!_context.Services.Any())
        {
            var services = new List<Service>
            {
                new Service { Description = "Организиране на иновативни събития и лагери за младежи", CompanyId = 1 },
                new Service { Description = "Възможности за участие в доброволчески проекти", CompanyId = 1 },
                new Service { Description = "Образователни семинари и уъркшопи", CompanyId = 1 },
                new Service { Description = "Платформа за нови приятелства и личностно развитие", CompanyId = 1 }
            };

            _context.Services.AddRange(services);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedMembersAsync()
    {
        if (!_context.Members.Any())
        {
            var members = new List<Member>
            {
                new Member { Name = "John Doe", Role = "Founder", CompanyId = 1 },
                new Member { Name = "Jane Smith", Role = "Coordinator", CompanyId = 1 }
            };

            _context.Members.AddRange(members);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedTermsAndConditionsAsync()
    {
        if (!_context.TermsAndConditions.Any())
        {
            var termsAndConditions = new TermsAndConditions
            {
                Content = "These are the terms and conditions for T-CAMPS.",
                CompanyId = 1
            };

            _context.TermsAndConditions.Add(termsAndConditions);
            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedEventsAsync()
    {
        if (!_context.Events.Any())
        {

            var events = new List<Event>
            {
                new Event
                {
                    Name = "Premium Camp 2025",
                    Location = "Utopia Forest Hotel, Bulgaria",
                    StartDate = new DateTime(2025, 10, 1),
                    EndDate = new DateTime(2025, 10, 8),
                    Price = 0.00m,
                    CompanyId = _context.Companies.FirstOrDefault().Id,
                    DescriptionShort = "🔥 Театър | 🎶 Музика | 💃 Танци | 🏐 Спорт | 🎓 Лекции",
                    DescriptionFull = "Premium Camp е мястото, където младите хора се събират за незабравимо преживяване. Импровизационен театър, музика, танци, спортни игри, лекции и вечерни събития като DJ партита и лагерен огън – всичко това в рамките на 7 дни в красивата природа на Utopia Forest.",
                    MainImageUrl = "/images/events/premium-camp-2025/main.jpg",
                    LocationMapEmbedUrl = "https://www.google.de/maps/place/Hotel+Utopia+Forest/@42.4442987,27.5565219,3a,75y,90t/data=!3m8!1e2!3m6!1shttps:%2F%2Fimages.trvl-media.com%2Flodging%2F45000000%2F44230000%2F44227000%2F44226902%2Fbe736221_z.jpg!2e7!3e27!6shttps:%2F%2Flh3.googleusercontent.com%2Fgps-proxy%2FALd4DhHs_HqoXxBsLvynwJxTif3xnwR_vNNHU_MNkcf2M1zCA1__DL8wN2CWmxy9bUiU3rkn18AgI8fYHheU6z8WQvCD9skuuVsVnN3IMUHj2pZvp5hILPItd61hN65ZFp1hk-O_9klWJJ82nitPlo-3Ox97KLcrhUo3uNLIX0rHLoSpsLk0mFwqTvFnyA%3Dw129-h86-k-no!7i1000!8i666!4m10!3m9!1s0x40a6c1cf8eb2d3d3:0x7f57c4568c3a8f30!5m2!4m1!1i2!8m2!3d42.4443119!4d27.5557038!10e5!16s%2Fg%2F11h8l5sv0g?entry=ttu&g_ep=EgoyMDI1MDQwMS4wIKXMDSoASAFQAw%3D%3D",
                    GalleryImageUrls = new List<string>
                    {
                        "/images/events/premium-camp-2025/gallery1.jpg",
                        "/images/events/premium-camp-2025/gallery2.jpg",
                        "/images/events/premium-camp-2025/gallery3.jpg",
                        "/images/events/premium-camp-2025/gallery4.jpg"
                    },
                    Schedules = new List<Schedule>
                    {
                        new Schedule { Description = "Пристигане и настаняване", Time = new DateTime(2025, 10, 1, 16, 0, 0) },
                        new Schedule { Description = "Откриващ концерт", Time = new DateTime(2025, 10, 1, 20, 30, 0) },
                        new Schedule { Description = "DJ парти", Time = new DateTime(2025, 10, 2, 21, 0, 0) },
                        new Schedule { Description = "Спортна игра на плажа", Time = new DateTime(2025, 10, 3, 9, 15, 0) },
                        new Schedule { Description = "Лекция / Семинар 1", Time = new DateTime(2025, 10, 2, 14, 15, 0) },
                        new Schedule { Description = "Лекция / Семинар 2", Time = new DateTime(2025, 10, 3, 14, 15, 0) },
                        new Schedule { Description = "Кино вечер на открито", Time = new DateTime(2025, 10, 4, 21, 0, 0) },
                        new Schedule { Description = "Куиз и Лагерен огън", Time = new DateTime(2025, 10, 5, 21, 0, 0) },
                        new Schedule { Description = "Караоке вечер и хоротека", Time = new DateTime(2025, 10, 6, 20, 0, 0) },
                        new Schedule { Description = "Награждаване на мис и мистър лагер", Time = new DateTime(2025, 10, 7, 21, 0, 0) },
                        new Schedule { Description = "Закриващ концерт", Time = new DateTime(2025, 10, 7, 21, 30, 0) },
                        new Schedule { Description = "Изпращане", Time = new DateTime(2025, 10, 8, 9, 15, 0) }
                    },
                    Speakers = new List<Speaker>
                    {
                        new Speaker { Name = "Иван Петров", Bio = "Лектор по личностно развитие и мотивация." },
                        new Speaker { Name = "Мария Георгиева", Bio = "Професионален музикален педагог и коуч по сценично поведение." }
                    }
                },
                new Event
                {
                    Name = "VIP Camp 2025",
                    Location = "bul. Knyaz Boris I 111, 9002 Varna",
                    StartDate = new DateTime(2025, 11, 5),
                    EndDate = new DateTime(2025, 11, 7),
                    Price = 2.00m,
                    CompanyId = _context.Companies.FirstOrDefault().Id,
                    DescriptionShort = "🔥 Театър | 🎶 Музика | 💃 Танци | 🏐 Спорт | 🎓 Лекции",
                    DescriptionFull = "VIP Camp е мястото, където младите хора се събират за незабравимо преживяване. Импровизационен театър, музика, танци, спортни игри, лекции и вечерни събития като DJ партита и лагерен огън – всичко това в рамките на 3 дни в красивата природа на Varna.",
                    MainImageUrl = "/images/events/vip-camp-2025/main.jpg",
                    LocationMapEmbedUrl = "https://www.google.bg/maps/place/Rosslyn+Dimyat+Hotel+Varna/@43.2098649,27.9262516,17z/data=!3m2!4b1!5s0x40a4540f75a98a9b:0x8a6cba320022fcdc!4m9!3m8!1s0x40a4540f0aa073a5:0xbdf6c46bb9b60967!5m2!4m1!1i2!8m2!3d43.2098649!4d27.9288265!16s%2Fg%2F11cm_hsrn4?entry=ttu&g_ep=EgoyMDI1MDMzMS4wIKXMDSoASAFQAw%3D%3D",
                    GalleryImageUrls = new List<string>
                    {
                        "/images/events/vip-camp-2025/gallery1.jpg",
                        "/images/events/vip-camp-2025/gallery2.jpg",
                        "/images/events/vip-camp-2025/gallery3.jpg",
                        "/images/events/vip-camp-2025/gallery4.jpg"
                    },
                    Schedules = new List<Schedule>
                    {
                        new Schedule { Description = "Пристигане и настаняване", Time = new DateTime(2025, 11, 5, 16, 0, 0) },
                        new Schedule { Description = "Откриващ концерт", Time = new DateTime(2025, 11, 5, 20, 30, 0) },
                        new Schedule { Description = "DJ парти", Time = new DateTime(2025, 11, 6, 21, 0, 0) },
                        new Schedule { Description = "Спортна игра на плажа", Time = new DateTime(2025, 11, 6, 9, 15, 0) },
                        new Schedule { Description = "Лекция / Семинар 1", Time = new DateTime(2025, 11, 6, 14, 15, 0) },
                        new Schedule { Description = "Кино вечер на открито", Time = new DateTime(2025, 11, 6, 21, 0, 0) },
                        new Schedule { Description = "Закриващ концерт", Time = new DateTime(2025, 11, 7, 21, 30, 0) },
                        new Schedule { Description = "Изпращане", Time = new DateTime(2025, 11, 7, 9, 15, 0) }
                    },
                    Speakers = new List<Speaker>
                    {
                        new Speaker { Name = "Иван Петров", Bio = "Лектор по личностно развитие и мотивация." },
                        new Speaker { Name = "Мария Георгиева", Bio = "Професионален музикален педагог и коуч по сценично поведение." }
                    }
                }
            };

            _context.Events.AddRange(events);
            await _context.SaveChangesAsync();
        }
    }
}
