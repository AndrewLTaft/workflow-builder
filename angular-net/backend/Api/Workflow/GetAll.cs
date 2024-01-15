using Api.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace Api.Workflow;

public class GetAll
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapGet("workflow", async (ApiContext db) =>
    {
      return await db.Workflows

          .Select(w => new Workflow_GetAll_Response(
            w.Id,
            w.Name,
            w.Description,
            w.Steps.OrderBy(s => s.Order).Select(s => new Step_Response(s.Id, s.Name)).ToList()))
          .ToListAsync();
    })
    .WithOpenApi();
  }
}

record Workflow_GetAll_Response(int Id, string Name, string? Description, List<Step_Response> steps);

record Step_Response(int Id, string Name);