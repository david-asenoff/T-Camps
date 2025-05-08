using T_Camps.Data;
using Bogus;
using T_Camps.ViewModels;
using static T_Camps.Data.Company;

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
            var faker = new Faker<Client>()
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
                Moto = "Wake up...",
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
                SocialMediaLinks = new List<SocialMediaLink>
    {
        new SocialMediaLink { Platform = "Instagram", Url = "https://www.instagram.com/t.camps.bulgaria" },
        new SocialMediaLink { Platform = "Facebook", Url = "https://www.facebook.com/t.camps.bulgaria" },
        new SocialMediaLink { Platform = "X", Url = null },
        new SocialMediaLink { Platform = "LinkedIn", Url = null },
        new SocialMediaLink { Platform = "YouTube", Url = null },
        new SocialMediaLink { Platform = "TikTok", Url = "https://www.tiktok.com/@t.camps.bulgaria" },
        new SocialMediaLink { Platform = "Threads", Url = "https://www.threads.net/@t.camps.bulgaria" }
    },
                PhoneNumber = "+359892040937",
                Email="contact@t-camps.org",
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
                TermsAndConditions = new List<TermsAndConditions>
                    {
                        new TermsAndConditions
                        {
                            SectionTitle = "Политика за опазване на личните данни",
                            Content = @"Като се регистрирате в T-Camps или попълните формата ни за контакт, вие се съгласявате да приемете практиките описани в тази Политика за опазване на личните данни и да ни предоставите действителна и вярна информация, доколкото тя се касае за вас.
                        T-Camps знае, че вие сте загрижени за това как информацията за вас се използва и споделя, и ние оценяваме вашето доверие, че ние ще правим това внимателно и разумно.
                        T-Camps се ангажира да спазва и уважава вашите желания относно информацията, която събираме за вас на нашия уеб сайт."
                        },
                        new TermsAndConditions
                        {
                            SectionTitle = "Лична информация",
                            Content = @"Информацията, която научаваме от вас, ни помага да персонализираме и непрекъснато да подобряваме начина, по който използвате T-Camps.
                        Историята на вашите транзакции и информацията, която ни предоставяте онлайн на T-Camps, по телефон или по електронна поща надеждно се съхраняват в нашата клиентска база данни и не се предоставят на трети страни.
                        T-Camps, както и други трети страни, обслужващи поръчката ви, може да ви предоставят информация, свързана с регистрацията и плащането по поръчката ви, в това число рекламни, информационни и други съобщения, на посочения от вас имейл адрес и/или телефонен номер."
                        },
                        new TermsAndConditions
                        {
                            SectionTitle = "Политика за електронната поща",
                            Content = @"Освен изключенията отбелязани в тази политика, T-Camps никога няма да продава, споделя или по какъвто и да било друг начин да разпространява вашия e-mail адрес, който сте ни изпратили, или който по друг начин е получен чрез вашето използване на сайта. Всеки e-mail адрес изпратен директно на T-Camps ще остане единствено притежание на T-Camps и свързаните с нея компании.
                        Ако не желаете да получавате промоционни имейли от T-Camps в бъдеще, моля известете ни чрез формата за контакт."
                        },
                        new TermsAndConditions
                        {
                            SectionTitle = "Бисквитки",
                            Content = @"Както повечето уеб сайтове, ние използваме ""бисквитки"" (""cookies""), които представляват парчета данни изпращани към вашия браузър, които позволяват на нашия уеб сайт да ви идентифицира, когато осъществявате достъп до него. Макар да се изразява известна загриженост за възможни усложнения по отношение на личната информация чрез ""бисквитки"", за вас е важно да разберете, че ""бисквитки"" не могат да извличат никаква информация за вас, която вие не сте вече разкрили доброволно.
                        Ако имате някакви въпроси относно който и да е от елементите на нашата уеб политика за опазване на личните данни, моля пишете ни чрез формата за контакт."
                        }

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
                        Name = "Premium Camp 2025 - II",
                        Location = "Utopia Forest Hotel, Bulgaria",
                        StartDate = new DateTime(2025, 10, 1),
                        EndDate = new DateTime(2025, 10, 8),
                        Price = 0.00m,
                        CompanyId = 1,
                        DescriptionFull = "Premium Camp е мястото, където младите хора се събират за незабравимо преживяване. Импровизационен театър, музика, танци, спортни игри, лекции и вечерни събития като DJ партита и лагерен огън – всичко това в рамките на 7 дни в красивата природа на Utopia Forest.",
                        DescriptionShort = "🔥 Театър | 🎶 Музика | 💃 Танци | 🏐 Спорт | 🎓 Лекции",
                        GalleryImageUrls = new List<string>
                        {
                            "/images/events/premium-camp-2025/gallery1.jpg",
                            "/images/events/premium-camp-2025/gallery2.jpg",
                            "/images/events/premium-camp-2025/gallery3.jpg",
                            "/images/events/premium-camp-2025/gallery4.jpg"
                        },
                        LocationMapEmbedUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2944.2208999138347!2d27.55312351308918!3d42.44431582965224!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a6c1cf8eb2d3d3%3A0x7f57c4568c3a8f30!2sHotel%20Utopia%20Forest!5e0!3m2!1sbg!2sbg!4v1745163006665!5m2!1sbg!2sbg",
                        MainImageUrl = "/images/events/premium-camp-2025/main.jpg",
                        Schedules = new List<Schedule>
                        {
                                new Schedule { Description = "Пристигане и настаняване", Time = new DateTime(2025, 10, 1, 16, 0, 0) },
                                new Schedule { Description = "Вечеря", Time = new DateTime(2025, 10, 1, 18, 45, 0) },
                                new Schedule { Description = "Откриващ концерт", Time = new DateTime(2025, 10, 1, 20, 30, 0) },

                                new Schedule { Description = "Закуска", Time = new DateTime(2025, 10, 2, 7, 0, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 2, 9, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 2, 10, 40, 0) },
                                new Schedule { Description = "Обяд", Time = new DateTime(2025, 10, 2, 12, 30, 0) },
                                new Schedule { Description = "Лекция / Семинар 1", Time = new DateTime(2025, 10, 2, 14, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 2, 15, 40, 0) },
                                new Schedule { Description = "Вечеря", Time = new DateTime(2025, 10, 2, 18, 45, 0) },
                                new Schedule { Description = "DJ парти", Time = new DateTime(2025, 10, 2, 21, 0, 0) },

                                new Schedule { Description = "Закуска", Time = new DateTime(2025, 10, 3, 7, 0, 0) },
                                new Schedule { Description = "Спортна игра на плажа", Time = new DateTime(2025, 10, 3, 9, 15, 0) },
                                new Schedule { Description = "Обяд", Time = new DateTime(2025, 10, 3, 12, 30, 0) },
                                new Schedule { Description = "Лекция / Семинар 2", Time = new DateTime(2025, 10, 3, 14, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 3, 15, 40, 0) },
                                new Schedule { Description = "Вечеря", Time = new DateTime(2025, 10, 3, 18, 45, 0) },
                                new Schedule { Description = "Вечер на настолните игри и Лагерен огън", Time = new DateTime(2025, 10, 3, 21, 0, 0) },

                                new Schedule { Description = "Закуска", Time = new DateTime(2025, 10, 4, 7, 0, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 4, 9, 15, 0) },
                                new Schedule { Description = "Обяд", Time = new DateTime(2025, 10, 4, 12, 30, 0) },
                                new Schedule { Description = "Лекция / Семинар 3", Time = new DateTime(2025, 10, 4, 14, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 4, 15, 40, 0) },
                                new Schedule { Description = "Вечеря", Time = new DateTime(2025, 10, 4, 18, 45, 0) },
                                new Schedule { Description = "Кино вечер на открито и Лагерен огън", Time = new DateTime(2025, 10, 4, 21, 0, 0) },

                                new Schedule { Description = "Закуска", Time = new DateTime(2025, 10, 5, 7, 0, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 5, 9, 15, 0) },
                                new Schedule { Description = "Обяд", Time = new DateTime(2025, 10, 5, 12, 30, 0) },
                                new Schedule { Description = "Лекция / Семинар 4", Time = new DateTime(2025, 10, 5, 14, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 5, 15, 40, 0) },
                                new Schedule { Description = "Вечеря", Time = new DateTime(2025, 10, 5, 18, 45, 0) },
                                new Schedule { Description = "Куиз и Лагерен огън", Time = new DateTime(2025, 10, 5, 21, 0, 0) },


                                    // 6-ти Октомври (Понеделник)
                                new Schedule { Description = "Закуска", Time = new DateTime(2025, 10, 6, 7, 0, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 6, 9, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 6, 10, 40, 0) },
                                new Schedule { Description = "Обяд", Time = new DateTime(2025, 10, 6, 12, 30, 0) },
                                new Schedule { Description = "Лекция / Семинар 5 – Кафе пауза 20мин", Time = new DateTime(2025, 10, 6, 14, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 6, 15, 40, 0) },
                                new Schedule { Description = "Вечеря", Time = new DateTime(2025, 10, 6, 18, 0, 0) },
                                new Schedule { Description = "Караоке вечер и хоротека", Time = new DateTime(2025, 10, 6, 20, 0, 0) },
    
                                // 7-ми Октомври (Вторник)
                                new Schedule { Description = "Закуска", Time = new DateTime(2025, 10, 7, 7, 0, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 7, 9, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 7, 10, 40, 0) },
                                new Schedule { Description = "Обяд", Time = new DateTime(2025, 10, 7, 12, 30, 0) },
                                new Schedule { Description = "Лекция / Семинар 6 – Кафе пауза 20мин", Time = new DateTime(2025, 10, 7, 14, 15, 0) },
                                new Schedule { Description = "Дейност по избор с предварително записване", Time = new DateTime(2025, 10, 7, 15, 40, 0) },
                                new Schedule { Description = "Възможност за лични консултации с треньор", Time = new DateTime(2025, 10, 7, 17, 15, 0) },
                                new Schedule { Description = "Вечеря", Time = new DateTime(2025, 10, 7, 18, 45, 0) },
                                new Schedule { Description = "Награди за спортните постижения и награждаване на мис и мистър лагер", Time = new DateTime(2025, 10, 7, 21, 0, 0) },
                                new Schedule { Description = "Закриващ концерт", Time = new DateTime(2025, 10, 7, 21, 30, 0) },
    
                                // 8-ми Октомври (Сряда)
                                new Schedule { Description = "Закуска", Time = new DateTime(2025, 10, 8, 7, 0, 0) },
                                new Schedule { Description = "Изпращане", Time = new DateTime(2025, 10, 8, 9, 15, 0) }
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
