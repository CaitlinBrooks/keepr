using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }// Id of each individual vault name
    public string Name { get; set; } //vault name
    public string Description { get; set; } //vault description
  }
}