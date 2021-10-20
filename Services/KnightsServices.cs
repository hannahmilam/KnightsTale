using System;
using System.Collections.Generic;

namespace KnightsTale
{
  public class KnightsService
  {
    private readonly KnightsRepository _kr;
    public KnightsService(KnightsRepository kr)
    {
      _kr = kr;
    }
    public List<Knight> Get()
    {
      return _kr.Get();
    }

    public Knight Get(int knightId)
    {
      var knight = _kr.Get(knightId);
      if(knight == null)
      {
        throw new SystemException("Invalid Knight Id");
      }
      return knight;
    }

    public Knight CreateKnight(Knight knightData)
    {
      return _kr.Create(knightData);
    }

    public Knight EditKnight(int knightId, Knight knightData)
    {
       var knight= Get(knightId);
      knight.Name = knightData.Name ?? knight.Name;
      
      _kr.Edit(knightId, knightData);
      return knight;
    }

    public Knight DeleteCastle(int knightId)
    {
      var knight = Get(knightId);
      _kr.Delete(knightId);
      return knight;
    }
  }
}