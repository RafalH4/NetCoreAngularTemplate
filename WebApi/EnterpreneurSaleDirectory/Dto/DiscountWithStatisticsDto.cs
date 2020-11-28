using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.EnterpreneurSaleDirectory.Dto
{
    public class DiscountWithStatisticsDto
    {
        public Guid DiscountID { get; set; }
        public int Discount { get; set; }
        public double AverageRate { get; set; }
        public string BusinessName { get; set; }
        public string PhotoUrl { get; set; }
        public int RatingCount { get; set; }
        public string Description { get; set; }
    }
}
