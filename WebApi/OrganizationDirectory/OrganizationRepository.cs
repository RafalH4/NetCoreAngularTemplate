using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.OrganizationDirectory
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly Context _context;
        public OrganizationRepository(Context context)
        {
            _context = context;
        }
        public async Task AddOrganization(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public Task<IEnumerable<Organization>> GetOrganizations()
        {
            throw new NotImplementedException();
        }
    }
}
