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
      if (await db.Workflows.Include(w => w.Steps).FirstOrDefaultAsync(w => w.Id == workflow.Id) is Api.DataAcess.Models.Workflow dbModel)
      {
        dbModel.Name = workflow.Name;
        dbModel.Description = workflow.Description;

        var steps = workflow.Steps.Select((newStep, i) =>
        {
          var dbStep = dbModel.Steps.FirstOrDefault(s => s.Id == newStep.Id);
          if (dbStep == null)
          {
            dbStep = new() { Name = newStep.Name, Order = i };
          }
          else
          {
            dbStep.Name = newStep.Name;
            dbStep.Order = i;
          }
          return dbStep;
        });
        dbModel.Steps = steps.ToList();

        await db.SaveChangesAsync();

        return Results.Ok(new Workflow_Put_Response(dbModel.Id, dbModel.Name, dbModel.Description, dbModel.Steps.Select(s => new Step_Put_Response(s.Id, s.Name)).ToList()));
      }
      else
      {
        return Results.BadRequest();
      }
    })
    .WithOpenApi();
  }
}

record Workflow_Put_Request(int Id, string Name, string? Description, List<Step_Put_Request> Steps);
record Step_Put_Request(int? Id, string Name);

record Workflow_Put_Response(int Id, string Name, string? Description, List<Step_Put_Response> Steps);
record Step_Put_Response(int Id, string Name);