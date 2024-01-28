using Microsoft.EntityFrameworkCore;
using Api.DataAcess;

namespace Api.Workflows;

public class WorkflowService
{
  private readonly ApiContext db;

  public WorkflowService(ApiContext db)
  {
    this.db = db;
  }

  public async Task<List<Workflow>> GetAllAsync()
  {
    return await db.Workflows

          .Select(w => new Workflow
          {
            Id = w.Id,
            Name = w.Name,
            Description = w.Description,
            Steps = w.Steps.OrderBy(s => s.Order).Select(s => new Step
            {
              Id = s.Id,
              Name = s.Name
            }).ToList()
          })
          .ToListAsync();
  }

  public async Task<Workflow> CreateAsync(Workflow_Create workflow)
  {
    var dbModel = new Api.DataAcess.Models.Workflow
    {
      Name = workflow.Name,
      Description = workflow.Description,
      Steps = workflow.Steps.Select((s, i) => new DataAcess.Models.Step
      {
        Id = s.Id ?? new Guid(),
        Name = s.Name,
        Order = i
      }).ToList()
    };
    db.Workflows.Add(dbModel);
    await db.SaveChangesAsync();

    return new Workflow
    {
      Id = dbModel.Id,
      Name = dbModel.Name,
      Description = dbModel.Description,
      Steps = dbModel.Steps.Select(s => new Step
      {
        Id = s.Id,
        Name = s.Name
      }).ToList()
    };
  }

  public async Task<Workflow> UpdateAsync(Workflow workflow)
  {
    if (await db.Workflows.Include(w => w.Steps).FirstOrDefaultAsync(w => w.Id == workflow.Id) is Api.DataAcess.Models.Workflow dbModel)
    {
      dbModel.Name = workflow.Name;
      dbModel.Description = workflow.Description;

      var steps = workflow.Steps.Select((newStep, i) =>
      {
        var dbStep = dbModel.Steps.FirstOrDefault(s => s.Id == newStep.Id);
        if (dbStep == null)
        {
          dbStep = new()
          {
            Id = new Guid(),
            Name = newStep.Name,
            Order = i
          };
        }
        else
        {
          dbStep.Name = newStep.Name;
          dbStep.Order = i;
        }
        return dbStep;
      });
      dbModel.Steps = steps.ToList();

      await db.SaveChangesAsync();

      return new Workflow
      {
        Id = dbModel.Id,
        Name = dbModel.Name,
        Description = dbModel.Description,
        Steps = dbModel.Steps.Select(s => new Step
        {
          Id = s.Id,
          Name = s.Name
        }).ToList()
      };
    }
    else
    {
      throw new ArgumentException("Workflow not found");
    }
  }
}

public class Workflow_Create
{
  public required string Name { get; init; }
  public string? Description { get; init; }
  public List<Step> Steps { get; init; } = new List<Step>();
}

public class Workflow : Workflow_Create
{
  public int Id { get; init; }
}

public class Step
{
  public Guid? Id { get; init; }
  public required string Name { get; init; }
}
