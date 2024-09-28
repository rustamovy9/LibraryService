using System.Runtime;

namespace Infrustructure.Models;

public class Authors
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    
}