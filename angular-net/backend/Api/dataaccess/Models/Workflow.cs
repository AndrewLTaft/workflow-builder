
namespace Api.DataAcess.Models;

public class Workflow
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }

  public ICollection<Step> Steps { get; } = new List<Step>();
}