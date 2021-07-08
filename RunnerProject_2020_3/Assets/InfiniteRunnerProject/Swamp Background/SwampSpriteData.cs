using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/SwampSpriteData")]
    public class SwampSpriteData : ScriptableObject
    {
        public string Swamp_Grass_SpriteName;
        public Vector3 Swamp_Grass_StartPos;
        [Range(0f, 1f)] public float Swamp_Grass_ParallaxPercentage;

        [Space(20)]

        public string Swamp_River_SpriteName;
        public Vector3 Swamp_River_StartPos;
        [Range(0f, 1f)] public float Swamp_River_ParallaxPercentage;

        [Space(20)]

        public string Swamp_FrontTrees_SpriteName;
        public Vector3 Swamp_FrontTrees_StartPos;
        [Range(0f, 1f)] public float Swamp_FrontTrees_ParallaxPercentage;

        [Space(20)]

        public string Swamp_BackTrees_SpriteName;
        public Vector3 Swamp_BackTrees_StartPos;
        [Range(0f, 1f)] public float Swamp_BackTrees_ParallaxPercentage;

        [Space(20)]

        public string Swamp_BackgroundColor_SpriteName;
        public Vector3 Swamp_BackgroundColor_StartPos;
        [Range(0f, 1f)] public float Swamp_BackgroundColor_ParallaxPercentage;

        [Space(20)]

        public uint Swamp_Unified_SpriteInterval = new uint();
        public Vector2 Swamp_Unified_SpriteSize = new Vector2();

        [Space(20)]
        public string Swamp_GroundTile25_SpriteName;
    }
}