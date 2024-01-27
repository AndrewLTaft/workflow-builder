using Api.DataAcess;

namespace Api.Workflows;

public class Create
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPost("workflow", async (Workflow_Post_Request workflow, WorkflowService service) =>
    {
      return await service.CreateAsync(workflow.Name, workflow.Description, workflow.Steps);
    })
    .WithOpenApi();
  }
}

record Workflow_Post_Request(string Name, string? Description, List<string> Steps);
