using System;
using UnityEngine;

public class TakeProviderButton : MonoBehaviour
{

    public void OnClick()
    {
        var texting = gameObject.GetComponentInParent<ProviderCellClass>().cost.text;
        GameManager.money -= Convert.ToInt32(texting.Remove(texting.Length-1));
        GameManager.SchizoRandom();
        Destroy(gameObject.GetComponentInParent<ProviderCellClass>().gameObject);
    }
}
