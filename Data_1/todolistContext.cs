using Microsoft.EntityFrameworkCore;
namespace Data_1;

public class TodolistContext : DbContext
{
    public DbSet<Category> categorys { get; set; }
    public DbSet<Todo> todos { get; set; }

    public string DbPath { get; set; }
    public object Categories { get; set; }

    public TodolistContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    public TodolistContext(string dbPath)
    {
        DbPath = dbPath;
        
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(connectionString:$"Data_1 Source = { DbPath }");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(e =>e .Todos)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.Id);
        modelBuilder.Entity<Todo>()
            .HasOne(p => p.Category)
            .WithMany(p => p.Todos)
            .HasForeignKey(p => p.Id);

    }
    
   
}