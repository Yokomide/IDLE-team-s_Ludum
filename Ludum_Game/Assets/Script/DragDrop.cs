using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour {

    public bool isDragging;
    public bool isCooking = true;

    private Collider2D _cl2D;
    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isCooking == true)
        {
            if (isDragging)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
                _cl2D.enabled = false;
            }
            if (!isDragging)
            {
                _cl2D.enabled = true;
            }
        }

    }
    private void Start()
    {
        _cl2D = GetComponent<Collider2D>();
    }
}
