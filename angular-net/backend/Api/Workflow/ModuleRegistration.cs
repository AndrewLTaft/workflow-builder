namespace Api.Workflow;

public static class WorkflowApiRegistration {
  public static void RegisterWorkflowEndpoints(this IEndpointRouteBuilder builder) {
    GetAll.Register(builder);
    GetById.Register(builder);
    Create.Register(builder);
  }
}