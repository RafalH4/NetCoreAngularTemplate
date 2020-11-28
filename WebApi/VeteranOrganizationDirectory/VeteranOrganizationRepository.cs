using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;
using WebApi.OrganizationDirectory;
using WebApi.UserDirectory;

namespace WebApi.VeteranOrganizationDirectory
{
    public class VeteranOrganizationRepository : IVeteranOrganizationRepository
    {
        private readonly Context _context;
        public VeteranOrganizationRepository(Context context)
        {
            _context = context;
        }

        public async Task AddVeteranToOrganization(VeteranOrganization vet)
        {
            await _context.VeteranOrganizations.AddAsync(vet);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Organization> GetOrganizationById(Guid id)
        => await Task.FromResult(_context.Organizations.FirstOrDefault(
                org => org.Id == id));

        public async Task<Veteran> GetVeteranById(Guid id)
        => await Task.FromResult(_context.Veterans.FirstOrDefault(
                vet => vet.Id == id));

        public async Task<IEnumerable<Veteran>> GetVeteransByOrgId(Guid idOrg)
        => await Task.FromResult(_context.VeteranOrganizations.Where(org => org.Organization.Id == idOrg).Select(org=>org.Veteran).ToList());

    }
}
