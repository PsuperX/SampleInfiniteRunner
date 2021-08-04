using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightStage : BaseStage
    {
        [SerializeField]
        private InputType _currentInputSelection = InputType.PLAYER_ONE;
        private InputType _prevInputSelection = InputType.NONE;

        public override void Init()
        {
            units = new Units(this);

            Physics2D.gravity = new Vector2(0f, BaseInitializer.current.fighterDataSO.Gravity);

            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.current.fighterDataSO.Camera_z);

            //load level 3 (oldcity)
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(3)) as GameObject;
            levelObj.transform.parent = this.transform;
            levelObj.transform.position = new Vector3(levelObj.transform.position.x, levelObj.transform.position.y, BaseInitializer.current.fighterDataSO.tempPlatforms_z);

            BaseInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_LIGHT);
            Unit player1 = units.GetUnit<LittleRed>();

            UserInput input = _inputController.AddInput();
            _currentInputSelection = input.INPUT_TYPE;
            _prevInputSelection = input.INPUT_TYPE;
            player1.SetUserInput(input);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(GetDefaultCameraState());
            cameraScript.SetFollowTarget(units.GetUnit<LittleRed>().gameObject);

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            Unit player2 = units.GetUnit<LittleRed>();
            player2.SetUserInput(_inputController.AddInput());

            //set z for all players
            List<Unit> allPlayers = units.GetUnits<LittleRed>();

            foreach(Unit player in allPlayers)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, BaseInitializer.current.fighterDataSO.Players_z);
            }
        }

        public override void OnUpdate()
        {
            _inputController.GetUserInput(_currentInputSelection).OnUpdate();
            cameraScript.OnUpdate();
            trailEffects.OnUpdate();
            units.OnUpdate();
            
            if (_inputController.GetUserInput(_currentInputSelection).commands.ContainsPress(CommandType.F5))
            {
                _gameIntializer.stageTransitioner.AddTransition(new FightStageTransition(_gameIntializer));
            }

            if (_inputController.GetUserInput(_currentInputSelection).commands.ContainsPress(CommandType.F6))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            if (_inputController.GetUserInput(_currentInputSelection).commands.ContainsPress(CommandType.F7))
            {
                _currentInputSelection++;

                if ((int)_currentInputSelection > _inputController.GetCount())
                {
                    _currentInputSelection = InputType.PLAYER_ONE;
                }
            }
        }

        public override void OnFixedUpdate()
        {
            cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();

            _inputController.GetUserInput(_currentInputSelection).commands.ClearKeyPressDictionary();
            _inputController.GetUserInput(_currentInputSelection).commands.ClearButtonPressDictionary();

            if (_currentInputSelection != _prevInputSelection)
            {
                _inputController.ClearAllKeysAndButtons();
                _prevInputSelection = _currentInputSelection;
            }
        }

        public override void OnLateUpdate()
        {
            cameraScript.OnLateUpdate();
            units.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.current.fighterDataSO.CumulativeGravityForcePercentage;
        }

        public override CameraState GetDefaultCameraState()
        {
            return new Camera_LerpOnTargetXAndY(0.08f, 0.08f);
        }
    }
}