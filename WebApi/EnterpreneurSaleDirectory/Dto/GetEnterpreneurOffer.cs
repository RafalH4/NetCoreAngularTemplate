using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessDirectory;

namespace WebApi.EnterpreneurSaleDirectory.Dto
{
    public class GetEnterpreneurOffer
    {
        public BusinessDto Business { get; set; }
        public SaleDto Sale { get; set; }
        public EnterpreneurDto Enterpreneur { get; set; }

    }
    public class BusinessDto
    {
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public string PhotoUrl { get; set; }
        public BusinessDto()
        {
        }
    }
    public class SaleDto
    {
        public string SaleName { get; set; }
        public string SaleDescription { get; set; }
        public int Discount { get; set; }
        public bool isActivated { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public SaleDto()
        {
        }
    }
    public class EnterpreneurDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AwatarUrl { get; set; }
        public EnterpreneurDto()
        {
        }
    }
}
