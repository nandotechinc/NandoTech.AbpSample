using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace NandoTech.AbpSample.Web.Views
{
    public abstract class AbpSampleRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpSampleRazorPage()
        {
            LocalizationSourceName = AbpSampleConsts.LocalizationSourceName;
        }
    }
}
