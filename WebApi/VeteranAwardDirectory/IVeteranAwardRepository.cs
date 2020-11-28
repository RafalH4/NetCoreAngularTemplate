using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory;
using WebApi.UserDirectory;

namespace WebApi.VeteranAwardDirectory
{
    public interface IVeteranAwardRepository
    {
        Task AddVeteranAward(VeteranAward veteranAward);
        Task<Award> GetAwardById(Guid id);
        Task<Veteran> GetVeteranById(Guid id);
        Task<IEnumerable<Award>> GetVeteranAvards(Guid id);
    }
}
