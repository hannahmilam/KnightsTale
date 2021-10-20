using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace KnightsTale
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;
    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Castle> Get()
    {
      return _db.Query<Castle>("SELECT * FROM castles").ToList();
    }

    public Castle Get(int id)
    {
      return _db
      .QueryFirstOrDefault<Castle>("SELECT * FROM castles WHERE id = @id", new { id });
    }

    public Castle Create(Castle castleData)
    {
      var sql = @"
      INSERT INTO castles(
        name,
        kingdom
        )
      VALUES (
          @Name,
          @Kingdom
          );
          SELECT LAST _INSERT_ID();
          ";
          var id = _db.ExecuteScalar<int>(sql, castleData);
          castleData.Id = id;
          return castleData;
      
    }

    public Castle Edit(int id, Castle castleData)
    {
      castleData.Id = id;
      var sql = @"
      UPDATE castles
      SET
        name = @Name,
        kingdom = @Kingdom
      WHERE castleId = @Id
      ";
      var rowsAffected = _db.Execute(sql, castleData);

       if (rowsAffected > 1)
      {
        throw new System.Exception("ERROR ERROR ERROR ERROR");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
      return castleData;
      
    }

    public void Delete(int id)
    {
      var rowsAffected = _db.Execute("DELETE FROM castles WHERE id = @id", new { id });

      if (rowsAffected > 1)
      {
        throw new System.Exception("ERROR ERROR ERROR ERROR");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
    }
  }
}
}