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


    public string TableName = "keeps";
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL KEEPS
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>($"SELECT * FROM {TableName}");
    }

    //GET KEEP BY ID
    public Keep GetById(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id }).FirstOrDefault();
    }
    //CREATE KEEP
    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, Img, userId, isPrivate, views, shares, keeps)
        VALUES (@Name, @Description, @Img, @userId, @IsPrivate, @Views, @Shares, @keeps);
        SELECT LAST_INSERT_ID();", keep
      );
      keep.Id = id;
      return keep;
    }

    //UPDATE KEEP
    public void Update(Keep keep)
    {
      _db.Execute(@"
      UPDATE keeps SET views = @Views, shares = @Shares, keeps = @Keeps
      WHERE id = @Id
      ", keep);
    }

    //DELETE KEEP
    public bool Delete(int keepId)
    {
      return _db.Execute("DELETE FROM keeps WHERE id = @keepId", new { keepId }) == 1;
    }

    public IEnumerable<Keep> GetKeepsByUserId(string id)
    {
      return _db.Query<Keep>(@"
        SELECT * FROM keeps
        WHERE userid = @Id
      ", new { id });
    }

    //     SELECT* FROM vaultkeeps vk
    // INNER JOIN keeps k ON k.id = vk.keepId
    // WHERE (vaultId = 2) // ask about this, I don't totally understand.
  }
}