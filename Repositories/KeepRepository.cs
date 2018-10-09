using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{

  public class KeepsRepository
  {
    private IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL KEEPS
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }

    //GET KEEP BY ID
    public Keep GetById(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id }).FirstOrDefault();
    }
    // GET KEEP BY VAULT ID

    public IEnumerable<Keep> GetbyVaultId(int id)
    {
      return _db.Query<Keep>("SELECT * FROM vaultkeeps vk INNER JOIN keep k ON k.id = vk.keepId WHERE (vaultId = @vaultId);");
    }
    //CREATE KEEP
    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, Img, userId)
        VALUES (@Name, @Description, @Img, @userId);
        SELECT LAST_INSERT_ID();", keep // ask about this, I don't understand flow
      );
      keep.Id = id;
      return keep;
    }
    public VaultKeep CreateVaultKeep(VaultKeep vaultkeep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (id, userId, vaultId, keepId)
        VALUES (@Id, @UserId, @VaultId, @KeepId);
        SELECT LAST_INSERT_ID();", vaultkeep
      );
      vaultkeep.Id = id;
      return vaultkeep;
    }

    //UPDATE KEEP
    public Keep Update(Keep keep)
    {
      _db.Execute(@"
      UPDATE keeps SET (name, description, Img) 
      VALUES (@Name, @Description, @Price)
      WHERE id = @Id
      ", keep);
      return keep;
    }

    //DELETE KEEP
    public Keep Delete(Keep keep)
    {
      _db.Execute("DELETE FROM keeps WHERE id = @Id", keep);
      return keep;
    }

    //DELETE VAULTKEEP

    public VaultKeep Delete(VaultKeep vaultkeep)
    {
      _db.Execute("DELETE FROM vaultkeeps WHERE vaultkeepid = @Id", vaultkeep);
      return vaultkeep;
    }

    public IEnumerable<Keep> GetKeepsByUserId(string id)
    {
      return _db.Query<Keep>(@"
        SELECT * FROM userkeeps
        INNER JOIN keeps ON keeps.id = userkeeps.keepId
        WHERE id = @userId
      ", new { id });
    }

    //     SELECT* FROM vaultkeeps vk
    // INNER JOIN keeps k ON k.id = vk.keepId
    // WHERE (vaultId = 2) // ask about this, I don't totally understand.

    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
    }
  }
}