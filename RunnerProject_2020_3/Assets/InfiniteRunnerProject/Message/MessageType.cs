using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum MessageType
    {
        NONE,

        RUNNER_IS_DEAD = 100,

        HITSTOP_REGISTER = 200,

        WINCE = 300,

        SHOW_BLOOD = 400,
    }
}