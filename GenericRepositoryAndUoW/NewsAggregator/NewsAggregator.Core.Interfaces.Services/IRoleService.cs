using System.Collections.Generic;
using System.Threading.Tasks;
using NewsAggregator.Core.DataTransferObjects;

namespace NewsAggregator.Core.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDto> GetUserRoles(string userName);
        Task AddRoleToUser(string userName, RoleDto roleDto);
        Task<IEnumerable<RoleDto>> GetRoles();
    }
}

