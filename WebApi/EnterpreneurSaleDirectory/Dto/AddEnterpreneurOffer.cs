using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.EnterpreneurSaleDirectory.Dto
{
    public class AddEnterpreneurOffer
    {
        public string SaleName { get; set; }
        public string SaleDescription { get; set; }
        public int Discount { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
