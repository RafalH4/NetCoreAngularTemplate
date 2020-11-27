using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory.Dto;

namespace WebApi.AwardDirectory
{
    public interface IAwardRepository
    {
        Task AddAward(Award award);
        Task<IEnumerable<Award>> GetAwards();

    }
}
