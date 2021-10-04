using System.Collections.Generic;
using UnityEngine;

public class Conveer : MonoBehaviour
{
    [Header("Ingredients prefabs")]
    public GameObject Meat;
    public GameObject Potato;
    public GameObject Rice;
    public GameObject Tomato;
    public GameObject RottenMeat;
    public GameObject Shrooms;
    public GameObject RottenShroom;
    public GameObject Sauce;
    public GameObject RottenPotato;

    public static Conveer current;

    [HideInInspector] public GameObject tempGameObject;

    [Header("Position for Lerp")]
    public GameObject StartPos_Meat;
    public GameObject EndPos_Meat;

    [Header("Time")]
    public float timeForLerp = 3f;
    public float temp_timeForLerp;

    public float timeSpawn = 3f;
    public float temp_timeSpawn;

    [HideInInspector] public List<GameObject> foodGameObjectList;

    public List<string> listtest;

    public void Start()
    {
        current = this;
        temp_timeSpawn = timeSpawn;
        temp_timeForLerp = timeForLerp;
        foodGameObjectList = new List<GameObject>();
        AcceptFoodList(listtest);
    }

    public void Update()
    {
        temp_timeForLerp -= Time.deltaTime;
        temp_timeSpawn -= Time.deltaTime;
        if (temp_timeSpawn <= 0)
        {
            InstantiateFoodList();
            temp_timeSpawn = timeSpawn;
            temp_timeForLerp = timeForLerp;

        }

        if (tempGameObject != null)
        {
            if (tempGameObject.GetComponent<FoodScript>().isCollided == true)
            {
                tempGameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                tempGameObject = null;
            }
            try { tempGameObject.transform.position = Vector2.Lerp(EndPos_Meat.transform.position, StartPos_Meat.transform.position, temp_timeForLerp); }
            catch { }
            if (temp_timeForLerp <= 0)
            {
                tempGameObject = null;
            }
        }
    }

    public void InstantiateFoodList()
    {

        if (foodGameObjectList.Count == 0)
        {
            Debug.Log("Food not be found");
            return;
        }
        foreach (var foodObject in foodGameObjectList)
        {
            tempGameObject = Instantiate(foodObject, StartPos_Meat.transform.position, Quaternion.identity);
            foodGameObjectList.Remove(foodObject);

            break;
        }
    }

    public void AcceptFoodList(List<string> foodNameList)
    {
        foreach (var foodName in foodNameList)
        {
            switch (foodName)
            {
                case "Meat":
                    foodGameObjectList.Add(Meat);
                    break;
                case "Potato":
                    foodGameObjectList.Add(Potato);
                    break;
                case "Shrooms":
                    foodGameObjectList.Add(Shrooms);
                    break;
                case "Sauce":
                    foodGameObjectList.Add(Sauce);
                    break;
                case "RottenShroom":
                    foodGameObjectList.Add(RottenShroom);
                    break;
                case "RottenPotato":
                    foodGameObjectList.Add(RottenPotato);
                    break;
                case "Rice":
                    foodGameObjectList.Add(Rice);
                    break;
                case "Tomato":
                    foodGameObjectList.Add(Tomato);
                    break;
                case "RottenMeat":
                    foodGameObjectList.Add(RottenMeat);
                    break;
            }
        }
    }
}
