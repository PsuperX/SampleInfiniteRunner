using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Jump_Up(Unit unit)
        {
            ownerUnit = unit;
        }

        public override void OnEnter()
        {
            ownerUnit.unitData.rigidBody2D.velocity = GameInitializer.current.gameDataSO.Runner_JumpUp_StartForce;
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.unitData.rigidBody2D.velocity.y < 0f && fixedUpdateCount >= 2)
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_Jump_Fall(ownerUnit));
            }

            FixedUpdateComponents();
        }

        public override void OnLateUpdate()
        {

        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}