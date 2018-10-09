using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : Controller
  {
    VaultsRepository _repo;
    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }
    // Trying to get by userId, will need to do a getuservault?
    // [HttpGet("{UserId}")]

    // public IEnumerable<Vault> Get(){
    //   public IEnumerable<Vault> 
    // }

    [HttpGet]
    public IEnumerable<Vault> Get()
    {
      return _repo.GetAll();
    }

    [Authorize]
    [HttpPost]
    public Vault Post([FromBody] Vault vault)
    {
      if (ModelState.IsValid)
      {
        vault = new Vault(vault.UserId, vault.Name, vault.Description);
        return _repo.Create(vault);
      }
      throw new Exception("INVALID VAULT");
    }



  }
}