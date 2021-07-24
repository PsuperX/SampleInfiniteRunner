using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class HitStop_Message : BaseMessage
    {
        uint _totalHitStopFrames = 0;
        UnitType _targetUnitType = UnitType.NONE;

        public HitStop_Message(uint totalHitStopFrames, UnitType targetUnitType)
        {
            _totalHitStopFrames = totalHitStopFrames;
            mMessageType = MessageType.HITSTOP_REGISTER;
            _targetUnitType = targetUnitType;
        }

        public override void Register()
        {
            GameInitializer.current.RunCoroutine(_register());
        }

        IEnumerator _register()
        {
            Debugger.Log("waiting 1 frame before register");
        
            yield return new WaitForEndOfFrame();

            Stage.currentStage.units.unitsMessageHandler.Register(this);
        }

        public override uint GetUnsignedIntMessage()
        {
            return _totalHitStopFrames;
        }

        public override UnitType GetUnitTypeMessage()
        {
            return _targetUnitType;
        }
    }
}