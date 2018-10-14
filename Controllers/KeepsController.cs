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
  public class KeepsController : Controller
  {
    KeepsRepository _repo;
    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<Keep> Get()
    {
      return _repo.GetAll();
    }

    // [HttpGet("{userid}")]
    // public IEnumerable<Keep> Get(string userid)
    // {
    //   userid = HttpContext.User.Identity.Name;
    //   return _repo.GetById(userid);
    // }

    [HttpPut("{id}")]
    public void UpdateKeep([FromBody] Keep keep)
    {
      if (ModelState.IsValid)
      {
        _repo.Update(keep);
        return;
      }
      throw new Exception("INVALID KEEP");
    }

    [Authorize]
    [HttpPost]
    public Keep Post([FromBody] Keep keep)
    {
      if (ModelState.IsValid)
      {
        keep.UserId = HttpContext.User.Identity.Name;
        return _repo.Create(keep);
      }
      throw new Exception("INVALID KEEP");
    }

    [HttpDelete("{id}")]
    public void Delete([FromRoute] int Id)
    {
      _repo.Delete(Id);
    }

  }

}