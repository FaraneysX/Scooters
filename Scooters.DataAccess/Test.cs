using Microsoft.EntityFrameworkCore;

namespace Scooters.DataAccess
{
    public class Test
    {
        public static void TestMethod(IDbContextFactory<ScootersDbContext> contextFactory)
        {
            using var context = contextFactory.CreateDbContext();

            context.Users.Add(new Entities.UserEntity());
            context.Users.Where(x => x.Id == 1);
            context.SaveChanges();
        }
    }
}
