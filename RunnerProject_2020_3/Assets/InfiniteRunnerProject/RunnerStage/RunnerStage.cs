using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : Stage
    {
        public override void Init()
        {
            _userInput = new UserInput();
            _backgroundSetup = new SwampSetup();
            _backgroundSetup.InstantiateBaseLayer();

            InstantiateUnit_ByUnitType(UnitType.RUNNER);
            InstantiateUnits_ByUnitType(UnitType.GOLEM);

            Runner_NormalRun.initialPush = false;

            units.AddCreator(new FlatGround_Creator(this.transform));
            units.ProcessCreators();

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.GAME_UI)) as GameUI;
            _baseUI.transform.parent = this.transform;

            cameraScript = new CameraScript();
            cameraScript.SetCamera(FindObjectOfType<Camera>());
            cameraScript.SetCameraState(new Camera_FollowRunner());

            Unit runner = units.GetUnit<Runner>();
            cameraScript.SetTarget(runner.gameObject);

            _backgroundSetup.AddAdditionalBackground<Swamp_Grass_DefaultState>();
            _backgroundSetup.AddAdditionalBackground<Swamp_Grass_DefaultState>();
            _backgroundSetup.AddAdditionalBackground<Swamp_River_DefaultState>();
            _backgroundSetup.AddAdditionalBackground<Swamp_River_DefaultState>();
            _backgroundSetup.AddAdditionalBackground<Swamp_FrontTrees_DefaultState>();
            _backgroundSetup.AddAdditionalBackground<Swamp_FrontTrees_DefaultState>();
            _backgroundSetup.AddAdditionalBackground<Swamp_BackTrees_DefaultState>();
            _backgroundSetup.AddAdditionalBackground<Swamp_BackTrees_DefaultState>();
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            cameraScript.OnUpdate();
            _baseUI.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new RunnerStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();

            _baseUI.OnFixedUpdate();
            cameraScript.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
            _baseUI.OnLateUpdate();
            cameraScript.OnLateUpdate();
        }
    }
}