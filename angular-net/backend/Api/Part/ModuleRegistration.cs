namespace Api.Part;

public static class PartApiRegistration
{
  public static void RegisterPartEndpoints(this IEndpointRouteBuilder builder)
  {
    GetAll.Register(builder);
    Create.Register(builder);
    //Update.Register(builder);
  }
}