using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Jump_Up : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        private bool _startPullDown = false;

        public LittleRed_Jump_Up(Unit unit)
        {
            ownerUnit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!_startPullDown)
            {
                if (!ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.JUMP))
                {
                    _startPullDown = true;
                }
            }
            else
            {
                if (ownerUnit.unitData.rigidBody2D.velocity.y > 0f)
                {
                    float y = Mathf.Lerp(ownerUnit.unitData.rigidBody2D.velocity.y, 0f, GameInitializer.current.fighterDataSO.JumpPullPercentagePerFixedUpdate);
                    ownerUnit.unitData.rigidBody2D.velocity = new Vector2(ownerUnit.unitData.rigidBody2D.velocity.x, y);
                }
            }
        }
    }
}