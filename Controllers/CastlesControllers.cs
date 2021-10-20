using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace KnightsTale
{
  [ApiController]
  [Route("api/[controller]")]
  public class CastlesController : ControllerBase
  {
    private readonly CastlesService _cs;

    public CastlesController(CastlesService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<CastlesController>> GetCastles()
    {
      try
      {
           var castles = _cs.Get();
           return Ok(castles);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{castleId}")]
    public ActionResult<Castle> GetCastleById(int castleId)
    {
      try
      {
           var castle = _cs.Get(castleId);
           return Ok(castle);
      }
      catch (System.Exception e)
      {
       return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Castle> CreateCastle([FromBody] Castle castleData)
    {
      try
      {
           var castle = _cs.CreateCastle(castleData);
           return Ok(castle);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{castleId}")]
    public ActionResult<Castle> EditCastle(int castleId, [FromBody] Castle castleData)
    {
      try
      {
          var castle = _cs.EditCastle(castleId, castleData);
          return Ok(castle); 
      }
      catch (System.Exception e)
      {
       return BadRequest(e.Message);
      }
    }
    [HttpDelete("{castleId}")]
    public ActionResult<Castle> DeleteCastle(int castleId)
    {
      try
      {
           var castle = _cs.DeleteCastle(castleId);
           return Ok(castle);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}