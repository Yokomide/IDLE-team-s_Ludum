using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TakeProviderButton : MonoBehaviour
{
    List<ContentTextClass> texts = new List<ContentTextClass>();

    List<string> food = new List<string>();

    public void OnClick()
    {
        var texting = gameObject.GetComponentInParent<ProviderCellClass>().cost.text;
        if (GameManager.money - Convert.ToInt32(texting.Remove(texting.Length - 1)) >= 0)
        {
            GameManager.money -= Convert.ToInt32(texting.Remove(texting.Length - 1));
            GameManager.SchizoRandom();
            texts = gameObject.GetComponentInParent<ProviderCellClass>().GetComponentInChildren<ListClass>().GetComponentsInChildren<ContentTextClass>().ToList();
            foreach(ContentTextClass t in texts)
            {
                food.Add(t.GetComponent<Text>().text);
            }
            Conveer.current.AcceptFoodList(food);
            Destroy(gameObject.GetComponentInParent<ProviderCellClass>().gameObject);

        }

        
    }
}
