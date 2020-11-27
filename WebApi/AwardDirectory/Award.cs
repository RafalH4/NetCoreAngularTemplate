using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.VeteranAwardDirectory;

namespace WebApi.AwardDirectory
{
    public class Award
    {
        public Guid Id { get; set; }
        public string AwardDescription { get; set; }
        public string UrlPhoto { get; set; }
        public List<VeteranAward> VeteranAwards { get; set; }
    }
}
