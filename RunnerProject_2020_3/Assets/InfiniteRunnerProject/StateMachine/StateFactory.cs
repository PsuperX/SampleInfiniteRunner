using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "StateFactory", menuName = "InfiniteRunner/StateFactory/StateFactory")]
    public class StateFactory : ScriptableObject
    {
        public void New_Runner_Idle(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Runner_Idle(unit, userInput));
        }

        public void New_Golem_Idle(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Golem_Idle(unit));
        }

        public void New_Swamp_Grass(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Swamp_Grass_DefaultState(unit));
        }

        public void New_Swamp_River(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Swamp_River_DefaultState(unit));
        }

        public void New_Swamp_FrontTrees(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Swamp_FrontTrees_DefaultState(unit));
        }

        public void New_Swamp_BackTrees(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Swamp_BackTrees_DefaultState(unit));
        }

        public void New_LandingDust(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new LandingDust_DefaultState(unit));
        }

        public void New_StepDust(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new StepDust_DefaultState(unit));
        }

        public void New_Blood_5(Unit unit, UserInput userInput)
        {
            unit.iStateController.SetNewState(new Blood_5_DefaultState(unit));
        }
    }
}