using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HostGame : UIOption
    {
        public override void OnEnterKey()
        {
            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.HOST_GAME_STAGE));
        }
    }
}