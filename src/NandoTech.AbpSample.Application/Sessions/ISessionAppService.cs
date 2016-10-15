using System.Threading.Tasks;
using Abp.Application.Services;
using NandoTech.AbpSample.Sessions.Dto;

namespace NandoTech.AbpSample.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
