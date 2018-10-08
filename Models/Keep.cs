using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public string Img { get; set; }
    public int Id { get; set; }
    [Required]
    [MinLength(6)]
    public string Name { get; set; }
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    public int Views { get; set; }
    public int Keeps { get; set; }
    public int Shares { get; set; }

  }
}
// Needs to be marked private by utilizing a bool to switch from from true and false. 