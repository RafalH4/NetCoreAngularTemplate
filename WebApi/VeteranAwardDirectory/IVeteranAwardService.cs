using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.VeteranAwardDirectory.Dto;

namespace WebApi.VeteranAwardDirectory
{
    public interface IVeteranAwardService
    {
        Task AddVeteranAward(AddVeteranAward addVeteranAward);
        Task<IEnumerable<GetAvardsDto>> GetVeteranAvards(Guid id);
    }
}
