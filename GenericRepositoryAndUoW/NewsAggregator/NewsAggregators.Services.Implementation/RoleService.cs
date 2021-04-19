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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<RoleDto> GetUserRoles(string userName)
        {
            var role = (await _unitOfWork.Users
                .FindBy(user => user.Email.Equals(userName), 
                includes: user => user.Role)
                .FirstOrDefaultAsync()).Role;

            var roleDto = new RoleDto()
            {
                Id = role.Id,
                Name = role.Name
            };
            return roleDto;
        }

        public async Task AddRoleToUser(string userName, RoleDto roleDto)
        {
            if (_unitOfWork.Roles.GetById(roleDto.Id) != null)
            {
                var user = await _unitOfWork.Users
                    .FindBy(u => u.Email.Equals(userName)).FirstOrDefaultAsync();

                user.RoleId = roleDto.Id;

                await _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<RoleDto>> GetRoles()
        {
            return await _unitOfWork.Roles.Get()
                .Select(role => new RoleDto()
                {
                    Id = role.Id,
                    Name = role.Name
                })
                .ToListAsync();
        }
    }
}