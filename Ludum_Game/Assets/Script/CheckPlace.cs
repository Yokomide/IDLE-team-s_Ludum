using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlace : MonoBehaviour
{
    public List<GameObject> food = new List<GameObject>();
    public GameObject butch;
    public bool canPlace;
    void OnTriggerEnter2D(Collider2D other)
    {
        canPlace = false;
        if (food.Count != 3)
        {
            if ((other.CompareTag("Meat") || other.CompareTag("Rice") || other.CompareTag("Tomato")))
            {
                if (food.Count == 0)
                {
                    Debug.Log("Вошёл1");
                    food.Add(other.gameObject);
                    canPlace = true;
                }

                if (food.Count == 1)
                {
                    if (!(other.tag == food[0].tag))
                    {
                        Debug.Log("Вошёл2");
                        food.Add(other.gameObject);
                        canPlace = true;
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
                    }
                    else
                    {
                        Debug.Log("Повтор2");
                    }
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (canPlace == true)
        {
            if (other.GetComponent<DragDrop>().isDragging == false)
            {
                foreach (var item in food)
                {
                    item.GetComponent<DragDrop>().isCooking = false;
                }

            }
        }
    }

    void Update()
    {
        if (butch.GetComponent<ButcherWork>().cookProgress == 10)
        {
            foreach (var item in food)
            {
                Destroy(item);
            }
            food.Clear();
            butch.GetComponent<ButcherWork>().isOnTable = false;
        }
        if (food.Count == 3)
        {
            butch.GetComponent<ButcherWork>().isOnTable = true;
        }
    }
}
