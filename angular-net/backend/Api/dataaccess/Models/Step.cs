namespace Api.DataAcess.Models;

public class Step
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required int Order { get; set; }
}