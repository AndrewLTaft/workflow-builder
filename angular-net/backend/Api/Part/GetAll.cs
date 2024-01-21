using Api.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace Api.Part;

public class GetAll
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapGet("part", async (ApiContext db) =>
    {
      return await db.Parts

          .Select(w => new Part_GetAll_Response(
            w.Id,
            w.WorkflowId
            ))
          .ToListAsync();
    })
    .WithOpenApi();
  }
}

record Part_GetAll_Response(int Id, int WorkflowId);
