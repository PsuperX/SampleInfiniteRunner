using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OnESC : UIElement
    {
        public override void InitElement()
        {

        }

        public override void OnUpdate()
        {
            InputController inputController = BaseInitializer.current.GetStage().GetInputController();
            UserInput userInput = inputController.GetUserInput(InputType.PLAYER_ONE);

            if (userInput.commands.ContainsPress(CommandType.ESCAPE, true))
            {
                if (_listChildElements.Count == 0)
                {
                    UIElement uiElement = AddChildElement(UIElementType.QUIT_GAME_ASK);
                }
                else
                {
                    foreach(UIElement element in _listChildElements)
                    {
                        Destroy(element.gameObject);
                    }

                    _listChildElements.Clear();
                }
            }

            OnUpdateChildElements();
        }

        public override void OnFixedUpdate()
        {
            OnFixedUpdateChildElements();
        }
    }
}