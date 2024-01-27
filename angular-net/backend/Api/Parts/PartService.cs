
using Api.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace Api.Parts;

public class PartService
{
  private readonly ApiContext db;

  public PartService(ApiContext db)
  {
    this.db = db;
  }

  public async Task<List<Part>> GetAllAsync()
  {
    return await db.Parts
      .Select(w => new Part
      {
        Id = w.Id,
        WorkflowId = w.WorkflowId
      })
      .ToListAsync();
  }


  public async Task<Part> CreateAsync(int WorkflowId)
  {
    var dbModel = new Api.DataAcess.Models.Part
    {
      WorkflowId = WorkflowId
    };
    db.Parts.Add(dbModel);
    await db.SaveChangesAsync();

    return new Part
    {
      Id = dbModel.Id,
      WorkflowId = dbModel.WorkflowId
    };
  }
}

public class Part
{
  public int Id { get; init; }
  public int WorkflowId { get; init; }
}
