using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SampleLeftEnemy : Unit
    {
        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();
            unitData.spriteAnimations.OnFixedUpdate();
        }
    }
}