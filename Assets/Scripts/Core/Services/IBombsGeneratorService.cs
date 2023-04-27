using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public interface IBombsGeneratorService
    {
        IEnumerable<Vector2Int> Generate(int width, int height);
    }
}