using T_Camps.Data;
using T_Camps.ViewModels;
using Bogus;

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
}
