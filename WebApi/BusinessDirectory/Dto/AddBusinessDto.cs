using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BusinessDirectory.Dto
{
    public class AddBusinessDto
    {
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public string PhotoUrl { get; set; }
        public Category Category { get; set; }
    }
}
