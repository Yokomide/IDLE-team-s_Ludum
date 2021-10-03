using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProviderMenuClass : MonoBehaviour
{
    public List<ProviderCellClass> providers = new List<ProviderCellClass>();


    private void Start()
    {
        providers = gameObject.GetComponentsInChildren<ProviderCellClass>().ToList();



    }

    void CreateList()
    {

    }
}
