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

    //CREATE KEEP
    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, Img )
        VALUES (@Name, @Description, @Price);
        SELECT LAST_INSERT_ID();", keep // ask about this, I don't understand flow
      );
      keep.Id = id;
      return keep;
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



    public IEnumerable<Keep> GetKeepsByUserId(string id)
    {
      return _db.Query<Keep>(@"
        SELECT * FROM userkeeps
        INNER JOIN keeps ON keeps.id = userkeeps.keepId
        WHERE userId = @id
      ", new { id });
    }

    //     SELECT* FROM vaultkeeps vk
    // INNER JOIN keeps k ON k.id = vk.keepId
    // WHERE (vaultId = 2)

    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
    }


  }

}