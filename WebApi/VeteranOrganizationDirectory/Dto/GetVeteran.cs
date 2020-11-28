using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.VeteranOrganizationDirectory.Dto
{
    public class GetVeteran
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string AwatarUrl { get; set; }
        public int DamageToHealth { get; set; }
        public long Pesel { get; set; }
        public string VeteranCardNumber { get; set; }
    }
}
