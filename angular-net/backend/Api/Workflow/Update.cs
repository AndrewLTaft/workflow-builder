using Api.DataAcess;
using Api.DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Workflow;

public class Update
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPut("workflow", async (Workflow_Put_Request workflow, ApiContext db) =>
    {
      if (await db.Workflows.FirstOrDefaultAsync(w => w.Id == workflow.Id) is Api.DataAcess.Models.Workflow dbModel)
      {
        dbModel.Name = workflow.Name;
        dbModel.Description = workflow.Description;

        await db.SaveChangesAsync();

        return Results.Ok(new Workflow_Put_Response(dbModel.Id, dbModel.Name, dbModel.Description));
      }
      else
      {
        return Results.BadRequest();
      }


    })
    .WithOpenApi();
  }
}

record Workflow_Put_Request(int Id, string Name, string? Description);

record Workflow_Put_Response(int Id, string Name, string? Description);