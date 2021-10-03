using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EatNPCState : NPCState
{
    bool _isEatStarted;
    public override void Init()
    {
        _isEatStarted = true;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
    }
}
