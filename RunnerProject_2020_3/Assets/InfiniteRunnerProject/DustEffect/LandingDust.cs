using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LandingDust : Unit
    {
        public override void OnFixedUpdate()
        {
            iStateController.OnFixedUpdate();
            unitData.spriteAnimations.OnFixedUpdate();
        }
    }
}