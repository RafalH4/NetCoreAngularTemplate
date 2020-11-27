using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.OrganizationDirectory;
using WebApi.UserDirectory;

namespace WebApi.VeteranOrganizationDirectory
{
    public class VeteranOrganization
    {
        public Guid Id { get; set; }
        public Veteran Veteran { get; set; }
        public Organization Organization { get; set; }
        public string Role { get; set; }
    }
}
