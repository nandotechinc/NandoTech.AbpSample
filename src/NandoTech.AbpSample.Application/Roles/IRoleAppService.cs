using System.Threading.Tasks;
using Abp.Application.Services;
using NandoTech.AbpSample.Roles.Dto;

namespace NandoTech.AbpSample.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
