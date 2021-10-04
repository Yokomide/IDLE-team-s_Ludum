using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProviderMenuClass : MonoBehaviour
{
    public static ProviderMenuClass current;
    public List<ProviderCellClass> providers = new List<ProviderCellClass>();
    public List<GameObject> objecti = new List<GameObject>();
    public ProviderCellClass cell;
    public GameObject textPrefab;

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        CreateList();
    }

    public void CreateList()
    {
        if (objecti.Count != 0)
        {
            foreach (GameObject i in objecti)
            {
                Destroy(i);
            }
        }
        objecti.Clear();
        providers.Clear();
        for (int i = 0; i < UnityEngine.Random.Range(2, 4); i++)
        {
            var cellProv = Instantiate(cell, transform);
            objecti.Add(cellProv.gameObject);
            providers.Add(cellProv);
        }
        providers = gameObject.GetComponentsInChildren<ProviderCellClass>().ToList();
        foreach (ProviderCellClass prov in providers)
        {
            switch (UnityEngine.Random.Range(0, 5))
            {
                case 0:
                    prov.name.text = "Bebrow";
                    break;
                case 1:
                    prov.name.text = "Meater";
                    break;
                case 2:
                    prov.name.text = "Miskaris";
                    break;
                case 3:
                    prov.name.text = "Meatorg";
                    break;
                case 4:
                    prov.name.text = "Barbar";
                    break;
                case 5:
                    prov.name.text = "Shewrp";
                    break;
            }
            prov.cost.text = Convert.ToString(UnityEngine.Random.Range(75, 200)) + "$";
            prov.stars.text = "";
            for (int i = 0; i < UnityEngine.Random.Range(1, 5); i++)
            {
                prov.stars.text += "★";
            }
            for (int i = 0; i < UnityEngine.Random.Range(3, 8); i++)
            {
                var text = Instantiate(textPrefab, prov.GetComponentInChildren<ListClass>().gameObject.transform);
                switch (UnityEngine.Random.Range(0, 9))
                {
                    case 0:
                        text.GetComponent<Text>().text = "Meat";
                        break;
                    case 1:
                        text.GetComponent<Text>().text = "Potato";
                        break;
                    case 2:
                        text.GetComponent<Text>().text = "Shrooms";
                        break;
                    case 3:
                        text.GetComponent<Text>().text = "Sauce";
                        break;
                    case 4:
                        text.GetComponent<Text>().text = "RottenShroom";
                        break;
                    case 5:
                        text.GetComponent<Text>().text = "RottenPotato";
                        break;
                    case 6:
                        text.GetComponent<Text>().text = "Rice";
                        break;
                    case 7:
                        text.GetComponent<Text>().text = "Tomato";
                        break;
                    case 8:
                        text.GetComponent<Text>().text = "RottenMeat";
                        break;


                }
            }

        }
    }
}
