using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveer : MonoBehaviour
{
    public GameObject Meat;
    GameObject tempMeat;
    public float timeForLerp = 2f;
    public GameObject StartPos_Meat;
    public GameObject EndPos_Meat;
    public float timeSpawn_Meat = 3f;
    [HideInInspector]public float temp_timeSpawn_Meat;

    public void Start()
    {
        temp_timeSpawn_Meat = timeSpawn_Meat;
    }

    public void Update()
    {
        timeForLerp -= Time.deltaTime;
        temp_timeSpawn_Meat -= Time.deltaTime;
        if (temp_timeSpawn_Meat <= 0)
        {
            tempMeat = Instantiate(Meat, StartPos_Meat.transform.position, Quaternion.identity);
            temp_timeSpawn_Meat = timeSpawn_Meat;
            timeForLerp = 2f;
            
        }
        if (tempMeat != null)
        {
           tempMeat.transform.position = Vector2.Lerp(EndPos_Meat.transform.position, StartPos_Meat.transform.position, timeForLerp);
        }
    }
}
