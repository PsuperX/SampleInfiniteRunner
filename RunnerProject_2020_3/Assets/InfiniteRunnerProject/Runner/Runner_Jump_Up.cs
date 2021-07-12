using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        private UserInput _userInput = null;
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Jump_Up(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
        }

        public override void OnEnter()
        {
            _unit.unitData.rigidBody2D.velocity = GameInitializer.current.gameDataSO.Runner_JumpUp_StartForce;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.rigidBody2D.velocity.y < 0f && updateCount >= 2)
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Fall(_unit, _userInput));
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