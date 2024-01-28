using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DataAcess.Models;

public class Part
{
  public int Id { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public required int WorkflowId { get; set; }

  public bool Completed { get; set; } = false;

  public Guid? StepId { get; set; }
}

public class PartEntityTypeConfiguration : IEntityTypeConfiguration<Part>
{
  public void Configure(EntityTypeBuilder<Part> builder)
  {
  }
}