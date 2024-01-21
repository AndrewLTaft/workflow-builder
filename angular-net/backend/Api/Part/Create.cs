using Api.DataAcess;

namespace Api.Part;

public class Create
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPost("part", async (Part_Post_Request part, ApiContext db) =>
    {
      var dbModel = new Api.DataAcess.Models.Part
      {
        WorkflowId = part.WorkflowId
      };
      db.Parts.Add(dbModel);
      await db.SaveChangesAsync();

      return new Part_Post_Response(dbModel.Id, dbModel.WorkflowId);
    })
    .WithOpenApi();
  }
}

record Part_Post_Request(int WorkflowId);

record Part_Post_Response(int Id, int WorkflowId);