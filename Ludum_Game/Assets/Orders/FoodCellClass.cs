using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FoodCellClass : MonoBehaviour
{
    public Text name;
    public List<FoodCellSpriteClass> sprites = new List<FoodCellSpriteClass>();
    public Text timer;
    public int readyTime;

    public ListObject foodCollection;
    
    public GameObject FoodBlockCell;

    private float _timer = 0;
    private int _timerInt = 0;
    private string hours = "";
    private string minutes = "";

    private void Awake()
    {
        name = gameObject.GetComponentInChildren<GuestNameClass>().gameObject.GetComponent<Text>();
        timer = gameObject.GetComponentInChildren<TimerFoodClass>().gameObject.GetComponent<Text>();

        sprites = gameObject.GetComponentInChildren<ReceiptFoodClass>().gameObject.GetComponentsInChildren<FoodCellSpriteClass>().ToList();

        readyTime = Random.Range(60, 120);
        _timer = readyTime;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _timerInt = System.Convert.ToInt32(_timer);
        bool pred = _timerInt / 60 < 10;
        bool predic = _timerInt % 60 < 10;
        hours = pred ? "0" + (_timerInt / 60) : System.Convert.ToString(_timerInt / 60);
        minutes = predic ? "0" + (_timerInt % 60) : System.Convert.ToString(_timerInt % 60);
        timer.text = hours + ":" + minutes;

        if ((System.Convert.ToInt32(hours) > 24))
        {
            hours = (System.Convert.ToInt32(hours) % 24).ToString();
        }

        if (_timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Retranslate()
    {
        Instantiate(FoodBlockCell,gameObject.GetComponentInChildren<ReceiptFoodClass>().transform);
    }
}
