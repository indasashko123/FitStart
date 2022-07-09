namespace FitStart.Persistance
{
    public class DbInializer
    {
        public static void Inialize(FitStartDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
