using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BusinessDirectory.Dto
{
    public class BusinessInfoDto
    {
        public Guid Id { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public string PhotoUrl { get; set; }
        public double AvarageRate { get; set; }
        public Category Category { get; set; }
        public int BiggestDiscount { get; set; }
        public int RatingCount { get; set; }
        public string Description { get; set; }
    }
}
