namespace Skidly.Infrastructure.EntityFramework.Models;

public class RoleReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<ApplicationUserReadModel> Users { get; set; }
}