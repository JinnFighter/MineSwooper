using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public class GameFieldGeneratorService : IGameFieldGeneratorService
    {
        private readonly float _bombGenerationChance = 0.3f;

        public Dictionary<Vector2Int, IGameFieldGeneratorService.CellData> Generate(int width, int height)
        {
            var result = new Dictionary<Vector2Int, IGameFieldGeneratorService.CellData>();
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                var position = new Vector2Int(i, j);
                result.TryAdd(position, new IGameFieldGeneratorService.CellData());
                if (!(Random.Range(0f, 1f) < _bombGenerationChance)) continue;
                var valueTuple = result[position];
                valueTuple.HasBomb = true;

                for (var x = Mathf.Clamp(i - 1, 0, width); x <= Mathf.Clamp(i + 1, 0, width - 1); x++)
                for (var y = Mathf.Clamp(j - 1, 0, height); y <= Mathf.Clamp(j + 1, 0, height - 1); y++)
                {
                    var nearCell = new Vector2Int(x, y);
                    result.TryAdd(nearCell, new IGameFieldGeneratorService.CellData());
                    if (x == i && y == j) continue;

                    var tuple = result[nearCell];
                    tuple.BombsAroundCount++;
                }
            }

            return result;
        }
    }
}