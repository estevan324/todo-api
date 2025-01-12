namespace ToDo.Domain.Models.Entities;

public class OwnerEntity : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<ToDoEntity> ToDos { get; set; }
}