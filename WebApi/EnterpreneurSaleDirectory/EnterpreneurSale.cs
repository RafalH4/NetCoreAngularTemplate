using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;
using WebApi.UserDirectory;

namespace WebApi.EnterpreneurSaleDirectory
{
    public class EnterpreneurSale
    {
        public Guid Id { get; set; }
        public string SaleName { get; set; }
        public string SaleDescription { get; set; }
        public int Discount { get; set; }
        public bool isActivated { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Business Business { get; set; }
        public Enterpreneur Enterpreneur { get; set; }
    }
}
