using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Core.Services.Interfaces;
using NewsAggregator.DAL.Repositories.Implementation;

namespace NewsAggregators.Services.Implementation
{
    public class RssSourseService : IRssSourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RssSourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<RssSourseDto>> GetAllRssSources()
        {
            return await _unitOfWork.RssSources.FindBy(sourse => !string.IsNullOrEmpty(sourse.Name))
                .Select(sourse => new RssSourseDto()
                {
                    Id = sourse.Id,
                    Name = sourse.Name,
                    Url = sourse.Url
                }).ToListAsync();
        }

        public async Task<RssSourseDto> GetRssSourseById(Guid id)
        {
            return _mapper.Map<RssSourseDto>(await _unitOfWork.RssSources.GetById(id));
        }

        public async Task<IEnumerable<RssSourseDto>> GetRssSoursesByNameAndUrl(string name, string url)
        {

            return await _unitOfWork.RssSources.FindBy(sourse => sourse.Name.Contains(name))
                .Select(sourse => _mapper.Map<RssSourseDto>(sourse)).ToListAsync();
        }
    }
}
