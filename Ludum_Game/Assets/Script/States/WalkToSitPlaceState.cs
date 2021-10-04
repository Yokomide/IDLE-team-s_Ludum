using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WalkToSitPlaceState : NPCState
{
    bool _isWalkToSitPlaceStarted;
    public override void Init()
    {
        _isWalkToSitPlaceStarted = true;
    }
    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
        
        if (_isWalkToSitPlaceStarted)
        {
            NPCController.gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = NPCController.SitPlace.transform;
        }
    }
}
