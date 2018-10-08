using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }// Id of each individual vault name
    [Required]
    [MinLength(6)]
    public string Name { get; set; } //vault name
    [Required]
    [MaxLength(255)]
    public string Description { get; set; } //vault description

    public Vault(string userId, string name, string description) //needs these to create a vault
    {
      Name = name;
      Description = description;
      userId = userid; // ask about this
    }
    public Vault() { }
  }
}