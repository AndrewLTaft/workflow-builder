using Api.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace Api.Parts;

public class GetAll
{
  public static void Register(IEndpointRouteBuilder builder)
  {
    builder.MapGet("part", async (PartService service) =>
    {
      return await service.GetAllAsync();
    })
    .WithOpenApi();
  }
}