using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace KnightsTale
{
  public class KnightsRepository
  {
    private readonly IDbConnection _db;
    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }
    public List<Knight> Get()
    {
      return _db.Query<Knight>("SELECT * FROM castles").ToList();
    }

    public Knight Get(int id)
    {
       return _db
      .QueryFirstOrDefault<Knight>("SELECT * FROM castles WHERE id = @id", new { id });
    }

    public Knight Create(Knight knightData)
    {
      var sql = @"
      INSERT INTO knights(
        name
        )
      VALUES (
          @Name
          );
          SELECT LAST _INSERT_ID();
          ";
          var id = _db.ExecuteScalar<int>(sql, knightData);
          knightData.Id = id;
          return knightData;
    }

    public Knight Edit(int id, Knight knightData)
    {
       knightData.Id = id;
      var sql = @"
      UPDATE knights
      SET
        name = @Name
      WHERE knightId = @Id
      ";
      var rowsAffected = _db.Execute(sql, knightData);

       if (rowsAffected > 1)
      {
        throw new System.Exception("ERROR ERROR ERROR ERROR");
      }
      if (rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
      return knightData;
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