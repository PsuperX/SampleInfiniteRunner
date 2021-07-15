using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GolemMessageHandler : BaseMessageHandler
    {
        private Unit _unit = null;
        private bool zeroHealthTriggered = false;

        public GolemMessageHandler(Unit unit)
        {
            _unit = unit;
        }

        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.WINCE)
                {
                    _unit.unitData.listNextStates.Add(new Golem_Wincing(_unit));
                }
                else if (message.MESSAGE_TYPE == MessageType.TAKE_DAMAGE)
                {
                    _unit.unitData.hp -= message.GetIntMessage();

                    if (_unit.hpBar == null)
                    {
                        HPBar bar = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.HP_BAR)) as HPBar;
                        _unit.hpBar = bar;
                        bar.transform.parent = Stage.currentStage.transform;
                        bar.SetOwnerUnit(_unit, new Vector2(-1.26f, 4.66f));
                    }
                }
                else if (message.MESSAGE_TYPE == MessageType.ZERO_HEALTH)
                {
                    if (!zeroHealthTriggered)
                    {
                        zeroHealthTriggered = true;
                        _unit.unitData.listNextStates.Add(new Golem_Death(_unit));
                    }

                    if (_unit.hpBar != null)
                    {
                        GameObject.Destroy(_unit.hpBar.gameObject);
                        _unit.hpBar = null;
                    }
                }
            }
        }
    }
}