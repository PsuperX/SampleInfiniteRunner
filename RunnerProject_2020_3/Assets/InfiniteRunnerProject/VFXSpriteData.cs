using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/VFXSpriteData")]
    public class VFXSpriteData : ScriptableObject
    {
        public string LandingDust_SpriteName;
        public uint LandingDust_SpriteInterval = new uint();
        public Vector2 LandingDust_SpriteSize = new Vector2();
    }
}