using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AwardDirectory.Dto
{
    public class AddAward
    {
        public string AwardDescription { get; set; }
        public string UrlPhoto { get; set; }
    }
}
