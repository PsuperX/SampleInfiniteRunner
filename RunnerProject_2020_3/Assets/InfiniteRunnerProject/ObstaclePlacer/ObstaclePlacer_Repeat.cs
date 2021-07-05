using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ObstaclePlacer_Repeat : State
    {
        private Unit _runner = null;
        private GameStage _gameStage = null;

        public ObstaclePlacer_Repeat(Unit unit, Unit runner, GameStage gameStage)
        {
            _unit = unit;
            _runner = runner;
            _gameStage = gameStage;
        }

        public override void SetHashString()
        {

        }

        public override void OnFixedUpdate()
        {
            Debugger.Log("creating an obstacle..");
            _gameStage.units.AddCreator(new ObstacleCreator(_gameStage.transform, _runner));
        }
    }
}