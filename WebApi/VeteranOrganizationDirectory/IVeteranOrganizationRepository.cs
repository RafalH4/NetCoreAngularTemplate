using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.OrganizationDirectory;
using WebApi.UserDirectory;

namespace WebApi.VeteranOrganizationDirectory
{
    public interface IVeteranOrganizationRepository
    {
        Task<Organization> GetOrganizationById(Guid id);
        Task<Veteran> GetVeteranById(Guid id);
        Task AddVeteranToOrganization(VeteranOrganization vet);
        Task<IEnumerable<Veteran>> GetVeteransByOrgId(Guid idOrg);
        Task<IEnumerable<Organization>> GetOrganizations(Guid id);
    }
}
