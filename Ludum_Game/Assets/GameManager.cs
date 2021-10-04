using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameManager current;
    public static float money = 1000;
    public static float reputation = 4.9f;
    public static float mindStatePoints = 25;
    public static bool isCrazy = false;
    public static float timer = 0;

    public GameObject orderCanvas;
    public GameObject foodCanvas;

    private void Awake()
    {
        current = this;
        GameEvents.current.OnSchizoRise += AddSchizo;
        GameEvents.current.OnSchizoDecrease += RemoveSchizo;
    }

    private void Start()
    {
        orderCanvas.GetComponent<GraphicRaycaster>().enabled = false;
        orderCanvas.GetComponent<Canvas>().targetDisplay = 1;
        foodCanvas.GetComponent<GraphicRaycaster>().enabled = false;
        foodCanvas.GetComponent<Canvas>().targetDisplay = 1;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
    public static void SchizoRandom()
    {
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                AddSchizo();
                break;
            case 1:
                RemoveSchizo();
                break;
        }
        CheckState();
    }

    public static void CheckState()
    {
        Debug.LogWarning(mindStatePoints);
        if (mindStatePoints >= 90)
        {
            isCrazy = true;
            GameEvents.current.SchizoAction();
        }
    }
    public static void AddSchizo(float num)
    {
        mindStatePoints += num;
        CheckState();
    }
    public static void AddSchizo()
    {
        float num = UnityEngine.Random.Range(10, 20);
        mindStatePoints += num;
        CheckState();
    }

    public static void RemoveSchizo(float num)
    {
        mindStatePoints -= num;
        CheckState();
    }

    public static void RemoveSchizo()
    {
        float num = UnityEngine.Random.Range(10, 20);
        mindStatePoints -= num;
        CheckState();
    }

}
