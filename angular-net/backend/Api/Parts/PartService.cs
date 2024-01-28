
using Api.DataAcess;
using Api.Workflows;
using Microsoft.EntityFrameworkCore;

namespace Api.Parts;

public class PartService
{
  private readonly ApiContext db;
  private readonly WorkflowService workflowService;

  public PartService(ApiContext db, WorkflowService workflowService)
  {
    this.db = db;
    this.workflowService = workflowService;
  }

  public async Task<List<Part>> GetAllAsync()
  {
    return await db.Parts
      .Select(w => FromModel(w))
      .ToListAsync();
  }

  public async Task<Part> CreateAsync(int workflowId)
  {
    var dbModel = new Api.DataAcess.Models.Part
    {
      WorkflowId = workflowId
    };
    db.Parts.Add(dbModel);
    await db.SaveChangesAsync();

    return FromModel(dbModel);
  }

  public async Task<Part> CompleteCurrentStep(int partId)
  {
    if (db.Parts.Find(partId) is DataAcess.Models.Part dbModel)
    {
      if (dbModel.Completed)
      {
        throw new ArgumentException("Part already completed");
      }
      var workflow = await workflowService.GetAsync(dbModel.WorkflowId);
      var nextStep = workflowService.GetNextStep(workflow, dbModel.StepId);
      if (nextStep == null)
      {
        dbModel.StepId = null;
        dbModel.Step = null;
        dbModel.Completed = true;
      }
      else
      {
        dbModel.StepId = nextStep.Id;
      }
      await db.SaveChangesAsync();

      return FromModel(dbModel);
    }
    throw new ArgumentException("Part not found");
  }

  private static Part FromModel(DataAcess.Models.Part model)
  {
    return new Part
    {
      Id = model.Id,
      WorkflowId = model.WorkflowId,
      CreatedAt = model.CreatedAt,
      Completed = model.Completed,
      StepId = model.StepId
    };
  }
}

public class Part
{
  public int Id { get; init; }
  public required DateTime CreatedAt { get; init; }
  public required int WorkflowId { get; init; }
  public required bool Completed { get; init; }
  public Guid? StepId { get; init; }
}
