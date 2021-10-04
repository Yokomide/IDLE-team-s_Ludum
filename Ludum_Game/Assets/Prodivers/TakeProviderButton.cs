using System;
using UnityEngine;

public class TakeProviderButton : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void OnClick()
    {
        var texting = gameObject.GetComponentInParent<ProviderCellClass>().cost.text;
        if (GameManager.money - Convert.ToInt32(texting) >= 0)
        {
            GameManager.money -= Convert.ToInt32(texting.Remove(texting.Length - 1));
            GameManager.SchizoRandom();
            Destroy(gameObject.GetComponentInParent<ProviderCellClass>().gameObject);
        }

        
    }
}
