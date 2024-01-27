using Api.DataAcess;

namespace Api.Parts;

public class Create
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPost("part", async (Part_Post_Request part, PartService service) =>
    {
      return await service.CreateAsync(part.WorkflowId);
    })
    .WithOpenApi();
  }
}

record Part_Post_Request(int WorkflowId);