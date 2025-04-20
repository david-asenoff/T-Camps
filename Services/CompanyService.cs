using T_Camps.Data;
using Microsoft.EntityFrameworkCore;

namespace T_Camps.Services
{
    public class CompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetCompanyAsync()
        {
            return await _context.Companies
                .Include(c => c.Missions)
                .Include(c => c.Services)
                .FirstOrDefaultAsync();
        }
    }
}
