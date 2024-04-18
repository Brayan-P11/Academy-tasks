using Microsoft.EntityFrameworkCore;

namespace task_torneoMK_120424.Models
{
    public class TorneoContext : DbContext
    {
        public TorneoContext(DbContextOptions<TorneoContext> options) : base(options) { }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Squadra> Squadre { get; set; }
        public DbSet<Personaggio> Personaggi { get; set; }

        //RELAZIONE ONE TO ONE tra Utente e Squadra
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Utente>()
        //        .HasOne(e => e.Squadra)
        //        .WithOne(e => e.UtenteRN)
        //        .HasForeignKey<Squadra>(e => e.UtenteRif)
        //        .IsRequired();
        //}

        //RELAZIONE ONE TO MANY tra Squadra e Personaggi
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Squadra>()
        //        .HasMany(e => e.Personaggios)
        //        .WithOne(e => e.SquadraRifNavigation)
        //        .HasForeignKey(e => e.SquadraRIF)
        //        .IsRequired();

        //}

    }
}
