using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Schulmanager.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext(){}
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options){}

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Anwesenheit> Anwesenheits { get; set; }
    public virtual DbSet<Fach> Faches { get; set; }
    public virtual DbSet<Klasse> Klasses { get; set; }
    public virtual DbSet<Kur> Kurs { get; set; }
    public virtual DbSet<Lehrer> Lehrers { get; set; }
    public virtual DbSet<LehrerFach> LehrerFaches { get; set; }
    public virtual DbSet<Noten> Notens { get; set; }
    public virtual DbSet<Raum> Raums { get; set; }
    public virtual DbSet<Slot> Slots { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<StudentFach> StudentFaches { get; set; }
    public virtual DbSet<Stundenplan> Stundenplans { get; set; }
    public virtual DbSet<ViewNotenspiegel> ViewNotenspiegels { get; set; }
    public virtual DbSet<ViewStundenplan> ViewStundenplans { get; set; }
    public virtual DbSet<ViewStundenplanKomplett> ViewStundenplanKompletts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\CC-Student\\Sqlite\\db\\SchoolDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");
            entity.HasIndex(e => e.Username, "IX_Account_Username").IsUnique();
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.FremdId).HasColumnName("FremdID");
        });
        modelBuilder.Entity<Anwesenheit>(entity =>
        {
            entity.ToTable("Anwesenheit");
            entity.Property(e => e.AnwesenheitId).HasColumnName("AnwesenheitID");
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.HasOne(d => d.Kurs).WithMany(p => p.Anwesenheits).HasForeignKey(d => d.KursId);
            entity.HasOne(d => d.Student).WithMany(p => p.Anwesenheits).HasForeignKey(d => d.StudentId);
        });
        modelBuilder.Entity<Fach>(entity =>
        {
            entity.ToTable("Fach");
            entity.Property(e => e.FachId).HasColumnName("FachID");
            entity.Property(e => e.Beschreibung).HasColumnType("TEXT (0)");
            entity.Property(e => e.Credits).HasDefaultValue(0).HasColumnType("INT");
            entity.Property(e => e.Titel).HasColumnType("VARCHAR (100)");
        });
        modelBuilder.Entity<Klasse>(entity =>
        {
            entity.ToTable("Klasse");
            entity.Property(e => e.KlasseId).HasColumnName("KlasseID");
            entity.Property(e => e.KlassenlehrerId).HasColumnName("KlassenlehrerID");
            entity.HasOne(d => d.Klassenlehrer).WithMany(p => p.Klasses).HasForeignKey(d => d.KlassenlehrerId);
        });
        modelBuilder.Entity<Kur>(entity =>
        {
            entity.HasKey(e => e.KursId);
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.FachId).HasColumnName("FachID");
            entity.Property(e => e.KlasseId).HasColumnName("KlasseID");
            entity.Property(e => e.LehrerId).HasColumnName("LehrerID");
            entity.HasOne(d => d.Fach).WithMany(p => p.Kurs).HasForeignKey(d => d.FachId);
            entity.HasOne(d => d.Klasse).WithMany(p => p.Kurs).HasForeignKey(d => d.KlasseId);
            entity.HasOne(d => d.Lehrer).WithMany(p => p.Kurs).HasForeignKey(d => d.LehrerId);
        });
        modelBuilder.Entity<Lehrer>(entity =>
        {
            entity.ToTable("Lehrer");
            entity.Property(e => e.LehrerId).HasColumnName("LehrerID");
            entity.Property(e => e.Email).HasColumnName("EMail");
        });
        modelBuilder.Entity<LehrerFach>(entity =>
        {
            entity.HasKey(e => e.LehFaId);
            entity.ToTable("LehrerFach");
            entity.Property(e => e.LehFaId).HasColumnName("LehFaID");
            entity.Property(e => e.FachId).HasColumnName("FachID");
            entity.Property(e => e.KlasseId).HasColumnName("KlasseID");
            entity.Property(e => e.LehrerId).HasColumnName("LehrerID");

            entity.HasOne(d => d.Fach).WithMany(p => p.LehrerFaches).HasForeignKey(d => d.FachId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Klasse).WithMany(p => p.LehrerFaches).HasForeignKey(d => d.KlasseId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Lehrer).WithMany(p => p.LehrerFaches).HasForeignKey(d => d.LehrerId).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<Noten>(entity =>
        {
            entity.ToTable("Noten");
            entity.Property(e => e.NotenId).HasColumnName("NotenID");
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.HasOne(d => d.Kurs).WithMany(p => p.Notens).HasForeignKey(d => d.KursId);
            entity.HasOne(d => d.Student).WithMany(p => p.Notens).HasForeignKey(d => d.StudentId);
        });
        modelBuilder.Entity<Raum>(entity =>
        {
            entity.ToTable("Raum");
            entity.Property(e => e.RaumId).HasColumnName("RaumID");
            entity.Property(e => e.Status).HasDefaultValueSql("aktiv");
        });
        modelBuilder.Entity<Slot>(entity =>
        {
            entity.ToTable("Slot");
            entity.Property(e => e.SlotId).HasColumnName("SlotID");
        });
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.KlasseId).HasColumnName("KlasseID");
            entity.HasOne(d => d.Klasse).WithMany(p => p.Students).HasForeignKey(d => d.KlasseId);
        });
        modelBuilder.Entity<StudentFach>(entity =>
        {
            entity.ToTable("StudentFach");
            entity.Property(e => e.StudentFachId).HasColumnName("StudentFachID");
            entity.Property(e => e.FachId).HasColumnName("FachID");
            entity.Property(e => e.LehrerId).HasColumnName("LehrerID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.HasOne(d => d.Fach).WithMany(p => p.StudentFaches).HasForeignKey(d => d.FachId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Lehrer).WithMany(p => p.StudentFaches).HasForeignKey(d => d.LehrerId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Student).WithMany(p => p.StudentFaches).HasForeignKey(d => d.StudentId).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<Stundenplan>(entity =>
        {
            entity.ToTable("Stundenplan");
            entity.Property(e => e.StundenplanId).HasColumnName("StundenplanID");
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.RaumId).HasColumnName("RaumID");
            entity.Property(e => e.SlotId).HasColumnName("SlotID");
            entity.HasOne(d => d.Kurs).WithMany(p => p.Stundenplans).HasForeignKey(d => d.KursId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Raum).WithMany(p => p.Stundenplans).HasForeignKey(d => d.RaumId).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Slot).WithMany(p => p.Stundenplans).HasForeignKey(d => d.SlotId).OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.Entity<ViewNotenspiegel>(entity =>
        {
            entity.HasNoKey().ToView("View_Notenspiegel");
            entity.Property(e => e.Fach).HasColumnType("VARCHAR (100)");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
        });
        modelBuilder.Entity<ViewStundenplan>(entity =>
        {
            entity.HasNoKey().ToView("View_Stundenplan");
            entity.Property(e => e.Fach).HasColumnType("VARCHAR (100)");
        });
        modelBuilder.Entity<ViewStundenplanKomplett>(entity =>
        {
            entity.HasNoKey().ToView("View_Stundenplan_Komplett");
            entity.Property(e => e.Fach).HasColumnType("VARCHAR (100)");
            entity.Property(e => e.StundenplanId).HasColumnName("StundenplanID");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
