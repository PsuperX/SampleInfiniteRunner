using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class EnterHostIPMessageHandler : BaseMessageHandler
    {
        public EnterHostIPMessageHandler()
        {

        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.HOST_IP_ENTERED)
                {
                    string ip = message.GetStringMessage();
                    Debugger.Log("host ip entered: " + ip);
                    RB.Client.ClientControl.CURRENT.SetHostIP(ip);

                    BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.CONNECTING_STAGE));
                }
            }
        }
    }
}