using System.ComponentModel.DataAnnotations;

namespace Data_1;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public string Titel { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
}