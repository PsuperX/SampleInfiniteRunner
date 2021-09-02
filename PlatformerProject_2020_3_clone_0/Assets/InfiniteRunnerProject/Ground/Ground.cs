using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Ground : Unit
    {
        public override void OnUpdate()
        {
            unitUpdater.CustomUpdate();
        }
        
        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();
        }
    }
}