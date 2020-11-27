using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BusinessRatingsDirectory.Dto
{
    public class AddBusinessRate
    {
        public Guid BusinessID { get; set; }
        public int Rate { get; set; }
        public string Opinion { get; set; }
        public string UrlPhoto { get; set; }
    }
}
