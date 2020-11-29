using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.StatisticsDirectory.Dto
{
    public class GetHomeStatisticsDto
    {
        public int Veterans { get; set; }
        public int VeteransWeek { get; set; }
        public int Enterpreneurs { get; set; }
        public int EnterpreneursWeek { get; set; }
        public int Organizations { get; set; }
        public int OrganizationsWeek { get; set; }
        public int ActualSales { get; set; }
        public int ActualSalesWeek { get; set; }
    }
}
