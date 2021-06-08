using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUpdater : IUpdater
    {
        private StateController _stateController = null;

        public DefaultUpdater(StateController stateController)
        {
            _stateController = stateController;
        }

        public void CustomFixedUpdate()
        {
            _stateController.TransitionToNextState();
            _stateController.OnFixedUpdate();
        }

        public void CustomLateUpdate()
        {
            _stateController.OnLateUpdate();
        }
    }
}