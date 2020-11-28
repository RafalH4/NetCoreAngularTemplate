using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.VeteranOrganizationDirectory.Dto
{
    public class AddVeteranOrganization
    {
        public string Role { get; set; }
        public Guid VeteranID { get; set; }
        public Guid OrganizationID { get; set; }
    }
}
