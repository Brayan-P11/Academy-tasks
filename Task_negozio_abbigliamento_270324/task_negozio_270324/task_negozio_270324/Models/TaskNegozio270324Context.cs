using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace task_negozio_270324.Models;

public partial class TaskNegozio270324Context : DbContext
{
    public TaskNegozio270324Context()
    {
    }

    public TaskNegozio270324Context(DbContextOptions<TaskNegozio270324Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ordine> Ordines { get; set; }

    public virtual DbSet<OrdineProdotto> OrdineProdottos { get; set; }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    public virtual DbSet<Variazione> Variaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-22\\SQLEXPRESS;Database=task_negozio_270324;User Id=academy;Password=academy?;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C0209C40B6C6");

            entity.HasIndex(e => e.Nome, "UQ__Categori__6F71C0DC16D6E97E").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__8F87D0E503F65DB6");

            entity.ToTable("Ordine");

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.DataEmissione).HasColumnName("data_emissione");
            entity.Property(e => e.NomeProdotto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome_prodotto");
            entity.Property(e => e.QuantitaOrd).HasColumnName("quantita_ord");
            entity.Property(e => e.StatoOrdine)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("stato_ordine");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Ordine__utenteRI__59063A47");
        });

        modelBuilder.Entity<OrdineProdotto>(entity =>
        {
            entity.HasKey(e => e.CodiceId).HasName("PK__Ordine_P__05D904A52BC8526E");

            entity.ToTable("Ordine_Prodotto");

            entity.Property(e => e.CodiceId).HasColumnName("codiceID");
            entity.Property(e => e.OrdineRif).HasColumnName("ordineRIF");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");

            entity.HasOne(d => d.OrdineRifNavigation).WithMany(p => p.OrdineProdottos)
                .HasForeignKey(d => d.OrdineRif)
                .HasConstraintName("FK__Ordine_Pr__ordin__5BE2A6F2");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.OrdineProdottos)
                .HasForeignKey(d => d.ProdottoRif)
                .HasConstraintName("FK__Ordine_Pr__prodo__5CD6CB2B");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB65975B641987D");

            entity.ToTable("Prodotto");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("categoriaRIF");
            entity.Property(e => e.Colore)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("colore");
            entity.Property(e => e.Galleria)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("galleria");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Taglia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("taglia");

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Prodotto__catego__5165187F");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C22535F5BB319");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Email, "UQ__Utente__AB6E61646CB549C7").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Variazione>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__54F6EA5A84319059");

            entity.ToTable("Variazione");

            entity.Property(e => e.VariazioneId).HasColumnName("variazioneID");
            entity.Property(e => e.FineOfferta).HasColumnName("fine_offerta");
            entity.Property(e => e.InizioOfferta).HasColumnName("inizio_offerta");
            entity.Property(e => e.PrezzoOfferta)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("prezzo_offerta");
            entity.Property(e => e.PrezzoPieno)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("prezzo_pieno");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.QuantitaFinale).HasColumnName("quantita_finale");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Variaziones)
                .HasForeignKey(d => d.ProdottoRif)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Variazion__prodo__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
