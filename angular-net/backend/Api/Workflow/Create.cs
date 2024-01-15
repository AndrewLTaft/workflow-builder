using Api.DataAcess;

namespace Api.Workflow;

public class Create
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPost("workflow", async (Workflow_Post_Request workflow, ApiContext db) =>
    {
      var dbModel = new Api.DataAcess.Models.Workflow
      {
        Name = workflow.Name,
        Description = workflow.Description,
        Steps = workflow.Steps.Select((s, i) => new DataAcess.Models.Step { Name = s.Name, Order = i }).ToList()
      };
      db.Workflows.Add(dbModel);
      await db.SaveChangesAsync();

      return new Workflow_Post_Response(dbModel.Id, dbModel.Name, dbModel.Description, dbModel.Steps.Select(s => new Step_Post_Response(s.Id, s.Name)).ToList());
    })
    .WithOpenApi();
  }
}

record Workflow_Post_Request(string Name, string? Description, List<Step_Post_Request> Steps);
record Step_Post_Request(string Name);

record Workflow_Post_Response(int Id, string Name, string? Description, List<Step_Post_Response> Steps);
record Step_Post_Response(int Id, string Name);