using Arende_hantering_wpf.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Arende_hantering_wpf.Contexts;

internal class DataContext : DbContext
{
    #region constructors and overrides
    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jamho\source\repos\EC-UTBILDNING\Datalagring-Kurs\Datalagring-inlamning\Arende-hantering-wpf\Contexts\arende-hantering-wpf_db.mdf;Integrated Security=True;Connect Timeout=30");
                                    
    }
    #endregion
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserTypeEntity> UserTypes { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CaseEntity> Cases { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
}
