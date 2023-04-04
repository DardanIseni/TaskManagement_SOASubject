using Microsoft.EntityFrameworkCore;
namespace TaskManagement.db;
using Task = TaskManagement.Models.Task; 

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

    public DbSet<Task> Tasks { get;set; }

}