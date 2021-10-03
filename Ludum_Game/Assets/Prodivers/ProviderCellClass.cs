using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProviderCellClass : MonoBehaviour
{
    public Text name;
    public Text stars;
    public Text cost;
    public List<ContentTextClass> providersList = new List<ContentTextClass>();
    public List<Text> contentList = new List<Text>();

    private void Awake()
    {
        name = gameObject.GetComponentInChildren<NameClass>().gameObject.GetComponent<Text>();
        stars = gameObject.GetComponentInChildren<StarsClass>().gameObject.GetComponent<Text>();
        cost = gameObject.GetComponentInChildren<CostClass>().gameObject.GetComponent<Text>();

        providersList = gameObject.GetComponentInChildren<ListClass>().gameObject.GetComponentsInChildren<ContentTextClass>().ToList();
    }


}
