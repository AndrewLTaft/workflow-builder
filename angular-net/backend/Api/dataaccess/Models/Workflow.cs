using Microsoft.EntityFrameworkCore;

namespace Api.DataAcess.Models;

public class Workflow
{
  public int Id { get; set; }
  public string Name { get; set; } = "";

  public string? Description { get; set; }
}