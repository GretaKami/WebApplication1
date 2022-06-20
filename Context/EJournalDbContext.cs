using Microsoft.EntityFrameworkCore;
using WebApplication1.Context.Entity;

namespace WebApplication1.Context
{
    public class EJournalDbContext : DbContext
    {
        /*
         * 1. Get the 3 EntityFrameworkCore packages from nuget
         * 2. Create Entities (classes that will be used to create the tables in db)
         * 3. Create DBCONTEXT and write the DBSets for the created entities
         * 4. Inside program add the builder.Services.AddDbContext
         * 5. Don't forget about the ConnectionStrings in AppSettings  (should be before number 4)
         * 6. Add-Migration  (add-migration "Type name of migration")in package manager console -- success if created the Migrations folder with migrations
         * 7. update-database in package manager console
         * 8. To use the dbContext don't forget to add it to the controller as a property and initialize it
         * through the constuctor, the context is then injected by the builder:
         *                          private readonly WebShopDbContext _context;
                                    public CategoryController(WebShopDbContext context)
                                    {
                                        _context = context;
                                    }
            9. Use the context to access the database or update the database
         */

        public EJournalDbContext(DbContextOptions<EJournalDbContext> options) : base (options)
        {

        }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}
