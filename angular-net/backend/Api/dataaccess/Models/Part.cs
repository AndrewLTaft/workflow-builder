namespace Api.DataAcess.Models;

public class Part
{
  public int Id { get; set; }

  public required int WorkflowId { get; set; }
  public Workflow? Workflow { get; set; }
}