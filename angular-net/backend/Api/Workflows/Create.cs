using Api.DataAcess;

namespace Api.Workflows;

public class Create
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPost("workflow", async (Workflow_Post_Request workflow, WorkflowService service) =>
    {
      return await service.CreateAsync(
        new Workflow_Create
        {
          Name = workflow.Name,
          Description = workflow.Description,
          Steps = workflow.Steps.Select(step => new Step
          {
            Id = new Guid(),
            Name = step.Name
          })
            .ToList()
        });
    })
    .WithOpenApi();
  }
}

record Workflow_Post_Request(string Name, string? Description, List<Step_Post_Request> Steps);
record Step_Post_Request(string Name);
