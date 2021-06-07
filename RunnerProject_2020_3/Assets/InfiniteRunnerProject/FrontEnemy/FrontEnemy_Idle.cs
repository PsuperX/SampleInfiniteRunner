using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FrontEnemy_Idle : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_Front_Enemy_Sample");

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public FrontEnemy_Idle(UnitData data)
        {
            _unitData = data;
        }

        public override void OnFixedUpdate()
        {

        }
    }
}