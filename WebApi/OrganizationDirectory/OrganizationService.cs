using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.OrganizationDirectory.Dto;

namespace WebApi.OrganizationDirectory
{
    public class OrganizationService : IOrganizationService

    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
        public async Task AddOrganization(AddOrganization addOrganization)
        {
            var newOrganization = new Organization();
            newOrganization.Id = Guid.NewGuid();
            newOrganization.Address = addOrganization.Address;
            newOrganization.OrganizationName = addOrganization.OrganizationName;
            newOrganization.PhotoUrl = addOrganization.PhotoUrl;
            await _organizationRepository.AddOrganization(newOrganization);

        }

        public async Task<IEnumerable<GetOrganizations>> GetOrganizations()
        {
            var organizations = await _organizationRepository.GetOrganizations();
            return organizations.Select(organizations => new GetOrganizations()
            {
                Address = organizations.Address,
                OrganizationName = organizations.OrganizationName,
                PhotoUrl = organizations.PhotoUrl,
                Id = organizations.Id
            });
        }
    }
}
