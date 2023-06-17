namespace Paintball_Project.Domain.Entities.EntitiesCore;

public class EntityCore
{
    public int Id { get; private set; }
    public DateTime DateTimeCreating { get; protected set; }
    public DateTime DateTimeChange { get; protected set; }
}
