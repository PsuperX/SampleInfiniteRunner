using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : Stage
    {
        private UserInput _userInput = new UserInput();

        public override void Init()
        {
            //InstantiateUnits_BySpecType<DefaultUnitCreationSpec>(_userInput);

            InstantiateUnit_ByUnitType(UnitType.RUNNER, _userInput);
            InstantiateUnits_ByUnitType(UnitType.SWAMP, null);
            InstantiateUnits_ByUnitType(UnitType.GOLEM, null);

            Unit runner = units.GetUnit<Runner>();
            Runner_NormalRun.initialPush = false;

            units.AddCreator(new CameraController_Creator(this.transform, runner, FindObjectOfType<Camera>()));
            units.AddCreator(new FlatGround_Creator(this.transform));

            units.ProcessCreators();
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.listStageTransitions.Add(new RunnerStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.listStageTransitions.Add(new IntroStageTransition(_gameIntializer));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
        }
    }
}