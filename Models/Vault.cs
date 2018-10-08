using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }// Id of each individual vault name
    public string UserId { get; set; } // Id of the user to create the vault
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
      UserId = userId;
    }
    public Vault() { }
  }
}