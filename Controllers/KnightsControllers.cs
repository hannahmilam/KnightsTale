using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace KnightsTale
{
    [ApiController]
    [Route("api/[controller]")]
  public class KnightsController : ControllerBase
  {
      private readonly KnightsService _ks;
      public KnightsController(KnightsService ks)
      {
        _ks = ks;
      }

      [HttpGet]
      public ActionResult<List<KnightsController>> GetKnights()
      {
        try
        {
           var knights = _ks.Get();
           return Ok(knights);
        }
        catch (System.Exception e)
        {
          return BadRequest(e.Message);
        }
      }

      [HttpGet("{knightId}")]
      public ActionResult<Knight> GetKnightById(int knightId)
      {
        try
        {
           var knight = _ks.Get(knightId);
            return Ok(knight);  
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
      }
      [HttpPost]
      public ActionResult<Knight> CreateKnight([FromBody] Knight knightData)
      {
        try
        {
             var knight = _ks.CreateKnight(knightData);
             return Ok(knight);
        }
        catch (System.Exception e)
        {
          return BadRequest(e.Message);
        }
      }
      [HttpPut("{knightId}")]
      public ActionResult<Knight> EditKnight(int knightId, [FromBody] Knight knightData)
      {
        try
        {
             var knight = _ks.EditKnight(knightId, knightData);
             return Ok(knight);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
      }

      [HttpDelete("{knightId}")]
      public ActionResult<Knight> DeleteKnight(int knightId)
      {
        try
        {
             var knight = _ks.DeleteCastle(knightId);
           return Ok(knight);
        }
        catch (System.Exception e)
        {
           return BadRequest(e.Message);
        }
      }

      
    }
  }