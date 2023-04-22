using System;
using UnityEngine;

namespace Core.Containers
{
    [Serializable]
    [CreateAssetMenu(menuName = "Containers/SpritesContainer", fileName = "SpritesContainer")]
    public class SpritesContainer : ScriptableObject
    {
        public Sprite BombSprite;
        public Sprite EmptySprite;
        public Sprite MarkedSprite;
    }
}