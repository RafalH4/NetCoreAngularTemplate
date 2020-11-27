using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.UserDirectory;

namespace WebApi.BusinessRatingsDirectory
{
    public class BusinessRatings
    {
        public Guid Id { get; set; }
        public Veteran Veteran { get; set; }
        public Business Business { get; set; }
        public int Rate { get; set; }
        public string Opinion { get; set; }
        public string UrlPhoto { get; set; }
    }
}
