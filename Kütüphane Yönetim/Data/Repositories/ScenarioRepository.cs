using KutuphaneyYonetim.Models.GameModels;

namespace KutuphaneyYonetim.Data.Repositories
{
    public class ScenarioRepository : Repository<Scenario>
    {
        public ScenarioRepository(KutuphaneyYonetimDbContext context) : base(context)
        {
        }
    }
}
