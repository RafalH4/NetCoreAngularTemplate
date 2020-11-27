using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory;

namespace WebApi.VeteranSaleDirectory.Dto
{
    public class AddVeteranOffer
    {
        public string SaleName { get; set; }
        public string SaleDescription { get; set; }
        public int Discount { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Veteran Veteran { get; set; }
    }
}
