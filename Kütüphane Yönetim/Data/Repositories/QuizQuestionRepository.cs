using KutuphaneyYonetim.Models.GameModels;

namespace KutuphaneyYonetim.Data.Repositories
{
    public class QuizQuestionRepository : Repository<QuizQuestion>
    {
        public QuizQuestionRepository(KutuphaneyYonetimDbContext context) : base(context)
        {
        }
    }
}
