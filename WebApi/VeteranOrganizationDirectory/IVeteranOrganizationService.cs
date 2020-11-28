using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.VeteranOrganizationDirectory.Dto;

namespace WebApi.VeteranOrganizationDirectory
{
    public interface IVeteranOrganizationService
    {
        Task AddVeteranToOrganization(AddVeteranOrganization addVeteranAward);
        Task<IEnumerable<GetVeteran>> GetVeteransByOrgId(Guid idOrg);
        Task <IEnumerable<GetOrganizationsDto>>GetOrganizations(Guid id);
    }
}
