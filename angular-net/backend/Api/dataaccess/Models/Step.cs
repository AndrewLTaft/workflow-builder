namespace Api.DataAcess.Models;

public class Step
{
  public required Guid Id { get; set; } = new Guid();
  public required string Name { get; set; }
  public required int Order { get; set; }
}