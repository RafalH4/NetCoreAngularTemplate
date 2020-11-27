using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory;
using WebApi.UserDirectory;

namespace WebApi.VeteranAwardDirectory.Dto
{
    public class AddVeteranAward
    {
        public Guid VeteranID { get; set; }
        public Guid AwardID { get; set; }
    }
}
