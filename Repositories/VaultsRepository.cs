using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{

  public class VaultsRepository
  {
    IDbConnection _db;
    public string TableName = "vaults";
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL VAULTS
    public IEnumerable<Vault> GetAll(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @userId;", new { userId });
    }

    //GET VAULT BY ID
    public Vault GetById(int id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE VAULT
    public Vault Create(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description, userId)
        VALUES (@Name, @Description, @UserId);
        SELECT LAST_INSERT_ID();", vault
      );
      vault.Id = id;
      return vault;
    }

    //UPDATE VAULT
    public Vault Update(Vault vault)
    {
      _db.Execute(@"
      UPDATE vaults SET (name, description, userId) 
      VALUES (@Name, @Description, @UserId)
      WHERE id = @Id
      ", vault);
      return vault;
    }

    //DELETE VAULT
    public Vault Delete(Vault vault)
    {
      _db.Execute("DELETE FROM vaults WHERE id = @Id", vault);
      return vault;
    }



    public IEnumerable<Vault> GetVaultsById(string id)
    {
      return _db.Query<Vault>(@"
        SELECT * FROM vaults WHERE userId = @id", new { id });
    }

    //     SELECT* FROM vaultkeeps vk
    // INNER JOIN keeps k ON k.id = vk.keepId
    // WHERE (vaultId = 2) //

    public bool Delete(int vaultId)
    {
      return _db.Execute("DELETE FROM vaults WHERE id = @vaultd", new { vaultId }) == 1;
    }
  }
}