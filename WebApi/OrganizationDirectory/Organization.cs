using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.VeteranOrganizationDirectory;

namespace WebApi.OrganizationDirectory
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public List<VeteranOrganization> VeteranOrganizations { get; set; }
    }

}
