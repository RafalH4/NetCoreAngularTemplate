using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.OrganizationDirectory.Dto;

namespace WebApi.OrganizationDirectory
{
    public interface IOrganizationService
    {
        Task AddOrganization(AddOrganization addOrganization);
        Task<IEnumerable<GetOrganizations>> GetOrganizations();
    }
}
