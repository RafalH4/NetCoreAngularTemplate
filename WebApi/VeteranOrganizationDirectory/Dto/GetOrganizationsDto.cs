using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.VeteranOrganizationDirectory.Dto
{
    public class GetOrganizationsDto
    {
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
    }
}
