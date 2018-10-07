using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public string Img { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Views { get; set; }
    public int Keeps { get; set; }
    public int Shares { get; set; }

  }
}
// Needs to be marked private by utilizing a bool to switch from from true anfd false. 