using FlashCards.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Data.Context
{
    public class FlashCardContext : DbContext
    {
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Memorization> Memorizations { get; set; }
        public DbSet<User> Users { get; set; }

        public FlashCardContext(DbContextOptions<FlashCardContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Deck
            modelBuilder.Entity<Deck>()
                .HasKey(d => d.DeckId);

            modelBuilder.Entity<Deck>()
                .HasMany(d => d.Cards)
                .WithOne(d => d.Deck);

            modelBuilder.Entity<Deck>()
                .Property(d => d.DeckId)
                .HasColumnName("DeckId")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Deck>()
                .Property(d => d.Done)
                .HasColumnName("Done")
                .HasColumnType("TINYINT")
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<Deck>()
                .Property(d => d.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Deck>()
                .Property(d => d.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Deck>()
                .Property(d => d.User)
                .HasColumnName("User")
                .HasColumnType("int");
            #endregion

            #region Card       
            modelBuilder.Entity<Card>()
                .HasKey(c => c.CardId);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.Deck)
                .WithMany(d => d.Cards)
                .HasForeignKey(c => c.DeckId)
                .IsRequired();

            modelBuilder.Entity<Card>()
                .Property(c => c.CardId)
                .HasColumnName("CardId")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Card>()
                .Property(c => c.DeckId)
                .HasColumnName("DeckId")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Card>()
                .Property(c => c.Frontside)
                .HasColumnName("Frontside")
                .HasColumnType("varchar(500)")
                .IsRequired();

            modelBuilder.Entity<Card>()
                .Property(c => c.Backside)
                .HasColumnName("Backside")
                .HasColumnType("varchar(500)")
                .IsRequired();

            modelBuilder.Entity<Card>()
                .Property(c => c.MemorizationId)
                .HasColumnName("MemorizationId")
                .HasColumnType("int")
                .HasDefaultValue(1)
                .IsRequired();
            #endregion

            #region Memorization
            modelBuilder.Entity<Memorization>()
                .HasKey(m => m.MemorizationId);

            modelBuilder.Entity<Memorization>()
                 .Property(m => m.MemorizationId)
                 .HasColumnName("MemorizationId")
                 .HasColumnType("int")
                 .IsRequired();

            modelBuilder.Entity<Memorization>()
                .Property(m => m.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(20)")
                .IsRequired();

            modelBuilder.Entity<Memorization>()
                .Property(m => m.Level)
                .HasColumnName("Level")
                .HasColumnType("int")
                .IsRequired();
            #endregion

            #region User
            modelBuilder.Entity<User>()
                 .Property(u => u.UserId)
                 .HasColumnName("UserId")
                 .HasColumnType("int")
                 .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(u => u.Username)
                 .HasColumnName("Username")
                 .HasColumnType("varchar(50)")
                 .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(u => u.Password)
                 .HasColumnName("Password")
                 .HasColumnType("varchar(20)")
                 .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(u => u.Email)
                 .HasColumnName("Email")
                 .HasColumnType("varchar(100)")
                 .IsRequired();

            modelBuilder.Entity<User>()
                 .Property(u => u.Role)
                 .HasColumnName("Role")
                 .HasColumnType("varchar(20)")
                 .IsRequired();

            #endregion

        }
    }
}
