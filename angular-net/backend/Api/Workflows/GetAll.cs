using Microsoft.EntityFrameworkCore;

namespace Api.Workflows;

public class GetAll
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapGet("workflow", async (WorkflowService service) =>
    {
      return await service.GetAllAsync();
    })
    .WithOpenApi();
  }
}

// record Workflow_GetAll_Response(int Id, string Name, string? Description, List<Step_Response> steps);

// record Step_Response(int Id, string Name);