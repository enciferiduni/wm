using System.ComponentModel.DataAnnotations;

namespace Data_1;

public class Category

{
   
    [Key]
    public int Id { get; set; }
    public string Titel { get; set; }
    public bool TsActive { get; set; }
    //relation
    public List <Todo>  Todos { get; set; }
 
}