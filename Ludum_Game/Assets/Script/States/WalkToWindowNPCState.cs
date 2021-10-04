
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WalkToWindowNPCState : NPCState
{
    bool _isWalkToWindowStarted;
    public override void Init()
    {
        _isWalkToWindowStarted = true;
    }

    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
        if (_isWalkToWindowStarted)
        {
            NPCController.gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = NPCController.Window.transform;
        }
    }
}
