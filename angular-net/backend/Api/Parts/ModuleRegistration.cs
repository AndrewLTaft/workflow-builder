namespace Api.Parts;

public static class PartApiRegistration
{
  public static void RegisterPartEndpoints(this IEndpointRouteBuilder builder)
  {
    GetAll.Register(builder);
    Create.Register(builder);
    CompleteStep.Register(builder);
  }
}