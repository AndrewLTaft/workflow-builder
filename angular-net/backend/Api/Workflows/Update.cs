using Api.DataAcess;
using Api.DataAcess.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Workflows;

public class Update
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPut("workflow", async (Workflow workflow, WorkflowService service) =>
    {
      return await service.UpdateAsync(workflow);
    })
    .WithOpenApi();
  }
}
