using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaultKeeps.Repositories;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : Controller
  {
    VaultKeepsRepository _repo;
    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    [HttpGet("{vaultId}")]
    public IEnumerable<Keep> Get(string vaultId)
    {
      return _repo.GetAll(vaultId);
    }

    [Authorize]
    [HttpPost]
    public void Create([FromBody] VaultKeep vaultkeep)
    {
      vaultkeep.UserId = HttpContext.User.Identity.Name;
      if (ModelState.IsValid)
      {
        _repo.CreateVaultKeep(vaultkeep);
        return;
      }
      throw new Exception("INVALID VAULTKEEP");
    }

    [HttpPut]
    public void Delete([FromBody]VaultKeep vaultkeep)
    {
      if (ModelState.IsValid)
      {
        _repo.Delete(vaultkeep);
      }
    }
  }
}