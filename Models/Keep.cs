using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public string UserId { get; set; }
    public int Id { get; set; }
    public string img { get; set; }
    [Required]
    [MinLength(6)]
    public string Name { get; set; }
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    public bool IsPrivate { get; set; } // Uses Tinyint and casts it with a bool to flip from logged out to logged in.
    public int Views { get; set; }
    public int Keeps { get; set; }
    public int Shares { get; set; }

    public Keep(string userId, string Img, string name, string description) //needs these to create a keep
    {
      UserId = userId;
      Img = img;
      Name = name;
      Description = description;
    }
    public Keep() { }
  }
}





