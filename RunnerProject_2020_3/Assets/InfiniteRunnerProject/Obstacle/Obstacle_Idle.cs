using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle_Idle : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_White100x100");

        private Unit _runner = null;

        public Obstacle_Idle(UnitData data, Unit runner)
        {
            _unitData = data;
            _runner = runner;
        }

        public override void OnEnter()
        {

        }

        public override void Update()
        {
            if (_runner.transform.position.x >= _unitData.unitTransform.position.x + 15f)
            {
                _unitData.shouldDestroy = true;
                _unitData.unitTransform.position = new Vector3(0f, 1f, 1f);
            }
        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}