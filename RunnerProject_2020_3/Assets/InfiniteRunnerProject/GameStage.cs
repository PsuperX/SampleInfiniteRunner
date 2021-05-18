using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameStage : Stage
    {
        List<Unit> listUnits = new List<Unit>();

        private UI ui = null;

        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();
        private UserInput userInput = new UserInput();
        
        private bool restartGame = false;
        private bool returnToIntro = false;

        [SerializeField]
        private GameData gameDataScriptableObj = null;

        public bool RestartGame()
        {
            return restartGame;
        }

        public bool ReturnToIntro()
        {
            return returnToIntro;
        }

        public void Init()
        {
            StaticRefs.gameData = gameDataScriptableObj;

            RunnerCreator runnerCreator = new RunnerCreator(userInput, this.transform);
            Unit runner = runnerCreator.GetUnit();

            ObstacleCreator obstacleCreator = new ObstacleCreator(this.transform);
            Unit obstacle = obstacleCreator.GetUnit();

            CameraControllerCreator cameraCreator = new CameraControllerCreator(this.transform, runner, FindObjectOfType<Camera>());
            Unit cameraController = cameraCreator.GetUnit();

            listUnits.Add(runner);
            listUnits.Add(obstacle);
            listUnits.Add(cameraController);

            ui = Instantiate(ResourceLoader.Get(typeof(UI))) as UI;
            ui.SetCounters(fixedUpdateCounter, updateCounter);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;
        }

        public void OnUpdate()
        {
            updateCounter.OnUpdate();
            userInput.OnUpdate();
            ui.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            fixedUpdateCounter.OnFixedUpdate();

            foreach (Unit unit in listUnits)
            {
                unit.MatchAnimationToState();
                unit.OnFixedUpdate();
                
                if (unit.collisionDetector != null)
                {
                    bool clear = false;

                    foreach (GameObject obj in unit.collisionDetector.listCollidedGameObjects)
                    {
                        Debugger.Log(unit.gameObject.name + " detected collision");
                        unit.OnCollision();
                        clear = true;
                    }

                    if (clear)
                    {
                        unit.collisionDetector.listCollidedGameObjects.Clear();
                    }
                }
            }

            foreach(KeyPress press in userInput.listPresses)
            {
                if (press.keyCode == KeyCode.F5)
                {
                    restartGame = true;
                    returnToIntro = false;
                    break;
                }

                if (press.keyCode == KeyCode.F6)
                {
                    restartGame = false;
                    returnToIntro = true;
                    break;
                }
            }

            userInput.listPresses.Clear();
        }
    }
}