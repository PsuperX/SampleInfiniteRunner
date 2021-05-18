using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public class IntroStage : Stage
    {
        //public bool EnterPressed = false;

        Keyboard _keyboard = null;
        Camera _mainCam = null;

        public override void Init()
        {
            _keyboard = Keyboard.current;

            _mainCam = FindObjectOfType<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);
        }
        
        public override void OnUpdate()
        {
            if (_keyboard.enterKey.wasPressedThisFrame)
            {
                listStageMessages.Add(StageMessage.GOTO_GAME_STAGE);
                //EnterPressed = true;
            }
        }
    }
}