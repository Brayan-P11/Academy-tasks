using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_ASP_WEB_impiegato.Models;

public partial class TaskImpiegatoContext : DbContext
{
    public TaskImpiegatoContext()
    {
    }

    public TaskImpiegatoContext(DbContextOptions<TaskImpiegatoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cittum> Cittas { get; set; }

    public virtual DbSet<Impiegato> Impiegatos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Reparto> Repartos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-22\\SQLEXPRESS;Database=task_impiegato;User Id=academy;Password=academy?;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cittum>(entity =>
        {
            entity.HasKey(e => e.CittaId).HasName("PK__Citta__3EF53F31902B6C3E");

            entity.Property(e => e.CittaId).HasColumnName("cittaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Impiegato>(entity =>
        {
            entity.HasKey(e => e.ImpiegatoId).HasName("PK__Impiegat__C7A20D128E135571");

            entity.ToTable("Impiegato");

            entity.HasIndex(e => e.Matricola, "UQ__Impiegat__2C2751BA56718C61").IsUnique();

            entity.HasIndex(e => e.Nome, "UQ__Impiegat__6F71C0DCA6023911").IsUnique();

            entity.HasIndex(e => e.Ruolo, "UQ__Impiegat__994A1C6B8C3645AD").IsUnique();

            entity.HasIndex(e => e.Indirizzo, "UQ__Impiegat__CBDAA5DC1E4D2FE7").IsUnique();

            entity.HasIndex(e => e.Cognome, "UQ__Impiegat__F83B294652B444B8").IsUnique();

            entity.Property(e => e.ImpiegatoId).HasColumnName("impiegatoID");
            entity.Property(e => e.CittaRif).HasColumnName("cittaRIF");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.DataNascita).HasColumnName("dataNascita");
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("indirizzo");
            entity.Property(e => e.Matricola)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("matricola");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.ProvinciaRif).HasColumnName("provinciaRIF");
            entity.Property(e => e.RepartoRif).HasColumnName("repartoRIF");
            entity.Property(e => e.Ruolo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ruolo");

            entity.HasOne(d => d.CittaRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.CittaRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Impiegato__citta__25518C17");

            entity.HasOne(d => d.ProvinciaRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.ProvinciaRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Impiegato__provi__2645B050");

            entity.HasOne(d => d.RepartoRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.RepartoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Impiegato__repar__245D67DE");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__671F1345F5CFB4CE");

            entity.HasIndex(e => e.Codice, "UQ__Provinci__40F9C18BAFF5D442").IsUnique();

            entity.Property(e => e.ProvinciaId).HasColumnName("provinciaID");
            entity.Property(e => e.Codice)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codice");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Reparto>(entity =>
        {
            entity.HasKey(e => e.RepartoId).HasName("PK__Reparto__612C4F36E5B33D2F");

            entity.ToTable("Reparto");

            entity.Property(e => e.RepartoId).HasColumnName("repartoID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
