using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BusinessRatingsDirectory;
using WebApi.EnterpreneurSaleDirectory;
using WebApi.UserDirectory;

namespace WebApi.BusinessDirectory
{
    public class Business
    {
        public Guid Id { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public string PhotoUrl { get; set; }
        public List<BusinessRatings> BusinessRatings { get; set; }
        public List<EnterpreneurSale> EnterpreneurSales { get; set; }
        public List<Enterpreneur> Enterpreneurs { get; set; }
        public Category Category { get; set; }
    }
    public enum Category
    {
        Restauracje,
        Sklepy,
        Atrakcje,
        Hotele,
        Inne
    }
}
