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
                Moto = "Wake up!",
                WelcomeMessage = "����� ����� � T-CAMPS � �������, ������ ������� �� ������� �� ��������� � ��������!",
                About = "��� ��� ���������������� �����������, ����� ������� ������������ ������� �� �������, �� �� �� ����������� ���������� �� ������� ���� ��, ������� ������ ������� � �������� ������ �����������. �������, �� ����� ����������� � T-CAMPS � �� ���� ������� � �������, �� � ��������������, ��������� ����������� ������� � ����������� �� ������ ������.",
                JoinInformation = @"
                    <h2>���� �� �����������:</h2>
                    <p>���������� � T-CAMPS � �������� ������, ����� �������:</p>
                    <ul>
                        <li>�������� �� ������� ��������� �� ������������ �����</li>
                        <li>��������� �� ������������ �����</li>
                        <li>�������� � �� �� ������� ������� �� ���������� ������� ����</li>
                    </ul>
                    <h3>����� �� ���������:</h3>
                    <ul>
                        <li>�� �������� � ������������ �� ����������� (���������, ����� �� ����������� ������)</li>
                        <li>�� ����� ����������� �� ��������� �� �������������</li>
                        <li>�� ������� ��������� �� ����������� �� ��������� �� �������� ����</li>
                        <li>�� ��������� ���������� � �������</li>
                    </ul>
                    <h3>���������� �� ���������:</h3>
                    <ul>
                        <li>�� ������� ������ � ��������� �� �����������</li>
                        <li>�� ���������� �� ��������� �� ������</li>
                        <li>�� ������ ������� ���� (��� ��� �����)</li>
                        <li>�� �������� ������� � �������� � ��������</li>
                    </ul>
                    <p>��������� ���� ����������� ���������� ��� ������������� � ����� �� ����� ���� �� ������� �� ������� �� �������.</p>

                    <h2>���������� � �����������:</h2>
                    <p>���������������� � ���������� ����� �� �������, ����� �� ������� ��������.</p>
                    <ul>
                        <li>���������� ���� ��������� �� ����� �� ������� � ��������� ���������� ��� ������</li>
                        <li>�� �� ������� ����������� ����������</li>
                    </ul>
                    <h3>����� �� ������������:</h3>
                    <ul>
                        <li>�� �������� � ������� � ���������� �� �������������</li>
                        <li>�� ��������� ����������� � ��������� �� ������������� ����</li>
                        <li>�� ���������� � ���� � ������� � ��������� ��������</li>
                    </ul>
                    <h3>���������� �� ������������:</h3>
                    <ul>
                        <li>�� ������� ���������� �� �������������� �� ���������</li>
                        <li>�� ������� �������� ����� � ���������� �� �����������</li>
                        <li>�� ���������� �� ��������� �� ������ � ������� �� ����������� �������</li>
                    </ul>
                    <p>������������ ����� ����� �� ������� � ������������, �� ����� �� ����� � ������ �� ������ �������, ��� ����� ��-����� ������ � �������������.</p>

                    <h2>���������:</h2>
                    <table class='table'>
                        <thead>
                            <tr>
                                <th>��������������</th>
                                <th>����</th>
                                <th>����������</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>������� � ������������</td>
                                <td>��</td>
                                <td>��</td>
                            </tr>
                            <tr>
                                <td>������ �� ��������</td>
                                <td>�������� (���������, ���������)</td>
                                <td>���������� (����������� �� �������)</td>
                            </tr>
                            <tr>
                                <td>�������� ����������</td>
                                <td>�������� (������� ����)</td>
                                <td>�� �� �������</td>
                            </tr>
                            <tr>
                                <td>���������������</td>
                                <td>�����������</td>
                                <td>������������ (�� ��������� �������)</td>
                            </tr>
                            <tr>
                                <td>����������</td>
                                <td>��</td>
                                <td>���� �� ����� �� �������</td>
                            </tr>
                            <tr>
                                <td>�����</td>
                                <td>������ �� �������, ������� � �������</td>
                                <td>������� � �������, �����������</td>
                            </tr>
                        </tbody>
                    </table>

                    <p>��� ����� �� ����� ��-��������� � �� �������� � ���������� �� �����������, ���������� � ���������� �����. ��� ����������� �� ���������� ������� ���� ��� ���������� ����������, ���������������� � ��-��������� �� ���.</p>
                ",
                PhoneNumber = "123-456-7890",
                Email = "info@t-camps.org",
                Instagram = "https://www.instagram.com/t-camps",
                Facebook = "https://www.facebook.com/t-camps",
                X = "https://www.x.com/t-camps",
                LinkedIn = "https://www.linkedin.com/company/t-camps",
                YouTube = "https://www.youtube.com/t-camps",
                Missions = new List<Mission>
                {
                    new Mission { Description = "�� �������� �����, � ����� ����� ���� ����� �� �� ������� �������� � ������ �� ������� ���� �����������." },
                    new Mission { Description = "�� ����������� ���������������� � ��������� ������� � ����������� �����." },
                    new Mission { Description = "�� ����������� ����������� � ���������� �������� ���� �������� � ������� ����������." }
                },
                Services = new List<Service>
                {
                    new Service { Description = "������������ �� ���������� ������� � ������ �� �������" },
                    new Service { Description = "����������� �� ������� � ������������� �������" },
                    new Service { Description = "������������� �������� � ��������" },
                    new Service { Description = "��������� �� ���� ����������� � ��������� ��������" }
                },
                Members = new List<Member>
                {
                    new Member { Name = "John Doe", Role = "Founder" },
                    new Member { Name = "Jane Smith", Role = "Coordinator" }
                },
                TermsAndConditions = new TermsAndConditions
                {
                    Content = "These are the terms and conditions for T-CAMPS."
                },
                Events = new List<Event>
                {
                    new Event
                    {
                        Name = "Summer Camp 2025",
                        Location = "Mountain Resort",
                        StartDate = new DateTime(2025, 6, 1),
                        EndDate = new DateTime(2025, 6, 10),
                        Price = 500.00m,
                        Schedules = new List<Schedule>
                        {
                            new Schedule { Description = "Opening Ceremony", Time = new DateTime(2025, 6, 1, 10, 0, 0) },
                            new Schedule { Description = "Hiking Trip", Time = new DateTime(2025, 6, 2, 8, 0, 0) }
                        },
                        Speakers = new List<Speaker>
                        {
                            new Speaker { Name = "Alice Johnson", Bio = "Expert in outdoor activities" },
                            new Speaker { Name = "Bob Brown", Bio = "Motivational speaker" }
                        }
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
                new Mission { Description = "�� �������� �����, � ����� ����� ���� ����� �� �� ������� �������� � ������ �� ������� ���� �����������.", CompanyId = 1 },
                new Mission { Description = "�� ����������� ���������������� � ��������� ������� � ����������� �����.", CompanyId = 1 },
                new Mission { Description = "�� ����������� ����������� � ���������� �������� ���� �������� � ������� ����������.", CompanyId = 1 }
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
                new Service { Description = "������������ �� ���������� ������� � ������ �� �������", CompanyId = 1 },
                new Service { Description = "����������� �� ������� � ������������� �������", CompanyId = 1 },
                new Service { Description = "������������� �������� � ��������", CompanyId = 1 },
                new Service { Description = "��������� �� ���� ����������� � ��������� ��������", CompanyId = 1 }
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
                    Name = "Summer Camp 2025",
                    Location = "Mountain Resort",
                    StartDate = new DateTime(2025, 6, 1),
                    EndDate = new DateTime(2025, 6, 10),
                    Price = 500.00m,
                    CompanyId = 1,
                    Schedules = new List<Schedule>
                    {
                        new Schedule { Description = "Opening Ceremony", Time = new DateTime(2025, 6, 1, 10, 0, 0) },
                        new Schedule { Description = "Hiking Trip", Time = new DateTime(2025, 6, 2, 8, 0, 0) }
                    },
                    Speakers = new List<Speaker>
                    {
                        new Speaker { Name = "Alice Johnson", Bio = "Expert in outdoor activities" },
                        new Speaker { Name = "Bob Brown", Bio = "Motivational speaker" }
                    }
                }
            };

            _context.Events.AddRange(events);
            await _context.SaveChangesAsync();
        }
    }
}
