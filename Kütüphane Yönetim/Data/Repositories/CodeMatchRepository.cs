using KutuphaneyYonetim.Models.GameModels;

namespace KutuphaneyYonetim.Data.Repositories
{
    public class CodeMatchRepository : Repository<CodeMatch>
    {
        public CodeMatchRepository(KutuphaneyYonetimDbContext context) : base(context)
        {
        }
    }
}
