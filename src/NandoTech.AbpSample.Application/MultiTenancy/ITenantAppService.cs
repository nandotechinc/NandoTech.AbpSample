using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NandoTech.AbpSample.MultiTenancy.Dto;

namespace NandoTech.AbpSample.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
