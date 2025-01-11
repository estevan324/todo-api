using ToDo.Domain.Domain.Enums;

namespace ToDo.Domain.Domain.Entities;

public class ToDoEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public OwnerEntity Owner { get; set; }
}