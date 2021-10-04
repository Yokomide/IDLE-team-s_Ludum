using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTableToServe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RottenMeal"))
        {
            GameManager.reputation -= 0.5f;
            GameManager.AddSchizo();
            StartCoroutine(Delete(collision.gameObject));
        }
        if (collision.gameObject.CompareTag( "RiceMeal"))
        {
            GameManager.reputation += 0.5f;
            GameManager.money += 250f;
            StartCoroutine(Delete(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("PotatoMeal"))
        {
            GameManager.reputation += 0.5f;
            GameManager.money += 350f;
            StartCoroutine(Delete(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("BadMeal"))
        {
            GameManager.reputation -= 0.5f;
            GameManager.AddSchizo();
            StartCoroutine(Delete(collision.gameObject));
        }
    }

    IEnumerator Delete(GameObject gam)
    {
        yield return new WaitForSeconds(2f);
        Destroy(gam);
    }
}
