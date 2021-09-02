using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpVerticalSpeed_Air : StateComponent
    {
        float _targetForce = 0f;
        float _percentagePerUpdate = 0f;

        public LerpVerticalSpeed_Air(Unit unit, float targetForce, float percentagePerUpdate)
        {
            _unit = unit;
            _targetForce = targetForce;
            _percentagePerUpdate = percentagePerUpdate;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                float dif = _unit.unitData.rigidBody2D.velocity.y - _targetForce;

                if (Mathf.Abs(dif) > 0.001f)
                {
                    float y = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.y, _targetForce, _percentagePerUpdate);
                    _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.rigidBody2D.velocity.x, y);
                }
            }
        }
    }
}