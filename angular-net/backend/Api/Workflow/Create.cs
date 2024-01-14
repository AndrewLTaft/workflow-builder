using Api.DataAcess;

namespace Api.Workflow;

public class Create{
  public static void Register(IEndpointRouteBuilder builder) {
    builder.MapPost("workflow", async (Workflow_PostRequest workflow, ApiContext db) =>{
        var dbModel = new Api.DataAcess.Models.Workflow{Name = workflow.Name};
        db.Workflows.Add(dbModel);
        await db.SaveChangesAsync();

        return new Workflow_Post_Response(dbModel.Id, dbModel.Name);
    })
    .WithOpenApi();
  }
}

record Workflow_PostRequest(string Name);

record Workflow_Post_Response(int Id, string Name);