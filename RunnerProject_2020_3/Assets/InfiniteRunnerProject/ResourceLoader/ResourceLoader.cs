using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class ResourceLoader
    {
        public static StageLoader stageLoader = null;
        public static LevelLoader levelLoader = null;
        public static etcLoader etcLoader = null;
        public static UnitLoader unitLoader = null;
        public static UILoader_RunnerStage uiLoader = null;
        public static UIElementLoader_RunnerStage uiElementLoader = null;

        static Dictionary<string, Sprite[]> _dicSpriteSets = new Dictionary<string, Sprite[]>();

        public static void Init()
        {
            stageLoader = new StageLoader();
            levelLoader = new LevelLoader();
            etcLoader = new etcLoader();
            unitLoader = new UnitLoader();
            uiLoader = new UILoader_RunnerStage();
            uiElementLoader = new UIElementLoader_RunnerStage();

            _dicSpriteSets.Clear();
        }

        public static void LoadRunnerStage()
        {
            unitLoader.LoadRunnerStageUnits();

        }

        public static void LoadFightStage()
        {
            unitLoader.LoadFightStageUnits();
        }

        //introduce array of spritenames, index defined in spec
        public static Sprite[] LoadSpriteBySpec(SpriteAnimationSpec spec)
        {
            Sprite[] arrSprite = LoadSpriteByString(spec.spriteName);

            if (arrSprite.Length == 0)
            {
                arrSprite = LoadSpriteByString(spec.backupSpriteName);
            }

            return arrSprite;
        }

        public static Sprite[] LoadSpriteByString(string spriteName)
        {
            if (_dicSpriteSets.ContainsKey(spriteName))
            {
                return _dicSpriteSets[spriteName];
            }
            else
            {
                Sprite[] arrSprites = Resources.LoadAll<Sprite>(spriteName);

                if (arrSprites.Length > 0)
                {
                    _dicSpriteSets.Add(spriteName, arrSprites);
                }

                return arrSprites;
            }
        }
    }
}