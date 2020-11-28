using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.OrganizationDirectory.Dto;

namespace WebApi.OrganizationDirectory
{
    public interface IOrganizationRepository
    {
        Task AddOrganization(Organization organization);
        Task<IEnumerable<Organization>> GetOrganizations();
    }
}
