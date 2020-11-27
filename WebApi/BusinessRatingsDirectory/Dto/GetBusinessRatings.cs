using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.UserDirectory;

namespace WebApi.BusinessRatingsDirectory.Dto
{
    public class GetBusinessRatings
    {
        public VeteranDto Veteran { get; set; }
        public Guid Id { get; set; }
        public int Rate { get; set; }
        public string Opinion { get; set; }
        public string UrlPhoto { get; set; }

    }
    public class VeteranDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AwatarUrl { get; set; }
        public VeteranDto()
        {

        }

    }

}
