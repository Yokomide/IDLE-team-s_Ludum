using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButcherWork : MonoBehaviour
{
    public List<string> Tablefood = new List<string>();

    public GameObject Relax;
    public GameObject progress;
    public GameObject finished;
    public GameObject food_rice;
    public GameObject food_potato;
    public GameObject Food;
    public GameObject table;
    public GameObject BadQuality;

    public ProgressBar progressBar;
    public float cookProgress;
    public float invokeDelay = 0.5f;
    

    public bool isOnTable = false;
    public bool isDelivery = false;
    public bool isBadFood = false;

    private bool _isActive = false;
    private bool _isCooking = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CookTable")
        {
            progress.SetActive(true);
            _isActive = true;
            _isCooking = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        progress.SetActive(false);
        _isActive = false;
        _isCooking = false;

    }

    void Cook()
    {
        cookProgress += 1;
        progressBar.FillSlider(cookProgress);

        if (cookProgress == 10)
        {
            SpawnFood();
        }
        _isActive = true;
        Debug.Log(cookProgress);
    }

    void CookingDelay()
    {
        if (_isCooking == true)
        {
            Invoke("Cook", invokeDelay);
        }
    }

    void Update()
    {
        Tablefood = table.GetComponent<CheckPlace>().foodTags;
        if(isOnTable == true && isDelivery == false)
        {
            gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = table.transform;
        }
        if (_isActive == true)
        {
            if (cookProgress != 10 && isDelivery == false)
            {
                CookingDelay();
                _isActive = false;
            }
        }
        if (cookProgress == 10)
        {
            if (isBadFood == false)
            {
                isDelivery = true;
                gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = finished.transform;
                if (Vector2.Distance(transform.position, finished.transform.position) <= 1f)
                {
                    Debug.Log("Да");
                    Food.transform.position = new Vector3(finished.transform.position.x, finished.transform.position.y + 0.4f, 0);
                    Food.transform.parent = finished.transform;
                    progressBar.FillSlider(0);
                    isDelivery = false;
                    cookProgress = 0;
                    gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = Relax.transform;
                    BadQuality.SetActive(false);
                }
            }
            else if (isBadFood == true)
            {
                isDelivery = true;
                gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = Relax.transform;
                if (Vector2.Distance(transform.position, Relax.transform.position) <= 1f)
                {
                    progressBar.FillSlider(0);
                    isDelivery = false;
                    cookProgress = 0;
                    isBadFood = false;
                    BadQuality.SetActive(false);

                }
            }
        }
    }

    void SpawnFood()
    {
        if(Tablefood.Contains("Meat") && Tablefood.Contains("Rice") && Tablefood.Contains("Tomato"))
        { 
            Food = Instantiate(food_rice, new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.3f), Quaternion.identity);
            Food.transform.parent = gameObject.transform;
            isBadFood = false;
            BadQuality.GetComponent<Text>().text = "YOU HAVE SUCCESSFULY COOKED A DISH"; 
            BadQuality.GetComponent<Text>().color = Color.green;
            BadQuality.SetActive(true);
        }
        if (Tablefood.Contains("Meat") && Tablefood.Contains("Potato") && Tablefood.Contains("Tomato"))
        {
            Food = Instantiate(food_potato, new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.3f), Quaternion.identity);
            Food.transform.parent = gameObject.transform;
            isBadFood = false;
            BadQuality.GetComponent<Text>().text = "YOU HAVE SUCCESSFULY COOKED A DISH";
            BadQuality.GetComponent<Text>().color = Color.green;
            BadQuality.SetActive(true);
        }
        else if ( (Tablefood.Contains("Rice") && Tablefood.Contains("Potato")))
        {
            Debug.Log("Вы испортили блюдо");
            BadQuality.GetComponent<Text>().text = "YOU RUINED THE DISH";
            BadQuality.GetComponent<Text>().color = Color.red;
            BadQuality.SetActive(true);
            isBadFood = true;
           
            
        }

    }
}
