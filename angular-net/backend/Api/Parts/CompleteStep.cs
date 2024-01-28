using Api.DataAcess;

namespace Api.Parts;

public class CompleteStep
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapPatch("part/{id:int}/completestep", async (int id, PartService service) =>
    {
      return await service.CompleteCurrentStep(id);
    })
    .WithOpenApi();
  }
}
