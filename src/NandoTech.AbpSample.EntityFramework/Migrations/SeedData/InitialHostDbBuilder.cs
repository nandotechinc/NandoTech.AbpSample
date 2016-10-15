using NandoTech.AbpSample.EntityFramework;
using EntityFramework.DynamicFilters;

namespace NandoTech.AbpSample.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly AbpSampleDbContext _context;

        public InitialHostDbBuilder(AbpSampleDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
