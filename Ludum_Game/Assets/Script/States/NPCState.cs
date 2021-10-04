using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCState : ScriptableObject
{
    public bool IsFinished {get ; protected set; }
    [HideInInspector]public NPCController NPCController {get ;  set; }
    public virtual void Init(){}
    public abstract void Run();
}
