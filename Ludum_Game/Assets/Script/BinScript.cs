using UnityEngine;

public class BinScript : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Meat") || other.CompareTag("Rice") || other.CompareTag("Tomato") || other.CompareTag("Potato")) || (other.CompareTag("RottenMeat")))
        {

            if (!other.GetComponent<DragDrop>().isDragging)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
