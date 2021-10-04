using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{ 
    [Header("Actual Target")]
    public GameObject SelectedTarget; 

    [Header("Targets")]
    public GameObject SitPlace;
    public GameObject Window;

    [Header("Initial Parameters")]

    public float patience = 20f;
    [SerializeField]public float tempPatience;

    public float timeNearWindow = 20f;
    [SerializeField]public float tempTimeNearWindow;

    [Header("Actual state")]
    public NPCState CurrentNPCState;
    [Header("States")]
    public NPCState StartNPCState;
    public NPCState EatNPCState;
    public NPCState SittingNPCState;
    public NPCState StayNearWindowState;
    public NPCState WalkToWindowNPCState;
    public NPCState WalkToSitPlaceNPCState;

    public void Start()
    {
        tempPatience = patience;
        tempTimeNearWindow = timeNearWindow;
        SetState(StartNPCState);
    }

    public void Update()
    {
        CheckPatience();
        CheckSit();
        CheckNearWindow();
        CheckTimeNearWindow();
        

        if (!CurrentNPCState.IsFinished)
        {
            CurrentNPCState.Run();
        }
    }

    public void CheckSit()
    {
        if (CurrentNPCState == WalkToSitPlaceNPCState && Vector2.Distance(SitPlace.transform.position, transform.position)<0.4)
        {
            gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = gameObject.transform;
            SetState(SittingNPCState);
        }
    }

    public void CheckNearWindow()
    {
        if (CurrentNPCState == WalkToWindowNPCState && Vector2.Distance(Window.transform.position, transform.position)<0.4)
        {
            SetState(StayNearWindowState);
        }
    }

    public void CheckTimeNearWindow()
    {
        if(CurrentNPCState == StayNearWindowState){
            DecreaseTimeNearWindow();
            if (tempTimeNearWindow <=0)
            {
                tempPatience = patience;
                tempTimeNearWindow = timeNearWindow;
                SetState(WalkToSitPlaceNPCState);
            }
        }
        
    }
    
    public void CheckPatience()
    {
        if (tempPatience > 0f && CurrentNPCState == SittingNPCState)
        {
            DecreasePatience(); 
        }
        else if (tempPatience <= 0f)
        {
            SetState(WalkToWindowNPCState);
        }
    }
    
    public void SetState(NPCState npcState)
    {
        CurrentNPCState = npcState;
        CurrentNPCState.NPCController = this;
        CurrentNPCState.Init();
    }
    
    public void DecreasePatience()
    {
        tempPatience -= Time.deltaTime;
    }

    public void DecreaseTimeNearWindow()
    {
        tempTimeNearWindow -= Time.deltaTime;
    }
}
