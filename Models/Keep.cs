using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
  }
  public class Keep
  {
    public string UserId { get; set; }
    public int Id { get; set; }
    public string Img { get; set; }
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

    public Keep(string userId, string img, string name, string description) //needs these to create a keep
    {
      UserId = userId;
      Img = img;
      Name = name;
      Description = description;
    }
    public Keep() { }
  }
}

// public VaultKeep(string Id, string UserId, string VaultId, string KeepId) //needs these to create a vaultkeep
// {
//   Id = id;
//   UserId = userId;
//   VaultId = vaultId;
//   KeepId = keepId;
// }
// public VaultKeep() { }
//   }
// }

// use this for postman
// {
// 	"userId": "be57dce1-9311-42a3-bf11-c743e4e29fb6",
// 	"Img": "http://www.umbra.com/media/catalog/product/cache/8/small_image/1826x/9df78eab33525d08d6e5fb8d27136e95/u/m/umbra_HUB_MIRROR_358370-040_01.jpg",
// 	"name": "circular mirror",
// 	"description": "Potential mirror for home remodel."
// }

// Test User Id
// e435a03a-bba1-4348-b487-01358ff6ba70