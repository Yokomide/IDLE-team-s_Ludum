using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SittingNPCState : NPCState
{
    bool _isSitStarted;
    public override void Init()
    {
        _isSitStarted = true;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
        
        if (_isSitStarted)
        {
            
        }
    }
}
