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
          .Select(w => new Workflow_GetAll_Response(w.Id, w.Name, w.Description))
          .ToListAsync();
    })
    .WithOpenApi();
  }
}

record Workflow_GetAll_Response(int Id, string Name, string? Description);
