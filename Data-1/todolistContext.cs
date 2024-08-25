using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Data_1;

public class todolistContext : DbContext
{
    public DbSet<category> categorys { get; set; }
    public DbSet<todo> todos { get; set; }

    public string DbPath { get; set; }

    public todolistContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
}
// The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    public class category
    {
        [Key]
        public int  id { get; set;}
        public string Titel { get; set; }
        public bool TsActive { get; set; }
        
        
        
        public int  category id { get; set; } 
        public category category { get; set; }
        
    }

    public class todo
    { 
        [Key]
        public int id { get; set;}
        public string Titel { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        
        
    }

}