using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AwardDirectory.Dto;

namespace WebApi.AwardDirectory
{
    public class AwardService: IAwardService
    {
        private readonly IAwardRepository _awardRepository;
        public AwardService(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }
        public async Task AddAward(AddAward addAward)
        {
            var award = new Award();
            award.Id = Guid.NewGuid();
            award.AwardDescription = addAward.AwardDescription;
            award.UrlPhoto = addAward.UrlPhoto;
            await _awardRepository.AddAward(award);
        }
        public async Task<IEnumerable<GetAward>> GetAwards()
        {
            var x = await _awardRepository.GetAwards();
            return x.Select(x => new GetAward
            {
                AwardDescription = x.AwardDescription,
                Id = x.Id,
                UrlPhoto = x.UrlPhoto
            });

        }

    }
}
