using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Wincing : UnitState
    {
        public Runner_Wincing(Unit unit, Vector2 pushForce, Unit attacker)
        {
            ownerUnit = unit;
            noHitStopAllowed = true;

            _listStateComponents.Add(new InitialPushBack(this, pushForce, attacker));
            _listStateComponents.Add(new InitialTextGUIMaterial(this, 15));
            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(this, 0.1f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_WINCING);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (fixedUpdateCount >= 20)
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun());
            }
        }
    }
}