namespace Api.Workflows;

public static class WorkflowApiRegistration
{
  public static void RegisterWorkflowEndpoints(this IEndpointRouteBuilder builder)
  {
    GetAll.Register(builder);
    Create.Register(builder);
    Update.Register(builder);
  }
}