using KutuphaneyYonetim.Models.GameModels;

namespace KutuphaneyYonetim.Data.Repositories
{
    public class AchievementRepository : Repository<Achievement>
    {
        public AchievementRepository(KutuphaneyYonetimDbContext context) : base(context)
        {
        }
    }
}
