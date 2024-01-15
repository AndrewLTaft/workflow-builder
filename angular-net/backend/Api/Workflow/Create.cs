using Api.DataAcess;

namespace Api.Workflow;

public class Create
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPost("workflow", async (Workflow_PostRequest workflow, ApiContext db) =>
    {
      var dbModel = new Api.DataAcess.Models.Workflow
      {
        Name = workflow.Name,
        Description = workflow.Description
      };
      db.Workflows.Add(dbModel);
      await db.SaveChangesAsync();

      return new Workflow_Post_Response(dbModel.Id, dbModel.Name, dbModel.Description);
    })
    .WithOpenApi();
  }
}

record Workflow_PostRequest(string Name, string? Description);

record Workflow_Post_Response(int Id, string Name, string? Description);