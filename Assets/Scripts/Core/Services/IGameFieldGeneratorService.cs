using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public interface IGameFieldGeneratorService
    {
        Dictionary<Vector2Int, CellData> Generate(int width, int height);
        
        public class CellData
        {
            public bool HasBomb;
            public int BombsAroundCount;
        }
    }
}