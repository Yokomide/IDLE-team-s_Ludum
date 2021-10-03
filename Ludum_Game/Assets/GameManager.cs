using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static float money = 1000;
    public static float reputation = 4.9f;
    public static float mindStatePoints = 25;
    public static bool isCrazy = false;
    public static float timer = 0;

    private void Awake()
    {
        GameEvents.current.OnSchizoRise += AddSchizo;
        GameEvents.current.OnSchizoDecrease += RemoveSchizo;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Convert.ToInt32(timer) % 3 >= 1)
        {
            switch (UnityEngine.Random.Range(0, 1))
            {
                case 0:
                    GameEvents.current.SchizoRise();
                    break;
                case 1:
                    GameEvents.current.SchizoDecrease();
                    break;
            }
        }
    }

    public static void CheckState()
    {
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
