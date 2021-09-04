using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Wincing : UnitState
    {
        public LittleRed_Wincing(Unit unit, Vector2 pushForce, Unit attacker)
        {
            ownerUnit = unit;
            noHitStopAllowed = true;

            _listStateComponents.Add(new InitialPushBack(ownerUnit, pushForce, attacker));
            _listStateComponents.Add(new InitialTextGUIMaterial(ownerUnit, 8));
            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(ownerUnit, 0.1f));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_IDLE);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (fixedUpdateCount >= 20)
            {
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }
        }
    }
}