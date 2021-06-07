using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IStateController
    {
        public abstract void OnFixedUpdate();
        public abstract void SetNewState(State newState);
        public abstract void TransitionToNextState();
    }
}