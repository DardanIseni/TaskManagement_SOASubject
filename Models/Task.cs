using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models;

public class Task
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime DateTime { get; set; }
    public bool IsCompleted { get; set; }
}