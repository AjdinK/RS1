using FIT_Api_Example.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Drzava> Drzava { get; set; }
    public DbSet<Predmet> Predmet { get; set; }
    public DbSet<Opstina> Opstina { get; set; }
    public DbSet<Student> Student { get; set; }

    public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
    public DbSet<Nastavnik> Nastavnik { get; set; }
    public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
    public DbSet<Obavijest> Obavijest { get; set; }
    public DbSet<AkademskaGodina> AkademskaGodina { get; set; }
    public DbSet<Ispit> Ispit{ get; set; }
    public DbSet<PrijavaIspita> PrijavaIspita{ get; set; }


    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}