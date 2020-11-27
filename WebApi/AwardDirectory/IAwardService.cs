using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory.Dto;

namespace WebApi.AwardDirectory
{
    public interface IAwardService
    {
        Task AddAward(AddAward addAward);
        Task<IEnumerable<GetAward>> GetAwards();
    }
}
