using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StayNearWindowState : NPCState
{
    bool _StayNearWindowStarted;
    public override void Init()
    {
        _StayNearWindowStarted = true;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
        
        if (_StayNearWindowStarted)
        {

        }
    }
}
