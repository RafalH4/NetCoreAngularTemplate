using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory;
using WebApi.UserDirectory;

namespace WebApi.VeteranAwardDirectory
{
    public class VeteranAward
    {
        public Guid Id { get; set; }
        public Award Award { get; set; }
        public Veteran Veteran { get; set; }
    }
}
