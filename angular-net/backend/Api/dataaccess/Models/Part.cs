namespace Api.DataAcess.Models;

public class Part
{
  public int Id { get; set; }

  public required int WorkflowId { get; set; }

  public Workflow? Workflow { get; set; }

  public bool Completed { get; set; } = false;

  public int? StepId { get; set; }

  public Step? Step { get; set; }
}