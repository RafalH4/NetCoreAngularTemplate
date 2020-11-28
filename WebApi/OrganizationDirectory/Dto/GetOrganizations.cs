using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.OrganizationDirectory.Dto
{
    public class GetOrganizations
    {
        public Guid Id { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
    }
}
