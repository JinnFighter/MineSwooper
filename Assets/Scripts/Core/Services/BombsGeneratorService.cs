using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public class BombsGeneratorService : IBombsGeneratorService
    {
        private readonly float _bombGenerationChance = 0.3f;

        public IEnumerable<Vector2Int> Generate(int width, int height)
        {
            var result = new List<Vector2Int>();
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                if (Random.Range(0f, 1f) < _bombGenerationChance)
                    result.Add(new Vector2Int(i, j));

            return result;
        }
    }
}