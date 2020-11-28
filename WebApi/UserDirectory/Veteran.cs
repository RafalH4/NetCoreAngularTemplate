using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory;
using WebApi.BusinessRatingsDirectory;
using WebApi.VeteranAwardDirectory;
using WebApi.VeteranOrganizationDirectory;
using WebApi.VeteranSaleDirectory;

namespace WebApi.UserDirectory
{
    public class Veteran: User
    {
        public List<Veteran> Friends { get; set; }
        public int DamageToHealth { get; set; }
        public long Pesel { get; set; }
        public string VeteranCardNumber { get; set; }
        public List<VeteranOrganization> VeteranOrganizations { get; set; }
        public List<VeteranAward> VeteranAwards { get; set; }
        public List<BusinessRatings> BusinessRatings { get; set; }
        public List<VeteranSale> VeteranSales { get; set; }
    }
}
