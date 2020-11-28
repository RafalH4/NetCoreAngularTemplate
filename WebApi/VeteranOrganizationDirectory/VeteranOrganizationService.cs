using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.VeteranOrganizationDirectory.Dto;

namespace WebApi.VeteranOrganizationDirectory
{
    public class VeteranOrganizationService : IVeteranOrganizationService
    {
        private readonly IVeteranOrganizationRepository _veteranOrganizationRepository;
        public VeteranOrganizationService(IVeteranOrganizationRepository veteranOrganizationRepository)
        {
            _veteranOrganizationRepository = veteranOrganizationRepository;
        }
        public async Task AddVeteranToOrganization(AddVeteranOrganization addVeteranOrganization)
        {
            var addVeteranToOrg = new VeteranOrganization();
            addVeteranToOrg.Id = Guid.NewGuid();
            addVeteranToOrg.Role = addVeteranOrganization.Role;
            addVeteranToOrg.Organization = _veteranOrganizationRepository.GetOrganizationById(addVeteranOrganization.OrganizationID).Result;
            addVeteranToOrg.Veteran = _veteranOrganizationRepository.GetVeteranById(addVeteranOrganization.VeteranID).Result;

            await _veteranOrganizationRepository.AddVeteranToOrganization(addVeteranToOrg);

        }
    }
}
