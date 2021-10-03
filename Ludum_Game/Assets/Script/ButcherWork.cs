using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButcherWork : MonoBehaviour
{
    public GameObject progress;
    public GameObject player;
    public GameObject food;
    public ProgressBar progressBar;

    public float cookProgress;
    public float invokeDelay = 0.5f;

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
        if (_isActive == true)
        {
            if (cookProgress != 10)
            {
                CookingDelay();
                _isActive = false;
            }
        }
        if (cookProgress == 10)
        {
            gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = player.transform;
        }
    }

    void SpawnFood()
    {
        var Food = Instantiate(food, new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.3f), Quaternion.identity);
        Food.transform.parent = gameObject.transform;
    }
}
