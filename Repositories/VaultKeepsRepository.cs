using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace VaultKeeps.Repositories
{

  public class VaultKeepsRepository
  {
    private IDbConnection _db;
    public string TableName = "vaultkeeps";

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL VAULTKEEPS
    public IEnumerable<Keep> GetAll(string vaultId)
    {
      return _db.Query<Keep>("SELECT * FROM vaultkeeps vk INNER JOIN keeps k ON k.id = vk.keepId WHERE (vaultId = @vaultId);", new { vaultId });
    }

    //CREATE VAULTKEEP
    public void CreateVaultKeep(VaultKeep vaultkeep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (userId, vaultId, keepId)
        VALUES (@UserId, @VaultId, @KeepId);
        SELECT LAST_INSERT_ID();", vaultkeep
      );
      return;
    }

    //UPDATE VAULTKEEP
    public VaultKeep Update(VaultKeep vaultkeep)
    {
      _db.Execute(@"
      UPDATE vaultkeeps SET (vaultId, userId, keepId) 
      VALUES (@VaultId, @KeepId, @UserId)
      WHERE id = @Id
      ", vaultkeep);
      return vaultkeep;
    }

    //DELETE VAULTKEEP
    internal void Delete(VaultKeep vaultkeep)
    {
      _db.Execute("DELETE FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @VaultId", vaultkeep);
    }

    //     SELECT* FROM vaultkeeps vk
    // INNER JOIN keeps k ON k.id = vk.keepId
    // WHERE (vaultId = 2) // ask about this, I don't totally understand.
  }
}