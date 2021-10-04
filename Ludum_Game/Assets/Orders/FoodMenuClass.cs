using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenuClass : MonoBehaviour
{
    public static FoodMenuClass current;
    public List<FoodCellClass> receipts = new List<FoodCellClass>();
    public List<GameObject> cells = new List<GameObject>();
    public ListObject foodList;

    public FoodCellClass cell;

    private float chance = 100;

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        CreateList();
    }

    private void Update()
    {
        if (System.Convert.ToInt32(GameManager.timer) % 15 > 0 && Random.Range(0, 1000) > 995 && chance >= 60)
        {
            var c = Instantiate(cell, transform);
            receipts.Add(c);
            cells.Add(c.gameObject);
            chance -= 20;
            c.name.text = "Name";
            for (int i = 0; i < Random.Range(2, 5); i++)
            {
                c.Retranslate();

            }
            switch (Random.Range(0, 4))
            {
                case 0:
                    c.name.text = "Gustav";
                    break;
                case 1:
                    c.name.text = "Mike";
                    break;
                case 2:
                    c.name.text = "Helena";
                    break;
                case 3:
                    c.name.text = "Jane";
                    break;
            }
            foreach (FoodReceiptClass food in c.GetComponentsInChildren<FoodReceiptClass>())
            {
                food.GetComponentInChildren<FoodCellSpriteClass>().GetComponent<Image>().sprite = (foodList.list[Random.Range(0, foodList.list.Count - 1)]).sprite;
            }
        }
    }

    public void CreateList()
    {
        if (cells.Count != 0)
        {
            foreach (GameObject i in cells)
            {
                Destroy(i);
            }
        }
        cells.Clear();
        receipts.Clear();
        receipts = gameObject.GetComponentsInChildren<FoodCellClass>().ToList();
        foreach (FoodCellClass rec in receipts)
        {

            for (int i = 0; i < Random.Range(2, 5); i++)
            {
                rec.Retranslate();
            }
            foreach (FoodReceiptClass food in rec.GetComponents<FoodReceiptClass>())
            {
                food.GetComponentInChildren<FoodCellSpriteClass>().GetComponent<Image>().sprite = (foodList.list[Random.Range(0, foodList.list.Count - 1)]).sprite;
            }
        }
    }


}
