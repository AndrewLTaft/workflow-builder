
namespace Api.DataAcess.Models;

public class Workflow
{
  public int? Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }

  public List<Step> Steps { get; set; } = new List<Step>();
  public ICollection<Part> Parts { get; set; } = new List<Part>();
}