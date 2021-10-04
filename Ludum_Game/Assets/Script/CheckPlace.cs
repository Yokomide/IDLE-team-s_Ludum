using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlace : MonoBehaviour
{
    public List<GameObject> food = new List<GameObject>();
    public List<string> foodTags = new List<string>();
    public GameObject butch;
    public bool canPlace;
    void OnTriggerEnter2D(Collider2D other)
    {
        canPlace = false;
        if (food.Count != 3)
        {
            if ((other.CompareTag("Meat") || other.CompareTag("Rice") || other.CompareTag("Tomato") || other.CompareTag("Potato"))|| (other.CompareTag("RottenMeat")))
            {
                if (food.Count == 0)
                {
                    Debug.Log("Вошёл1");
                    food.Add(other.gameObject);
                    foodTags.Add(other.tag);
                    canPlace = true;
                }

                if (food.Count == 1)
                {
                    if (!(other.tag == food[0].tag))
                    {
                        Debug.Log("Вошёл2");
                        food.Add(other.gameObject);
                        canPlace = true;
                        foodTags.Add(other.tag);
                    }
                    else
                    {
                        Debug.Log("Повтор1");
                    }
                }
                if (food.Count == 2)
                {
                    if (!(other.tag == food[0].tag) && !(other.tag == food[1].tag))
                    {
                        Debug.Log("Вошёл3");
                        food.Add(other.gameObject);
                        canPlace = true;
                        foodTags.Add(other.tag);
                    }
                    else
                    {
                        Debug.Log("Повтор2");
                    }
                }
            }
        }
    }

    void Update()
    {
        if (butch.GetComponent<ButcherWork>().cookProgress == 10 && butch.GetComponent<ButcherWork>().isDelivery == false)
        {
            foreach (var item in food)
            {
                Destroy(item);
            }
            food.Clear();
            foodTags.Clear();
            butch.GetComponent<ButcherWork>().isOnTable = false;
        }
        if (food.Count == 3)
        {
            butch.GetComponent<ButcherWork>().isOnTable = true;
        }
        foreach (var item in food)
        {
            if (canPlace == true)
            {
                if (item.GetComponent<DragDrop>().isDragging == false)
                {
                    item.GetComponent<DragDrop>().isCooking = false;
                }
            }
        }
    }
}
