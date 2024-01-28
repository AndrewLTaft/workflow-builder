
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DataAcess.Models;

public class Workflow
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public List<Step> Steps { get; set; } = new List<Step>();
  public List<Part> Parts { get; set; } = new List<Part>();
}

public class WorkflowEntityTypeConfiguration : IEntityTypeConfiguration<Workflow>
{
  public void Configure(EntityTypeBuilder<Workflow> builder)
  {
    builder.OwnsMany(wf => wf.Steps);
    builder.HasMany(wf => wf.Parts).WithOne().OnDelete(DeleteBehavior.Restrict);
  }
}