using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseNPCSetup
    {
        protected BaseStage _stage = null;
        protected BaseUpdater _updater = null;

        public abstract void OnFixedUpdate();
    }
}