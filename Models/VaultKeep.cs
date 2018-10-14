using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }

    [Required]
    public string VaultId { get; set; }

    [Required]

    public string KeepId { get; set; }
    public string UserId { get; set; }

  }
}