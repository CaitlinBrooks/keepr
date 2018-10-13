// using System;
// using System.Collections.Generic;
// using keepr.Models;
// using keepr.Repositories;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// IS THIS ALL CORRECT? WORTH SPLITTING THEM OUT FROM KEEPS?



// namespace keepr.Controllers
// {
//   [Route("api/[controller]")]
//   [ApiController]
//   public class VaultKeepsController : Controller
//   {
//     VaultKeepsRepository _repo;
//     public KeepsController(KeepsRepository repo)
//     {
//       _repo = repo;
//     }

//     [HttpGet]
//     public IEnumerable<Keep> Get()
//     {
//       var keeps = _repo.GetAll();
//       return keeps;
//     }

//     [HttpGet("/vaultkeeps/{id}")]
//     public IEnumerable<Keep> Get(int id)
//     {
//       return _repo.GetbyVaultId(id);
//     }

//     [HttpGet("{userid}")]
//     public IEnumerable<Keep> Get(string userid)
//     {
//       userid = HttpContext.User.Identity.Name;
//       return _repo.GetById(userid);
//     }

//     [Authorize]
//     [HttpPost]
//     public Keep Post([FromBody] Keep keep)
//     {
//       if (ModelState.IsValid)
//       {
//         keep = new Keep(keep.UserId, keep.Img, keep.Name, keep.Description);
//         return _repo.Create(keep);
//       }
//       throw new Exception("INVALID KEEP");
//     }

//     [HttpDelete("{{id}}")]
//     public void Delete(int keepId)
//     {
//       _repo.Delete(keepId);
//     }

//   }

// }