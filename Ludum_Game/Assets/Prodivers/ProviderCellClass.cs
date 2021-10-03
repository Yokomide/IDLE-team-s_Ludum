using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProviderCellClass : MonoBehaviour
{
    private Text _name;
    private Text _stars;
    private Text _cost;
    private List<ContentTextClass> _providersList = new List<ContentTextClass>();
    private List<Text> _contentList = new List<Text>();

    private void Start()
    {
        _name = gameObject.GetComponentInChildren<NameClass>().gameObject.GetComponent<Text>();
        _stars = gameObject.GetComponentInChildren<StarsClass>().gameObject.GetComponent<Text>();
        _cost = gameObject.GetComponentInChildren<CostClass>().gameObject.GetComponent<Text>();

        _providersList = gameObject.GetComponentInChildren<ListClass>().gameObject.GetComponentsInChildren<ContentTextClass>().ToList();
    }


}
