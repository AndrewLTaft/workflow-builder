using Microsoft.EntityFrameworkCore;

namespace Api.Workflows;

public class GetAll
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapGet("workflow", async (WorkflowService service) =>
    {
      return await service.GetAllAsync();
    })
    .WithOpenApi();
  }
}