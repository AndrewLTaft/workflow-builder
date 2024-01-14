using Microsoft.EntityFrameworkCore;

namespace Api.DataAcess.Models;

public class Workflow {
  public int Id {get; init;}
  public string Name {get; init;} = "";
}