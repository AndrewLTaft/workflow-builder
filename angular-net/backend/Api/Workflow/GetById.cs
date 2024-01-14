using Api.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace Api.Workflow;

public class GetById{
  public static void Register(IEndpointRouteBuilder builder) {
    builder.MapGet("workflow/{id:int}", async (int Id, ApiContext db) =>{
    return await db.Workflows
        .Where(w => w.Id == Id)
        .Select(w => new Workflow_GetById_Response(w.Id, w.Name))
        .FirstAsync();
})
.WithOpenApi();
  }
}

record Workflow_GetById_Response(int Id, string Name);
