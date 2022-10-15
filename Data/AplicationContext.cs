using Data.Maps;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;


    public class AplicationContext: DbContext
    {
       /* public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {
        
        }*/
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tiraet2;Username=postgres;Password=1");
    
       
       public DbSet<Card> Cards { get; set; }
        public DbSet<Discont> Disconts { get; set; }
        public DbSet<MailToken> MailTokens { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        //dotnet tool install --global dotnet-ef
        //dotnet ef migrations add 'begin'
        //dotnet ef database update

        
        
    
        protected override void OnModelCreating(ModelBuilder model)
        {
           
            new UserMap(model.Entity<User>());
            new PersonMap(model.Entity<Person>());
            new CardMap(model.Entity<Card>());
            new MailTokenMap(model.Entity<MailToken>());
            new DiscontMap(model.Entity<Discont>()); 
            base.OnModelCreating(model);

        }

    
    }
