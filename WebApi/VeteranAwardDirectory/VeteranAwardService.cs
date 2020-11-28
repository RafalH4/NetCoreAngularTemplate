using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.VeteranAwardDirectory.Dto;

namespace WebApi.VeteranAwardDirectory
{
    public class VeteranAwardService: IVeteranAwardService
    {
        private readonly IVeteranAwardRepository _veteranAwardRepository;
        public VeteranAwardService(IVeteranAwardRepository veteranAwardRepository)
        {
            _veteranAwardRepository = veteranAwardRepository;
        }
        public async Task AddVeteranAward(AddVeteranAward addVeteranAward)
        {
            var veteranAward = new VeteranAward();
            veteranAward.Id = Guid.NewGuid();
            veteranAward.Award = _veteranAwardRepository.GetAwardById(addVeteranAward.AwardID).Result;
            veteranAward.Veteran = _veteranAwardRepository.GetVeteranById(addVeteranAward.VeteranID).Result;

            await _veteranAwardRepository.AddVeteranAward(veteranAward);

        }

        public async Task<IEnumerable<GetAvardsDto>> GetVeteranAvards(Guid id)
        {
            var awards = await _veteranAwardRepository.GetVeteranAvards(id);
            return awards.Select(awards => new GetAvardsDto()
            {
                AwardDescription = awards.AwardDescription,
                UrlPhoto = awards.UrlPhoto
            });
        }
    }
}
