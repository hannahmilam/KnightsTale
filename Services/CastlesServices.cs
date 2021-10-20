using System;
using System.Collections.Generic;

namespace KnightsTale
{
  public class CastlesService
  {
    private readonly CastlesRepository _cr;
    public CastlesService(CastlesRepository cr)
    {
      _cr = cr;
    }
    public List<Castle> Get()
    {
      return _cr.Get();
    }

    public Castle Get(int castleId)
    {
      var castle = _cr.Get(castleId);
      if(castle == null)
      {
        throw new SystemException("Invalid Castle Id");
      }
      return castle;
    }

    public Castle CreateCastle(Castle castleData)
    {
      return _cr.Create(castleData);
    }

    public Castle EditCastle(int castleId, Castle castleData)
    {
      var castle = Get(castleId);
      castle.Kingdom = castleData.Kingdom ?? castle.Kingdom;
      castle.Name = castleData.Name ?? castle.Name;
      
      _cr.Edit(castleId, castleData);
      return castle;
    }

    public Castle DeleteCastle(int castleId)
    {
      var castle = Get(castleId);
      _cr.Delete(castleId);
      return castle;
    }
  }
}