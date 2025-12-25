using KutuphaneyYonetim.Models.GameModels;

namespace KutuphaneyYonetim.Data.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(KutuphaneyYonetimDbContext context) : base(context)
        {
        }
    }
}
