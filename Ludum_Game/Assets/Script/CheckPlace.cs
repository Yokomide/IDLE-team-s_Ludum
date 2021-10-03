using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlace : MonoBehaviour
{
    public List<GameObject> food = new List<GameObject>();
    public GameObject butch;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meat"))
            {
            Debug.Log("Вошёл");
            food.Add(other.gameObject);
            
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Meat"))
        {
            if (other.GetComponent<DragDrop>().isDragging == false)
            {
                other.GetComponent<DragDrop>().isCooking = false;
                butch.GetComponent<ButcherWork>().isOnTable = true;
                
                return;
            }
        }
    }
    void Start()
    {
    }
    void Update()
    {
        
    }
}
